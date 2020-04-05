using System.IO;
using DeployTool.Core.Models;
using DeployTool.Core.Settings;
using DeployTool.Core.Repositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DeployTool.Infrastructure.Repositories
{
    public class WorkflowConfigRepository : IWorkflowConfigRepository
    {
        private readonly IOptions<AppSettings> _appSettings;

        public WorkflowConfigRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public WorkflowConfig Read(string catalogName,string workflowName)
        {
            var path = $"{_appSettings.Value.StartupPath}\\configs\\{catalogName}\\{workflowName}.json";
            var json = File.ReadAllText(path);
            var projectConfig = JsonConvert.DeserializeObject<WorkflowConfig>(json);
            return projectConfig;
        }

        public void Save(string catalogName, string workflowName,WorkflowConfig workflowConfig)
        {
            var path = $"{_appSettings.Value.StartupPath}\\configs\\{catalogName}\\{workflowName}.json";
            var json = JsonConvert.SerializeObject(workflowConfig);
            File.WriteAllText(path,json);
        }
    }
}