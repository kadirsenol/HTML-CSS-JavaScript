using Microsoft.AspNetCore.Identity;

namespace Asp.Net_Core_Identity.Layers.Entities.Concrete
{
    public class MyUser : IdentityUser // IdentityUseri genisletebilmek icin Useri BaseEntity den inherit almayip problarini ayri olarak ekliyorum.
    {
        public DateTime CreateDate { get; set; } = DateTime.UtcNow.AddHours(3); // Sqlden baska bir db ye geciste config islemine gerek kalmamasini saglar.
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow.AddHours(3);
        public bool IsDelete { get; set; } = false;

        //IdentityUser nesnesinde olmasini istedigim BaseEntity proplari
        /*********************************************************/
        //IdentityUser nesnesinde olmasini istedigim ek proplar

        public int TcNo { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? ExprationToken { get; set; } // Tokenin gecerlilik suresi

    }
}
