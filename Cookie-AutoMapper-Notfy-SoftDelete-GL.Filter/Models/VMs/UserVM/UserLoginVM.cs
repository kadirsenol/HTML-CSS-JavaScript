using System.ComponentModel.DataAnnotations;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Models.VMs.UserVM
{
    public class UserLoginVM
    {
        [MaxLength(50, ErrorMessage = "50 karakterden fazla E-mail girilemez")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email alanı boş bırakılamaz.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen uygun formatta e-mail adresi giriniz")]
        public string Email { get; set; }

        [MaxLength(50, ErrorMessage = "50 karakterden fazla parola girilemez")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password alanı boş bırakılamaz")]
        public string Password { get; set; }
    }
}
