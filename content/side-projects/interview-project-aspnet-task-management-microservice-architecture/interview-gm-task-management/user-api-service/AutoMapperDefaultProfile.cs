using AutoMapper;
using user_api_contracts;
using user_api_contracts.Entities;

namespace user_api_service
{
    public class AutoMapperDefaultProfile : Profile
    {
        public AutoMapperDefaultProfile(string profileName) : base(profileName)
        {
            CreateMap<UserRegisterModel, User>().ReverseMap();
            CreateMap<UserInfoModel, User>().ReverseMap();
        }
    }
}
