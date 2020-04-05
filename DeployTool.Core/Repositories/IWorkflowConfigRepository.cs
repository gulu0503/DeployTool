using DeployTool.Core.Models;
using DeployTool.Core.Repositories;

namespace DeployTool.Core.Repositories
{
    public interface IWorkflowConfigRepository : IJsonRepository<WorkflowConfig>
    {
        WorkflowConfig Read(string catalogName, string workflowName);
        void Save(string catalogName, string workflowName, WorkflowConfig workflowConfig);
    }
}