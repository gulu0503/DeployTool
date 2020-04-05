using DeployTool.SharedKernel;

namespace DeployTool.Core.ValueObjects
{
    public class MsBuildSetting : ValueObject
    {
        public string MsBuildPath { get; }
        public string SlnPath { get; }
        public string BuildConfiguration { get; }

        public MsBuildSetting(string msBuildPath,string slnPath,string buildConfiguration)
        {
            MsBuildPath = msBuildPath;
            SlnPath = slnPath;
            BuildConfiguration = buildConfiguration;
        }
    }
}