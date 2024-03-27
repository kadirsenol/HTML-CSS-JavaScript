using Asp.Net_Core_Identity.Layers.Entities.Concrete;
using ASP.Net_Core_Identity.Models.VMs.Account;
using AutoMapper;

namespace ASP.Net_Core_Identity.MyExtensions.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RegisterVm, MyUser>().ReverseMap();
        }
    }
}
