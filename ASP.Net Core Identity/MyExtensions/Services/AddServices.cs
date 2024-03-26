using Asp.Net_Core_Identity.Layers.DataAccess.DBContexts;
using Asp.Net_Core_Identity.Layers.Entities.Concrete;
using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Identity;

namespace ASP.Net_Core_Identity.MyExtensions.Services
{
    public static class AddServices
    {
        public static IServiceCollection AddIdentitySettings(this IServiceCollection services)
        {
            //Burasi IOC Container a Identity eklemesini soyluyoruz yani Identity'in sunduğu özelliklerden (kimlik doğrulama, yetkilendirme, roller yönetimi vb.) yararlanabilmek için. Bunu kullanmazsak bu sunulan özelliklerden yararlanamayız.
            services.AddIdentity<MyUser, IdentityRole>()
                .AddEntityFrameworkStores<SqlDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                #region Password Kurallari
                options.Password.RequireDigit = false; //Olusacak sifrenin icinde rakam zorunlulugu olsun mu ?
                options.Password.RequireLowercase = false; //Kucuk harf zorunlulugu olsun mu ?
                options.Password.RequireUppercase = false; //Buyuk harf zorunlulugu olsun mu ?
                options.Password.RequireNonAlphanumeric = false; //#$½%& gibi karakterler icermek zorunda mı ? 
                #endregion

                #region User Kurallari
                options.User.RequireUniqueEmail = true; // Email uniq olsun mu ?
                options.User.AllowedUserNameCharacters = @"abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@"; //Isimler turkce ve ingilizce karakterlerden ve -._@ karakterler icerebilir. 
                #endregion

                #region SignIn Kurallari
                options.SignIn.RequireConfirmedPhoneNumber = false; //Telefon numarasi ile confirm etme zorunlulugu olsun mu ?
                options.SignIn.RequireConfirmedEmail = false;//Email ile confirm etme zorunlulugu olsun mu ? 
                #endregion

                #region LockOut Kurallari
                options.Lockout.AllowedForNewUsers = false; //Yeni kullanicilarin hesaplari kilitlensin mi ?
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10); //Kullanicinin hesabi kilitlenmisse ne kadar kilitli kalsin ?  
                options.Lockout.MaxFailedAccessAttempts = 20; //Default olarak 5dk icerisinde 20 kere hatali giris gerceklesirse kullanici hesabi kilitlensin.   
                #endregion
            });
            return services;
        }

        public static IServiceCollection AddNotyfSetting(this IServiceCollection services)
        {
            services.AddNotyf(config =>
            {
                config.DurationInSeconds = 10;
                config.IsDismissable = true;
                config.Position = NotyfPosition.BottomRight;
            });

            return services;
        }
    }
}
