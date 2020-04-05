using DeployTool.Core.Models;

namespace DeployTool.Core.Repositories
{
    public interface ICatalogConfigRepository : IJsonRepository<CatalogConfig>
    {
        CatalogConfig Read();
        void Save(CatalogConfig data);
    }
}