using AutoMapper;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Concrete;
using Web_API_with_JSON_Web_Token_for_Server_Side.Models.VMs.UserVM;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.MyExtensions.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserLoginVm, User>().ReverseMap();
        }
    }
}
