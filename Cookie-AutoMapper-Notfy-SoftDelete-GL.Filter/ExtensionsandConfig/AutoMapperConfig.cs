using AutoMapper;
using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Concrete;
using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Models.VMs.MessageVM;
using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Models.VMs.UserVM;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.ExtensionsandConfig
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserLoginVM, User>().ReverseMap();
            CreateMap<MessageInsertVm, Message>().ReverseMap();
        }
    }
}
