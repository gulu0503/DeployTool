using System.IO;
using DeployTool.Core.Models;
using DeployTool.Core.Repositories;
using DeployTool.Core.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DeployTool.Infrastructure.Repositories
{
    public class CatalogConfigRepository : ICatalogConfigRepository
    {
        private readonly IOptions<AppSettings> _appSettings;

        public CatalogConfigRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public CatalogConfig Read()
        {
            var path = Path.Combine(_appSettings.Value.ConfigPath, "configs", "CatalogSetting.json");
            var json = File.ReadAllText(path);
            var projectConfig = JsonConvert.DeserializeObject<CatalogConfig>(json);
            return projectConfig;
        }

        public void Save(CatalogConfig data)
        {
            var path = Path.Combine(_appSettings.Value.ConfigPath, "configs", "CatalogSetting.json");
            var json = JsonConvert.SerializeObject(data,Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}