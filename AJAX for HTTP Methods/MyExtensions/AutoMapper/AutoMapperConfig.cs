using AJAX_for_HTTP_Methods.Layers.Entities.Concrete;
using AJAX_for_HTTP_Methods.Models.VMs.Account;
using AutoMapper;

namespace AJAX_for_HTTP_Methods.MyExtensions.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RegisterVm, MyUser>().ReverseMap();
        }
    }
}
