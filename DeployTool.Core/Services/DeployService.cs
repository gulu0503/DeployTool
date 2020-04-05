using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DeployTool.Core.Interfaces.Common;
using DeployTool.Core.Interfaces.Services;
using DeployTool.Core.Models;
using DeployTool.Core.Repositories;
using DeployTool.Core.Settings;
using DeployTool.Core.ValueObjects;
using DeployTool.SharedKernel.Exceptions;
using Microsoft.Extensions.Options;

namespace DeployTool.Core.Services
{
    public class DeployService : IDeployService
    {
        private readonly ICatalogConfigRepository _catalogConfigRepository;
        private readonly ICatalogRepository _catalogRepository;
        private readonly IWorkflowConfigRepository _workflowConfigRepository;
        private readonly IFtpFactory _ftpFactory;
        private readonly ICompressor _compressor;
        private readonly ICodeBuilderFactory _codeBuilderFactory;
        private readonly IOptions<AppSettings> _appSettings;

        public DeployService(ICatalogConfigRepository catalogConfigRepository,
            ICatalogRepository catalogRepository,
            IWorkflowConfigRepository workflowConfigRepository,
            IFtpFactory ftpFactory,
            ICompressor compressor,
            ICodeBuilderFactory codeBuilderFactory,
            IOptions<AppSettings> appSettings)
        {
            _catalogConfigRepository = catalogConfigRepository;
            _catalogRepository = catalogRepository;
            _workflowConfigRepository = workflowConfigRepository;
            _ftpFactory = ftpFactory;
            _compressor = compressor;
            _codeBuilderFactory = codeBuilderFactory;
            _appSettings = appSettings;
        }
        public void ExecuteDeploy(WorkflowConfig workflowConfig)
        {
            var targetFolderName = workflowConfig.GetTargetFolderName();
            //編譯
            if (workflowConfig.IsBuild)
            {
                CodeBuild(workflowConfig);
            }

            var fileCopyMappingModels = workflowConfig.Projects
                    //取得被選取的專案
                    .Where(r => r.Selected)
                    .Select(p => new ProjectConfigModel(workflowConfig, p))
                    //取得所有資料夾
                    .ToProjectDirectoryDatas()
                    //取得所有檔案
                    .ToProjectFileDatas().ToList()
                    //依IgnoreRule設定排除檔案
                    .FilterByIgnoreRule()
                    //依最後修改日期排除檔案
                    .FilterByLastWriteTime()
                    .ToFileCopyMappingModels(targetFolderName)
                    .Distinct()
                    .ToList();

            //預先建立空資料夾
            if (workflowConfig.IsKeepEmptyDir)
            {
                CreateEmptyDirectory(workflowConfig);
            }

            //複製檔案
            fileCopyMappingModels.DoCopy();

            //無檔案不進行後續動作
            if (!fileCopyMappingModels.Any())
            {
                throw new CustomException(@"無檔案！");
            }


            //壓縮
            if (workflowConfig.IsCompression)
            {
                Compression(workflowConfig);
            }

            //利用FTP發佈
            if (workflowConfig.IsPublishToFtp)
            {
                PublishToFtp(workflowConfig);
            }

            //利用磁碟機發佈
            if (workflowConfig.IsPublishToDisk)
            {
                PublishToDisk(workflowConfig);
            }

            //寫FileList Txt
            WriteFileList(workflowConfig, fileCopyMappingModels.Select(r => r.TargetPath).ToList());
        }

        private void CodeBuild(WorkflowConfig workflowConfig)
        {
            var codeBuilder = _codeBuilderFactory.Create(new MsBuildSetting(workflowConfig.MsBuildPath,
                workflowConfig.SlnPath, workflowConfig.BuildConfiguration));
            codeBuilder.Build();
        }

        private void CreateEmptyDirectory(WorkflowConfig workflowConfig)
        {
            var targetFolderName = workflowConfig.GetTargetFolderName();
            workflowConfig.Projects
                //取得被選取的專案
                .Where(r => r.Selected)
                .Select(p => new ProjectConfigModel(workflowConfig, p))
                //取得所有資料夾
                .ToProjectDirectoryDatas()
                //依IgnoreRule設定排除檔案
                .FilterByIgnoreRule()
                //依建立日期和最後修改日期排除檔案
                .FilterByLastWriteTime()
                .CreateDirectory(targetFolderName);
        }

        private void Compression(WorkflowConfig workflowConfig)
        {
            var targetDirectoryPath = workflowConfig.GetTargetDirectoryPath();
            var compressionFileName = workflowConfig.GetCompressionFileName();
            var compressionFilePath = workflowConfig.GetCompressionFilePath();
            _compressor.Compress(targetDirectoryPath, compressionFilePath, workflowConfig.CompressionPassword);

            if (!workflowConfig.IsCopyToFtp) return;

            var ftpSetting = workflowConfig.FtpUserName == null
                ? new FtpSetting(workflowConfig.FtpUserName)
                : new FtpSetting(workflowConfig.FtpUrl, workflowConfig.FtpUserName, workflowConfig.FtpPassword);
            using (var ftp = _ftpFactory.Create(ftpSetting))
            {
                ftp.UploadFile(compressionFilePath, Path.Combine(workflowConfig.FtpPath, compressionFileName));
            }
        }

        private void PublishToFtp(WorkflowConfig workflowConfig)
        {
            var directoryName = workflowConfig.GetTargetDirectoryPath();
            var ftpSetting = workflowConfig.PublishFtpUserName == null
                ? new FtpSetting(workflowConfig.PublishFtpUrl)
                : new FtpSetting(workflowConfig.PublishFtpUrl, workflowConfig.PublishFtpUserName, workflowConfig.PublishFtpPassword);
            using (var ftp = _ftpFactory.Create(ftpSetting))
            {
                ftp.UploadDirectory(directoryName, workflowConfig.PublishFtpPath);
            }
        }

        private void PublishToDisk(WorkflowConfig workflowConfig)
        {
            var directoryName = workflowConfig.GetTargetDirectoryPath();
            DirectoryCopy(directoryName, workflowConfig.DiskPath, true);
        }

        private void WriteFileList(WorkflowConfig workflowConfig, List<string> fileList)
        {
            var fileListPath = workflowConfig.GeFileListPath();
            File.AppendAllText(fileListPath, string.Join("\r\n", fileList.ToArray()));
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            var dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
            }

            var dirs = dir.GetDirectories();
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            var files = dir.GetFiles();
            foreach (var file in files)
            {
                var tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, true);
            }

            if (!copySubDirs) return;

            foreach (var subDir in dirs)
            {
                var tempPath = Path.Combine(destDirName, subDir.Name);
                DirectoryCopy(subDir.FullName, tempPath, true);
            }

        }
    }
}
