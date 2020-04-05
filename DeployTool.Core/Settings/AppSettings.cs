using System;
using System.Collections.Generic;
using System.Text;

namespace DeployTool.Core.Settings
{
    public class AppSettings
    {
        public string CatalogSettingPath { get; set; }

        public string StartupPath { get; set; }

        public string GetWorkflowConfigPath(string catalogName, string workflowName)
        {
            return $"{StartupPath}\\configs\\{catalogName}\\{workflowName}.json";
        }      
        public string GetCatalogFolderPath(string catalogName)
        {
            return $"{StartupPath}\\configs\\{catalogName}";
        }
    }
}
