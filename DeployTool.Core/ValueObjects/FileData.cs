using System.IO;
using DeployTool.SharedKernel;

namespace DeployTool.Core.ValueObjects
{
    public class FileData : ValueObject
    {
        [IgnoreMember]
        public FileInfo FileInfo { get; }
        public string Path { get; }
        public FileData(FileInfo fileInfo, DirectoryData directoryData)
        {
            FileInfo = fileInfo;
            Path = System.IO.Path.Combine(directoryData.Path, FileInfo.Name);
        }
    }
}