using System.Collections.Generic;
using System.IO;
using System.Linq;
using DeployTool.Core.Settings;
using DeployTool.Core.Repositories;
using Microsoft.Extensions.Options;

namespace DeployTool.Infrastructure.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly IOptions<AppSettings> _appSettings;

        public CatalogRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }
        public List<string> GetCatalogs()
        {
            var directories = Directory.EnumerateDirectories(Path.Combine(_appSettings.Value.ConfigPath, "configs"));
            return directories.Select(r => r.Split('\\').Last()).ToList();
        }

        public List<string> GetWorkFlowConfigs(string catalogName)
        {
            var files = Directory.EnumerateFiles(Path.Combine(_appSettings.Value.ConfigPath, "configs", catalogName));
            return files.Select(Path.GetFileNameWithoutExtension).ToList();
        }
    }
}