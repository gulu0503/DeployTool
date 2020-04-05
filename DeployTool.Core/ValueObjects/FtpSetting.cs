using System;
using DeployTool.SharedKernel;

namespace DeployTool.Core.ValueObjects
{
    public class FtpSetting : ValueObject
    {
        public string Host { get; }
        public string UserName { get; }
        public string Password { get; }

        public FtpSetting(string host)
        {
            Host = host ?? throw new ArgumentNullException(nameof(host));
        }

        public FtpSetting(string host,string userName,string password)
        {
            Host = host ?? throw new ArgumentNullException(nameof(host));
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }
    }
}