using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Models.VMs.MessageVM
{
    public class MessageInsertVm
    {
        [Required(ErrorMessage = "İsim Alanı Boş Bırakılamaz")]
        public string Ad { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "E-mail Alanı Boş Bırakılamaz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mesaj Alanı Boş Bırakılamaz")]
        public string Mesaj { get; set; }

        [Range(1, 5, ErrorMessage = "Lütfen Mesajınız için İlgili Konu Başlığını Seçiniz.")]
        public int KonuId { get; set; } // Burasi mapping esnasinda db modelimin KonuId propuna aktaracagım kısım için
        public ICollection<Konu>? Konular { get; set; } //= new List<Konu>(); // İlişkili olanları toplu olarak getirip buraya atabilmek için. Select options kısmında Bu konunun id sini kabul edilen InsertModelin KonuId sine esitleyeceğiz.

        public IFormFile? File { get; set; } // File icin sınırlamalar var mi arastir.
    }
}
