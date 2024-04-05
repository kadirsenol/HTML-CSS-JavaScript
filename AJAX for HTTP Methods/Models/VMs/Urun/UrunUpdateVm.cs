namespace AJAX_for_HTTP_Methods.Models.VMs.Urun
{
    public class UrunUpdateVm
    {
        public int Id { get; set; }
        public string? KategoriAdi { get; set; }
        public int? StokAdet { get; set; }
        public string? UrunAdi { get; set; }
        public int? UrunFiyati { get; set; }
    }
}
