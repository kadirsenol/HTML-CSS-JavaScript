using AutoMapper;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.Concrete;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Models.KullaniciVM;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Models.UrunVM;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Models.AutoMapperProfile
{
    public class AutoMapperConfig : Profile // Mapper i mizi configure edecegimiz class
    {
        public AutoMapperConfig()
        {
            CreateMap<KullaniciCreateVM, Kullanici>().ReverseMap(); // KullaniciVM i Kullaniciya cevir, gerekirse tam tersinide yapabil.
            CreateMap<KullaniciLoginVM, Kullanici>().ReverseMap();
            CreateMap<UrunInsertVM, Urun>().ReverseMap();
        }
    }
}
