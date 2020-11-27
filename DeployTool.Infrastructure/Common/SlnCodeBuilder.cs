using System.IO;
using System.Linq;
using System.Net;
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
            return new SlnCodeBuilder(msBuildSetting);
        }
    }
    public class SlnCodeBuilder : ICodeBuilder
    {
        private readonly MsBuildSetting _msBuildSetting;

        public SlnCodeBuilder(MsBuildSetting msBuildSetting)
        {
            _msBuildSetting = msBuildSetting;
        }
        public void Build()
        {
            if (!File.Exists(_msBuildSetting.MsBuildPath))
            {
                throw new CustomException("MsBuild Path Error！");
            }
            if (!File.Exists(_msBuildSetting.SlnPath))
            {
                throw new CustomException("Sln Path Error！");
            }


            MsBuilder builder = new MsBuilder(_msBuildSetting.MsBuildPath,_msBuildSetting.SlnPath, _msBuildSetting.BuildConfiguration);
            bool success = builder.Build(out string buildOutput);
            if (!success)
            {
                throw new CustomException("編譯錯誤！" + buildOutput);
            }
        }


    }
}
