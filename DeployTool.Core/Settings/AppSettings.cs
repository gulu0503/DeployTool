using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DeployTool.Core.Settings
{
    public class AppSettings
    {
        public string CatalogSettingPath { get; set; }

        public string ConfigPath { get; set; }

        public string GetDeployWorkConfigPath(string catalogName, string deployWorkName)
        {
            return Path.Combine(ConfigPath, $"configs\\{catalogName}\\{deployWorkName}.json");
        }      
        public string GetCatalogFolderPath(string catalogName)
        {
            return Path.Combine(ConfigPath, $"configs\\{catalogName}");
        }
    }
}
