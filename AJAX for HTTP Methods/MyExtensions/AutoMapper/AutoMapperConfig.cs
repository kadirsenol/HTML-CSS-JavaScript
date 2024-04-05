using AJAX_for_HTTP_Methods.Layers.Entities.Concrete;
using AJAX_for_HTTP_Methods.Models.VMs.Account;
using AJAX_for_HTTP_Methods.Models.VMs.Message;
using AJAX_for_HTTP_Methods.Models.VMs.Urun;
using AutoMapper;

namespace AJAX_for_HTTP_Methods.MyExtensions.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RegisterVm, MyUser>().ReverseMap();
            CreateMap<UrunCreateVm, Urun>().ReverseMap();
            CreateMap<MessageCreateVm, Message>().ReverseMap();
            CreateMap<UrunUpdateVm, Urun>().ReverseMap();
            CreateMap<MessageUpdateVm, Message>().ReverseMap();
        }
    }
}
