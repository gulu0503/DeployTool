using System.IO;
using DeployTool.Core.Models;
using DeployTool.Core.Settings;
using DeployTool.Core.Repositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DeployTool.Infrastructure.Repositories
{
    public class DeployWorkConfigRepository : IDeployWorkConfigRepository
    {
        private readonly IOptions<AppSettings> _appSettings;

        public DeployWorkConfigRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public DeployWorkConfig Read(string catalogName,string deployWorkName)
        {
            var path = Path.Combine(_appSettings.Value.ConfigPath, "configs", catalogName, $"{deployWorkName}.json");
            var json = File.ReadAllText(path);
            var projectConfig = JsonConvert.DeserializeObject<DeployWorkConfig>(json);
            return projectConfig;
        }

        public void Save(string catalogName, string deployWorkName,DeployWorkConfig deployWorkConfig)
        {
            var path = Path.Combine(_appSettings.Value.ConfigPath, "configs", catalogName, $"{deployWorkName}.json");
            var json = JsonConvert.SerializeObject(deployWorkConfig,Formatting.Indented);
            File.WriteAllText(path,json);
        }
    }
}