using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DeployTool.SharedKernel;

namespace DeployTool.Core.Models
{
    public class ProjectConfigModel : ValueObject
    {
        public string DeployWorkTargetPath { get; set; }
        public string OriginalFullPath { get; set; }
        public DateTime LastWriteTime { get; set; }
        public string ProjectPath { get; set; }
        public string TargetPath { get; set; }
        public bool Selected { get; set; }
        public List<string> IgnoreRules { get; set; }
        public List<string> ExceptIgnoreRules { get; set; }

        public ProjectConfigModel(DeployWorkConfig deployWorkConfig, ProjectConfig projectConfig)
        {
            OriginalFullPath = Path.Combine(deployWorkConfig.OriginalPath, projectConfig.ProjectPath);
            DeployWorkTargetPath = deployWorkConfig.TargetPath;
            LastWriteTime = deployWorkConfig.LastWriteTime;

            ProjectPath = projectConfig.ProjectPath;
            TargetPath = projectConfig.TargetPath;
            Selected = projectConfig.Selected;

            IgnoreRules = GetIgnore(deployWorkConfig.IgnoreRules);
            IgnoreRules.AddRange(GetIgnore(projectConfig.IgnoreRules));
            if (deployWorkConfig.IsIgnoreCs)
            {
                IgnoreRules.Add("*.[cC][sS]");
            }
            if (deployWorkConfig.IsIgnoreConfig)
            {
                IgnoreRules.Add("[aA][pP][pP].[cC][oO][nN][fF][iI][gG]");
                IgnoreRules.Add("[wW][eE][bB].[cC][oO][nN][fF][iI][gG]");
            }
            IgnoreRules = IgnoreRules.Distinct().ToList();

            ExceptIgnoreRules = GetExceptIgnoreRules(deployWorkConfig.IgnoreRules);
            ExceptIgnoreRules.AddRange(GetExceptIgnoreRules(projectConfig.IgnoreRules));
            ExceptIgnoreRules = ExceptIgnoreRules.Distinct().ToList();
        }

        private List<string> GetIgnore(string ignoreString)
        {
            if (ignoreString == null) return new List<string>();
            return ignoreString.Split('\r','\n')
                .Select(r => r.Trim())
                .Where(r => !string.IsNullOrEmpty(r))
                .Where(r => r[0] != '#')
                .Where(r => r[0] != '!').ToList();
        }

        private List<string> GetExceptIgnoreRules(string ignoreString)
        {
            if (ignoreString == null) return new List<string>();
            return ignoreString.Split('\r', '\n')
                .Select(r => r.Trim())
                .Where(r => !string.IsNullOrEmpty(r))
                .Where(r => r[0] != '#')
                .Where(r => r[0] == '!')
                .Select(r => r.Substring(1))
                .Select(r => r.Trim())
                .Where(r => !string.IsNullOrEmpty(r))
                .ToList();
        }
    }
}