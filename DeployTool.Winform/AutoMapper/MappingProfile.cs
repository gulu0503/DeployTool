using AutoMapper;
using DeployTool.Core.Models;
using DeployTool.Ui.Models;

namespace DeployTool.Ui.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WorkflowConfig, WorkflowConfigDto>();
            CreateMap<WorkflowConfigDto, WorkflowConfig>();
            CreateMap<ProjectConfig, ProjectConfigDto>();
            CreateMap<ProjectConfigDto, ProjectConfig>();
        }
    }
}
