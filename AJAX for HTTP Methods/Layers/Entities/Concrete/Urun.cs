using AJAX_for_HTTP_Methods.Layers.Entities.Abstract;

namespace AJAX_for_HTTP_Methods.Layers.Entities.Concrete
{
    public class Urun : BaseEntity<int>
    {
        public string UrunAdi { get; set; }
        public int StokAdet { get; set; }
        public string KategoriAdi { get; set; }

        public int UrunFiyati { get; set; }

    }
}
