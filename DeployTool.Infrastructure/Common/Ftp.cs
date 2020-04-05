using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using DeployTool.Core.Interfaces.Common;
using DeployTool.Core.ValueObjects;
using DeployTool.SharedKernel.Exceptions;
using FluentFTP;

namespace DeployTool.Infrastructure.Common
{
    public class FtpFactory : IFtpFactory
    {
        public IFtp Create(FtpSetting ftpSetting)
        {
            return new Ftp(ftpSetting);
        }
    }
    public class Ftp : IFtp
    {
        private readonly FtpClient _ftpClient;
        public Ftp(FtpSetting ftpSetting)
        {
            _ftpClient = ftpSetting.UserName != null ?
                new FtpClient(ftpSetting.Host, new NetworkCredential(ftpSetting.UserName, ftpSetting.Password)) :
                new FtpClient(ftpSetting.Host);
        }
        public void UploadDirectory(string localFolder, string remoteFolder)
        {
            if (_ftpClient.UploadDirectory(localFolder, remoteFolder, FtpFolderSyncMode.Update , FtpRemoteExists.Overwrite).Any(r => r.IsFailed))
            {
                throw new CustomException("Ftp上傳失敗");
            }
        }

        public void UploadFile(string localPath, string remotePath)
        {
            if (_ftpClient.UploadFile(localPath, remotePath) != FtpStatus.Success)
            {
                throw new CustomException("Ftp上傳失敗");
            }
        }

        public void Dispose()
        {
            _ftpClient.Dispose();
        }
    }
}
