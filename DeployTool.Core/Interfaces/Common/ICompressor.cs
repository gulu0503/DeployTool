using System;

namespace DeployTool.Core.Interfaces.Common
{
    public interface ICompressor 
    {
        void Compress(string originalPath, string targetPath);

        void Compress(string originalPath, string targetPath, string password);

    }
}
