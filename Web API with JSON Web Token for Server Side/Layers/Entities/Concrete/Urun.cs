using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Abstract;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Concrete
{
    public class Urun : BaseEntity<int>
    {
        public string UrunAdi { get; set; }
        public int StokAdet { get; set; }
        public string KategoriAdi { get; set; }

        public int UrunFiyati { get; set; }

    }
}
