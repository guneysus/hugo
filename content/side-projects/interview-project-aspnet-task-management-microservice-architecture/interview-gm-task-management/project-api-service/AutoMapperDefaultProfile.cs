using AutoMapper;
using project_api_contracts;
using project_api_contracts.Entities;

namespace project_api_service
{
    public class AutoMapperDefaultProfile : Profile
    {
        public AutoMapperDefaultProfile(string profileName) : base(profileName)
        {
            CreateMap<ProjectCreateModel, Project>().ReverseMap();
        }
    }
}
