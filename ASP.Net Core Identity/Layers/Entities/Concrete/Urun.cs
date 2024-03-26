using Asp.Net_Core_Identity.Layers.Entities.Abstract;

namespace Asp.Net_Core_Identity.Layers.Entities.Concrete
{
    public class Urun : BaseEntity<int>
    {
        public string UrunAdi { get; set; }
        public int StokAdet { get; set; }
        public string KategoriAdi { get; set; }

        public int UrunFiyati { get; set; }

    }
}
