using System.ComponentModel.DataAnnotations;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Models.KullaniciVM
{
    public class KullaniciLoginVM
    {
        [Range(12, int.MaxValue, ErrorMessage = "11 karakterden fazla Tc No girilemez")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tc No Alanı Boş Geçilemez")]
        public int TcNo { get; set; }

        [MaxLength(50, ErrorMessage = "50 karakterden fazla şifre girilemez")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Alanı Boş Geçilemez")]
        public string Password { get; set; }
    }
}
