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
        private readonly IDeployWorkConfigRepository _deployWorkConfigRepository;
        private readonly IFtpFactory _ftpFactory;
        private readonly ICompressor _compressor;
        private readonly ICodeBuilderFactory _codeBuilderFactory;
        private readonly IOptions<AppSettings> _appSettings;

        public DeployService(ICatalogConfigRepository catalogConfigRepository,
            ICatalogRepository catalogRepository,
            IDeployWorkConfigRepository deployWorkConfigRepository,
            IFtpFactory ftpFactory,
            ICompressor compressor,
            ICodeBuilderFactory codeBuilderFactory,
            IOptions<AppSettings> appSettings)
        {
            _catalogConfigRepository = catalogConfigRepository;
            _catalogRepository = catalogRepository;
            _deployWorkConfigRepository = deployWorkConfigRepository;
            _ftpFactory = ftpFactory;
            _compressor = compressor;
            _codeBuilderFactory = codeBuilderFactory;
            _appSettings = appSettings;
        }
        public void ExecuteDeploy(DeployWorkConfig deployWorkConfig)
        {
            var targetFolderName = deployWorkConfig.GetTargetFolderName();
            //編譯
            if (deployWorkConfig.IsBuild)
            {
                CodeBuild(deployWorkConfig);
            }

            var fileCopyMappingModels = deployWorkConfig.Projects
                    //取得被選取的專案
                    .Where(r => r.Selected)
                    .Select(p => new ProjectConfigModel(deployWorkConfig, p))
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
            if (deployWorkConfig.IsKeepEmptyDir)
            {
                CreateEmptyDirectory(deployWorkConfig);
            }

            //複製檔案
            fileCopyMappingModels.DoCopy();

            //無檔案不進行後續動作
            if (!fileCopyMappingModels.Any())
            {
                throw new CustomException(@"無檔案！");
            }


            //壓縮
            if (deployWorkConfig.IsCompression)
            {
                Compression(deployWorkConfig);
            }

            //利用FTP發佈
            if (deployWorkConfig.IsPublishToFtp)
            {
                PublishToFtp(deployWorkConfig);
            }

            //利用磁碟機發佈
            if (deployWorkConfig.IsPublishToDisk)
            {
                PublishToDisk(deployWorkConfig);
            }

            //寫FileList Txt
            WriteFileList(deployWorkConfig, fileCopyMappingModels.Select(r => r.TargetPath).ToList());
        }

        private void CodeBuild(DeployWorkConfig deployWorkConfig)
        {
            var codeBuilder = _codeBuilderFactory.Create(new MsBuildSetting(deployWorkConfig.MsBuildPath,
                deployWorkConfig.SlnPath, deployWorkConfig.BuildConfiguration));
            codeBuilder.Build();
        }

        private void CreateEmptyDirectory(DeployWorkConfig deployWorkConfig)
        {
            var targetFolderName = deployWorkConfig.GetTargetFolderName();
            deployWorkConfig.Projects
                //取得被選取的專案
                .Where(r => r.Selected)
                .Select(p => new ProjectConfigModel(deployWorkConfig, p))
                //取得所有資料夾
                .ToProjectDirectoryDatas()
                //依IgnoreRule設定排除檔案
                .FilterByIgnoreRule()
                //依建立日期和最後修改日期排除檔案
                .FilterByLastWriteTime()
                .CreateDirectory(targetFolderName);
        }

        private void Compression(DeployWorkConfig deployWorkConfig)
        {
            var targetDirectoryPath = deployWorkConfig.GetTargetDirectoryPath();
            var compressionFileName = deployWorkConfig.GetCompressionFileName();
            var compressionFilePath = deployWorkConfig.GetCompressionFilePath();
            _compressor.Compress(targetDirectoryPath, compressionFilePath, deployWorkConfig.CompressionPassword);

            if (!deployWorkConfig.IsCopyToFtp) return;

            var ftpSetting = deployWorkConfig.FtpUserName == null
                ? new FtpSetting(deployWorkConfig.FtpUserName)
                : new FtpSetting(deployWorkConfig.FtpUrl, deployWorkConfig.FtpUserName, deployWorkConfig.FtpPassword);
            using (var ftp = _ftpFactory.Create(ftpSetting))
            {
                ftp.UploadFile(compressionFilePath, Path.Combine(deployWorkConfig.FtpPath, compressionFileName));
            }
        }

        private void PublishToFtp(DeployWorkConfig deployWorkConfig)
        {
            var directoryName = deployWorkConfig.GetTargetDirectoryPath();
            var ftpSetting = deployWorkConfig.PublishFtpUserName == null
                ? new FtpSetting(deployWorkConfig.PublishFtpUrl)
                : new FtpSetting(deployWorkConfig.PublishFtpUrl, deployWorkConfig.PublishFtpUserName, deployWorkConfig.PublishFtpPassword);
            using (var ftp = _ftpFactory.Create(ftpSetting))
            {
                ftp.UploadDirectory(directoryName, deployWorkConfig.PublishFtpPath);
            }
        }

        private void PublishToDisk(DeployWorkConfig deployWorkConfig)
        {
            var directoryName = deployWorkConfig.GetTargetDirectoryPath();
            DirectoryCopy(directoryName, deployWorkConfig.DiskPath, true);
        }

        private void WriteFileList(DeployWorkConfig deployWorkConfig, List<string> fileList)
        {
            var fileListPath = deployWorkConfig.GeFileListPath();
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
