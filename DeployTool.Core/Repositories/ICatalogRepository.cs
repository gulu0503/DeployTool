using System.Collections.Generic;

namespace DeployTool.Core.Repositories
{
    public interface ICatalogRepository
    {
        List<string> GetCatalogs();
        List<string> GetWorkFlowConfigs(string catalogName);
    }
}