using System.ComponentModel.DataAnnotations;

namespace AJAX_for_HTTP_Methods.Models.VMs.Account
{
    public class RegisterVm
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email alani zorunludur")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName Alani Zorunludur")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Şifre Alani Zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Şifre Alani Zorunludur")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Girilen parolalar eşleşmiyor")]
        public string RePassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "TcNo Alani Zorunludur")]
        public int TcNo { get; set; }

    }
}
