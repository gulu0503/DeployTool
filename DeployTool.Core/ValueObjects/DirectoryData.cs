using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DeployTool.SharedKernel;

namespace DeployTool.Core.ValueObjects
{
    public class DirectoryData : ValueObject
    {
        [IgnoreMember]
        private readonly DirectoryInfo _directoryInfo;
        public string Path { get; }
        public DateTime LastWriteTime { get; }
        public DateTime CreationTime { get; }
        public DirectoryData(DirectoryInfo directoryInfo)
        {
            _directoryInfo = directoryInfo;
            Path = "";
            LastWriteTime = _directoryInfo.LastWriteTime;
            CreationTime = _directoryInfo.CreationTime;
        }
        private DirectoryData(DirectoryInfo directoryInfo, DirectoryData parentDirectoryData)
        {
            _directoryInfo = directoryInfo;
            Path = System.IO.Path.Combine(parentDirectoryData.Path, _directoryInfo.Name);
            LastWriteTime = _directoryInfo.LastWriteTime;
            CreationTime = _directoryInfo.CreationTime;
        }

        public IEnumerable<FileData> GetFiles()
        {
            return _directoryInfo.EnumerateFiles().Select(file => new FileData(file, this));
        }

        public IEnumerable<DirectoryData> GetDirectories()
        {
            return _directoryInfo.GetDirectories().Select(directory => new DirectoryData(directory, this));
        }
    }
}