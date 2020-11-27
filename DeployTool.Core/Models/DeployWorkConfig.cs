using System;
using System.Collections.Generic;
using System.IO;
using DeployTool.SharedKernel;

namespace DeployTool.Core.Models
{
    public class DeployWorkConfig
    {
        public string OriginalPath { get; set; }
        public string TargetPath { get; set; }
        public DateTime LastWriteTime { get; set; }
        public DateTime LastExecuteTime { get; set; }
        public IEnumerable<ProjectConfig> Projects { get; set; }
        public string IgnoreRules { get; set; }
        public bool IsIgnoreCs { get; set; }
        public bool IsIgnoreConfig { get; set; }
        public bool IsKeepEmptyDir { get; set; }
        public bool IsCompression { get; set; }
        public bool IsBuild { get; set; }
        public bool IsCopyToFtp { get; set; }
        public string CompressionPassword { get; set; }
        public string FtpUrl { get; set; }
        public string FtpUserName { get; set; }
        public string FtpPassword { get; set; }
        public string FtpPath { get; set; }
        public bool IsPublishToFtp { get; set; }
        public string PublishFtpUrl { get; set; }
        public string PublishFtpUserName { get; set; }
        public string PublishFtpPassword { get; set; }
        public string PublishFtpPath { get; set; }
        public bool IsPublishToDisk { get; set; }
        public string DiskPath { get; set; }
        public string BuildConfiguration { get; set; }
        public string MsBuildPath { get; set; }
        public string SlnPath { get; set; }

        public string GetTargetFolderName()
        {
            return LastExecuteTime.ToString("yyyyMMddHHmmss");
        }

        public string GetTargetDirectoryPath()
        {
            return Path.Combine(TargetPath, GetTargetFolderName());
        }
        public string GetCompressionFileName()
        {
            return string.IsNullOrEmpty(CompressionPassword)
                ? $"{GetTargetFolderName()}.zip"
                : $"{GetTargetFolderName()}【password：{CompressionPassword}】.zip";
        }
        public string GetCompressionFilePath()
        {
            return Path.Combine(GetTargetDirectoryPath(), GetCompressionFileName());
        }

        public string GeFileListPath()
        {
            return Path.Combine(GetTargetDirectoryPath(), "FileList.txt");
        }
    }

    public class ProjectConfig:ValueObject
    {
        public string ProjectPath { get; set; }
        public string TargetPath { get; set; }
        public bool Selected { get; set; }
        public string IgnoreRules { get; set; }
    }
}