using DeployTool.Core.Models;
using DeployTool.Core.Repositories;

namespace DeployTool.Core.Repositories
{
    public interface IDeployWorkConfigRepository : IJsonRepository<DeployWorkConfig>
    {
        DeployWorkConfig Read(string catalogName, string deployWorkName);
        void Save(string catalogName, string deployWorkName, DeployWorkConfig deployWorkConfig);
    }
}