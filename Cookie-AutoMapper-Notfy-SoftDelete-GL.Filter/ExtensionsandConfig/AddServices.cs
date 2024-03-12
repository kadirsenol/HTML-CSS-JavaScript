using AspNetCoreHero.ToastNotification;
using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Bussines.Abstract;
using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Bussines.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.ExtensionsandConfig
{
    public static class AddServices
    {
        public static IServiceCollection AddCookieSetting(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "CookieDeneme";
                options.LoginPath = "/Account/Index";//Eger bir controlle erisim sirasinda autontacion gerekli ise otomatik yonlendirilecek path.
                options.LogoutPath = "/Account/Logaut";
                options.AccessDeniedPath = "/Account/Stop";
                options.Cookie.HttpOnly = true;//Yalnizca http istekleri sonucunda cookie ulasilir. Script isteklerinde ulasim engellenir.
                options.Cookie.SameSite = SameSiteMode.Strict;//Bizim tarayıcımız dışında kullanılmasi engellenir. Sahte sitelere karsi alinmis onlem
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);//10 dakika boyunca hareketsiz kalinmasi halinde cookie silinir ve logout olunur
                options.SlidingExpiration = true;//Yukarida ki kisitlama sureyi kullanici her istek yaptiginda tekrar basa sarar.
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

        public static IServiceCollection AddScopedAll(this IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
            return services;
        }

    }
}
