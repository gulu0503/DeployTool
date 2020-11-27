using AutoMapper;
using DeployTool.Core.Models;
using DeployTool.WinForm.Models;

namespace DeployTool.Ui.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DeployWorkConfig, DeployWorkConfigDto>();
            CreateMap<DeployWorkConfigDto, DeployWorkConfig>();
            CreateMap<ProjectConfig, ProjectConfigDto>();
            CreateMap<ProjectConfigDto, ProjectConfig>();
        }
    }
}
