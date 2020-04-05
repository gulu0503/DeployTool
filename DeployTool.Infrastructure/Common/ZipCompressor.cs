using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using DeployTool.Core.Interfaces.Common;
using FluentFTP;
using Ionic.Zip;

namespace DeployTool.Infrastructure.Common
{
    public class ZipCompressor : ICompressor
    {
        public void Compress(string originalPath, string targetPath)
        {
            Compress(originalPath, targetPath,null);
        }

        public void Compress(string originalPath, string targetPath, string password)
        {
            if (originalPath == null) throw new ArgumentNullException(nameof(originalPath));
            if (targetPath == null) throw new ArgumentNullException(nameof(targetPath));
            using (ZipFile zip = new ZipFile(targetPath, Encoding.UTF8))
            {
                if (!string.IsNullOrEmpty(password))
                {
                    zip.Password = password;
                }
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                zip.AddDirectory(originalPath);
                zip.Save();
            }
        }
    }
}
