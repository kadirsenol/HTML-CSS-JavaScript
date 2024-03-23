namespace WebAPI_for_Client_Side.Models.withToken
{
    public class Urun
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow.AddHours(3); // Sqlden baska bir db ye geciste config islemine gerek kalmamasini saglar.
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow.AddHours(3);
        public bool IsDelete { get; set; } = false;
        public string UrunAdi { get; set; }
        public int StokAdet { get; set; }
        public string KategoriAdi { get; set; }
        public int UrunFiyati { get; set; }

    }
}
