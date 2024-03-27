using System.ComponentModel.DataAnnotations;

namespace AJAX_for_HTTP_Methods.Models.VMs.Account
{
    public class LoginVm
    {
        [Required(ErrorMessage = "Email Alani Zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Alani Zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}
