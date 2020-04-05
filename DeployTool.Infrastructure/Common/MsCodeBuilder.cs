using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using DeployTool.Core.Interfaces.Common;
using DeployTool.Core.ValueObjects;
using DeployTool.SharedKernel.Exceptions;
using FluentFTP;

namespace DeployTool.Infrastructure.Common
{
    public class CodeBuilderFactory : ICodeBuilderFactory
    {
        public ICodeBuilder Create(MsBuildSetting msBuildSetting)
        {
            return new MsCodeBuilder(msBuildSetting);
        }
    }
    public class MsCodeBuilder : ICodeBuilder
    {
        private readonly MsBuildSetting _msBuildSetting;

        public MsCodeBuilder(MsBuildSetting msBuildSetting)
        {
            _msBuildSetting = msBuildSetting;
        }
        public void Build()
        {
            var p = new Process();
            p.StartInfo.FileName = _msBuildSetting.MsBuildPath;
            p.StartInfo.Arguments = _msBuildSetting.SlnPath + " /p:Configuration=" + _msBuildSetting.BuildConfiguration;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine("exit");
            var strRst = p.StandardOutput.ReadToEnd();
            if (strRst.IndexOf("0 個錯誤") == -1)
            {
                throw new CustomException("編譯錯誤！");
            }
        }
    }
}
