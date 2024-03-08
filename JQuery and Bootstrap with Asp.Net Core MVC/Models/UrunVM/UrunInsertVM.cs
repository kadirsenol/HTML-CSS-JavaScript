using System.ComponentModel.DataAnnotations;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Models.UrunVM
{
    public class UrunInsertVM
    {

        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "50 karakterden fazla ürün adı girilemez")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ürün Adı Boş Geçilemez")]
        public string UrunAdi { get; set; }

        [Range(1, 100, ErrorMessage = "1-100 adet arası Stok giriniz")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Stok Alanı Boş Geçilemez")]
        public int StokAdet { get; set; }

        [MaxLength(50, ErrorMessage = "50 karakterden fazla Kategori Adı girilemez")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kategori Alanı Boş Geçilemez")]
        public string KategoriAdi { get; set; }

        [Range(1, 100000, ErrorMessage = "1 - 100000 aralığında Fiyat giriniz")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fiyat Alanı Boş Geçilemez")]
        public int UrunFiyati { get; set; }
    }
}
