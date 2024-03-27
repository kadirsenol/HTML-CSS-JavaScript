using AJAX_for_HTTP_Methods.Layers.DataAccess.DBContexts;
using AJAX_for_HTTP_Methods.MyExtensions.AutoMapper;
using AJAX_for_HTTP_Methods.MyExtensions.Services;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.EntityFrameworkCore;


namespace AJAX_for_HTTP_Methods
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConstr")));
            builder.Services.AddIdentitySettings();
            builder.Services.AddNotyfSetting();
            builder.Services.AddSpecialPolicy();
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseNotyf();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
