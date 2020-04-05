using System;
using DeployTool.Core.ValueObjects;

namespace DeployTool.Core.Interfaces.Common
{
    public interface IFtpFactory
    {
        IFtp Create(FtpSetting ftpSetting);
    }

    public interface IFtp:IDisposable
    {
        void UploadDirectory(string localFolder, string remoteFolder);
        void UploadFile(string localPath, string remotePath);
    }
}
