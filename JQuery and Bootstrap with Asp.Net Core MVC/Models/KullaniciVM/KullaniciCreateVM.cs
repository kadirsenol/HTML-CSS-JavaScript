using System.ComponentModel.DataAnnotations;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Models.KullaniciVM
{
    public class KullaniciCreateVM
    {
        [MaxLength(20, ErrorMessage = "20 karakterden fazla isim girilemez")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "İsim Alanı Boş Geçilemez")] // Veritabanına uugramadan yapılabilecek tum kontroller
        public string Ad { get; set; }

        [Range(12, int.MaxValue, ErrorMessage = "11 karakterden fazla Tc No girilemez")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tc No Alanı Boş Geçilemez")]
        public int TcNo { get; set; }

        [MaxLength(50, ErrorMessage = "50 karakterden fazla şifre girilemez")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Alanı Boş Geçilemez")]
        public string Password { get; set; }

        [MaxLength(15, ErrorMessage = "15 karakterden fazla sehir girilemez")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Sehir Alanı Boş Geçilemez")]
        public string City { get; set; }
    }
}
