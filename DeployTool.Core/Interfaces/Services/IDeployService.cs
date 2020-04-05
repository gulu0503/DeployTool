using System;
using System.Collections.Generic;
using System.Text;
using DeployTool.Core.Models;

namespace DeployTool.Core.Interfaces.Services
{
    public interface IDeployService
    {
        void ExecuteDeploy(WorkflowConfig workflowConfig);
    }
}
