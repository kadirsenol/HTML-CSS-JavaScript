using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.Abstract;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.Concrete
{
    public class Urun : BaseEntity<int>
    {
        public string UrunAdi { get; set; }
        public int StokAdet { get; set; }
        public string KategoriAdi { get; set; }

        public int UrunFiyati { get; set; }

    }
}
