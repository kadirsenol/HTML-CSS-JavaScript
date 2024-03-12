using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Bussines.Abstract;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Bussines.Concrete;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Models.AutoMapperProfile;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            #region ConStr
            //Ben constr yi repository ile cekiyorum fakat burada servislere de eklenbiliyor. Bunu manage user secrets için ekle
            #endregion

            #region Menagers
            builder.Services.AddScoped<IKullaniciManager, KullaniciManager>();
            builder.Services.AddScoped<IUrunManager, UrunManager>();
            #endregion


            #region AutoMapper
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));  // Sen bu AutoMapperConfig ile calis.
            #endregion

            #region AspNetCoreHero
            builder.Services.AddNotyf(config =>
            {
                config.DurationInSeconds = 10;
                config.IsDismissable = true;
                config.Position = NotyfPosition.BottomRight;
            });
            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); //wwwroot u public yapýyor

            app.UseRouting();

            app.UseAuthorization();

            #region AspNetCoreHero
            app.UseNotyf();
            #endregion

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
