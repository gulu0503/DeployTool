using System.IO;
using DeployTool.SharedKernel;

namespace DeployTool.Core.ValueObjects
{
    public class FileCopyMappingModel : ValueObject
    {
        public string OriginalPath { get; }
        public string TargetPath { get; }

        [IgnoreMember]
        public FileInfo OriginalFileInfo { get; }
        public FileCopyMappingModel(FileInfo originalFileInfo, string targetPath)
        {
            OriginalFileInfo = originalFileInfo;
            OriginalPath = originalFileInfo.FullName;
            TargetPath = targetPath;
        }
    }
}