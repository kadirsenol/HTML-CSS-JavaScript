using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Abstract;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Concrete
{
    public class Urun : BaseEntity<int>
    {
        public string UrunAdi { get; set; }
        public int StokAdet { get; set; }
        public string KategoriAdi { get; set; }

        public int UrunFiyati { get; set; }

    }
}
