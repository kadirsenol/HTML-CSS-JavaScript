using AJAX_for_HTTP_Methods.Layers.Bussines.Abstract;
using AJAX_for_HTTP_Methods.Layers.Bussines.Concrete;
using AJAX_for_HTTP_Methods.Layers.DataAccess.DBContexts;
using AJAX_for_HTTP_Methods.Layers.Entities.Concrete;
using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Identity;

namespace AJAX_for_HTTP_Methods.MyExtensions.Services
{
    public static class AddServices
    {
        public static IServiceCollection AddScopedAll(this IServiceCollection services)
        {

            services.AddScoped<IMessageManager, MessageManager>();
            services.AddScoped<IKonuManager, KonuManager>();
            services.AddScoped<IUrunManager, UrunManager>();
            return services;
        }
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

        public static IServiceCollection AddSpecialPolicy(this IServiceCollection services) // Bu yontem sadece verilen degeri karsilamasi sartini ele alir. Eger istenmeyen durum varsa farkli yontem uygulaniyor.
        {                                                                                   // Burada TCNO adında bir politika olusturduk ve bunu TcNo adinda ki bir claim imize bagladik.
            services.AddAuthorization(options => options.AddPolicy(                         // Sarti ise:Kimlikte ki TcNo claim degeri sadece 123 olan kullanicilara yetki izni verilmesidir.
                "TCNO", policy => policy.RequireClaim("TcNo", "123")));
            return services;
        }
    }
}
