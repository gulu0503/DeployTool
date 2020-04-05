using System;
using DeployTool.Core.ValueObjects;

namespace DeployTool.Core.Interfaces.Common
{
    public interface ICodeBuilder
    {
        void Build();
    }

    public interface ICodeBuilderFactory
    {
        ICodeBuilder Create(MsBuildSetting buildSetting);
    }
}
