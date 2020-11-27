using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using DeployTool.Core.Models;
using DeployTool.Core.ValueObjects;

namespace DeployTool
{
    public static class Pipe
    {
        public static IEnumerable<DirectoryData> GetAllDirectoryInfos(this DirectoryData directoryData)
        {
            yield return directoryData;
            foreach (var child in directoryData.GetDirectories().SelectMany(GetAllDirectoryInfos))
            {
                yield return child;
            }
        }

        public static IEnumerable<(ProjectConfigModel projectConfig, IEnumerable<DirectoryData> allDirectoryDatas)> FilterByLastWriteTime
            (this IEnumerable<(ProjectConfigModel projectConfig, IEnumerable<DirectoryData> allDirectoryDatas)> projectDirectoryDatas)
        {
            return projectDirectoryDatas.Select(projectData =>
            {
                var projectConfig = projectData.projectConfig;
                var allDirectoryDatas = projectData.allDirectoryDatas;
                allDirectoryDatas = allDirectoryDatas.Where(directoryData => directoryData.LastWriteTime >= projectConfig.LastWriteTime || directoryData.CreationTime >= projectConfig.LastWriteTime);
                return (projectConfig, allDirectoryDatas);
            });
        }

        public static IEnumerable<FileData> GetAllFiles(this IEnumerable<DirectoryData> directoryInfos)
        {
            return directoryInfos.SelectMany(directoryInfo => directoryInfo.GetFiles());
        }

        public static IEnumerable<(ProjectConfigModel projectConfig, IEnumerable<DirectoryData> allDirectoryDatas)> ToProjectDirectoryDatas
            (this IEnumerable<ProjectConfigModel> projectConfigModels)
        {
            return projectConfigModels.Select(projectConfig =>
            {
                var directoryInfo = new DirectoryInfo(projectConfig.OriginalFullPath);
                var directoryData = new DirectoryData(directoryInfo);

                var allDirectoryInfos = directoryData.GetAllDirectoryInfos();

                return (projectConfig, allDirectoryInfos);
            });
        }

        public static IEnumerable<(ProjectConfigModel projectConfig, IEnumerable<DirectoryData> allDirectoryDatas)> FilterByIgnoreRule
            (this IEnumerable<(ProjectConfigModel projectConfig, IEnumerable<DirectoryData> allDirectoryDatas)> directoryDatas)
        {
            return directoryDatas.Select(directoryData =>
            {
                var projectConfig = directoryData.projectConfig;
                var allDirectoryDatas = directoryData.allDirectoryDatas;

                allDirectoryDatas = allDirectoryDatas.Where(dir =>
                    !(projectConfig.IgnoreRules.Any(ir => Regex.IsMatch(dir.Path, $"^{ir}")) &&
                      !projectConfig.ExceptIgnoreRules.Any(ir => Regex.IsMatch(dir.Path, $"^{ir}")))
                );
                return (projectConfig, allDirectoryDatas);
            });
        }


        public static IEnumerable<(ProjectConfigModel projectConfig, IEnumerable<FileData> allFileDatas)> ToProjectFileDatas
            (this IEnumerable<(ProjectConfigModel projectConfig, IEnumerable<DirectoryData> allDirectoryDatas)> projectDirectoryDatas)
        {
            return projectDirectoryDatas.Select(projectDirectoryData =>
            {
                var projectConfig = projectDirectoryData.projectConfig;
                var allDirectoryDatas = projectDirectoryData.allDirectoryDatas;

                var allFileDatas = allDirectoryDatas.GetAllFiles();
                return (projectConfig, allFileDatas);
            });
        }

        public static IEnumerable<(ProjectConfigModel projectConfig, IEnumerable<FileData> allFileDatas)> FilterByIgnoreRule
            (this IEnumerable<(ProjectConfigModel projectConfig, IEnumerable<FileData> allFileDatas)> projectFileDatas)
        {
            return projectFileDatas.Select(projectFileData =>
            {
                var projectConfig = projectFileData.projectConfig;
                var allFileDatas = projectFileData.allFileDatas;

                allFileDatas = allFileDatas.Where(file =>
                    !(projectConfig.IgnoreRules.Any(ir => Regex.IsMatch(file.Path, $"^{ir}")) &&
                      !projectConfig.ExceptIgnoreRules.Any(ir => Regex.IsMatch(file.Path, $"^{ir}")))
                );
                return (projectConfig, allFileDatas);
            });
        }

        public static IEnumerable<(ProjectConfigModel projectConfig, IEnumerable<FileData> allFileDatas)> FilterByLastWriteTime
            (this IEnumerable<(ProjectConfigModel projectConfig, IEnumerable<FileData> allFileDatas)> projectDatas)
        {
            return projectDatas.Select(projectData =>
            {
                var projectConfig = projectData.projectConfig;
                var allFileDatas = projectData.allFileDatas;

                allFileDatas = allFileDatas.Where(file => file.FileInfo.LastWriteTime >= projectConfig.LastWriteTime);
                return (projectConfig, allFileDatas);
            });
        }

        public static void CreateDirectory
            (this IEnumerable<(ProjectConfigModel projectConfig, IEnumerable<DirectoryData> allDirectoryDatas)> projectDirectoryDatas,string targetFolderName)
        {
            var items = projectDirectoryDatas.ToList();
            foreach (var item in items)
            {
                var projectConfig = item.projectConfig;
                var dataAllDirectoryDatas = item.allDirectoryDatas;
                foreach (var directoryData in dataAllDirectoryDatas)
                {
                    var directoryName = Path.Combine(projectConfig.DeployWorkTargetPath, targetFolderName, projectConfig.TargetPath, directoryData.Path);
                    if (!Directory.Exists(directoryName)) Directory.CreateDirectory(directoryName);
                }
            }
        }

        public static IEnumerable<FileCopyMappingModel> ToFileCopyMappingModels(this IEnumerable<(ProjectConfigModel projectConfig, IEnumerable<FileData> allFileDatas)> projectDatas,  string targetFolderName)
        {
            foreach (var projectData in projectDatas)
            {
                foreach (var fileData in projectData.allFileDatas)
                {
                    yield return new FileCopyMappingModel(
                        fileData.FileInfo,
                        Path.Combine(projectData.projectConfig.DeployWorkTargetPath , targetFolderName, projectData.projectConfig.TargetPath, fileData.Path));
                }
            }
        }

        public static void DoCopy(
            this IEnumerable<FileCopyMappingModel> fileCopyMappingModels)
        {
            var items = fileCopyMappingModels.ToList();
            foreach (var item in items)
            {
                var directoryName = Path.GetDirectoryName(item.TargetPath);
                if (!Directory.Exists(directoryName)) Directory.CreateDirectory(directoryName);

                var newFileInfo = item.OriginalFileInfo.CopyTo(item.TargetPath, false);
                newFileInfo.Attributes = System.IO.FileAttributes.Normal;
            }
        }

    }
}