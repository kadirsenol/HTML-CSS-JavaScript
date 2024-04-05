using System.ComponentModel.DataAnnotations;

namespace AJAX_for_HTTP_Methods.Models.VMs.Urun
{
    public class UrunCreateVm
    {

        [Required(ErrorMessage = "Kategori Adı Boş Bırakılamaz")]
        public string KategoriAdi { get; set; }

        [Required(ErrorMessage = "Stok Adedi Boş Bırakılamaz")]
        public int? StokAdet { get; set; }

        [Required(ErrorMessage = "Ürün Adı Boş Bırakılamaz")]
        public string UrunAdi { get; set; }

        [Required(ErrorMessage = "Ürün Fiyatı Boş Bırakılamaz")]
        public int? UrunFiyati { get; set; }
    }
}
