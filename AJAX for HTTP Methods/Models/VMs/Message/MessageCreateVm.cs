using System.ComponentModel.DataAnnotations;

namespace AJAX_for_HTTP_Methods.Models.VMs.Message
{
    public class MessageCreateVm
    {

        [Required(ErrorMessage = "Ad Alanı Boş Bırakılamaz")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Email Alanı Boş Bırakılamaz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mesaj Alanı Boş Bırakılamaz")]
        public string Mesaj { get; set; }

        [Required(ErrorMessage = "Konu Alanı Boş Bırakılamaz")]
        public int? KonuId { get; set; }

    }
}
