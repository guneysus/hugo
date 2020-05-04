using AutoMapper;
using task_api_contracts;
using task_api_contracts.Entities;

namespace task_api_service
{
    public class AutoMapperDefaultProfile : Profile
    {
        public AutoMapperDefaultProfile(string profileName) : base(profileName)
        {
            CreateMap<TaskCreateModel, Task>().ReverseMap();
        }
    }
}
