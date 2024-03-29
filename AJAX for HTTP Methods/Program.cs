using AJAX_for_HTTP_Methods.Layers.DataAccess.DBContexts;
using AJAX_for_HTTP_Methods.MyExtensions.AutoMapper;
using AJAX_for_HTTP_Methods.MyExtensions.Services;
using AspNetCoreHero.ToastNotification.Extensions;


namespace AJAX_for_HTTP_Methods
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<SqlDbContext>();//Identity paketini kullandýgim icin ve pakette user, role kurallari bulundugundan bu kurallarin yonetimini saglayacak dbcontexti servislere bildirmek zorundayim.
                                                          //Eger DbContextimi, identityDbContexten degil de DbContexten inherit alsaydim servislere dbcontexti eklemek zorunda olmayacaktým ama ekleyerekde configure edebilicektim.
                                                          //DbContextOption ile constryi belirtmememde ki sebep; repo tasarimimda dbcontextimi generic tasarladim ve dbcontextimin parametresiz olarakda newlenmesi gerekiyor ve haliyle constrsi DbContext icerisinde ovverride edilmesi gerekiyor. DbContext icerisinde constr bulundugu icin birdaha program.cs de belirtmeye gerek olmadýgi icin burda constr belirtmedim. Zaten DbContext classimda DbContextOptions ile constryi program.csden al ve baseye gonder ctorunu kullanmadim.
                                                          //Eger SqlDbContextim parametresiz newlenmesi gerekmiyorsa(repo generic degilse) DbContextinin icerisinde constryi baseden almasi gerektigini ctorla belirt ve servislere de secret.json icerisinde belirttigin constr yi referans gececek sekilde AddDbContext i ekle. Bu sekilde DbContext icerisinde onconfiguring metodunu override edilmesine gerek yok. Bu hem guvenli hemde degisiklik esnasinda koda degil json dosyasina mudehale ile kolaylik saglar.
                                                          //Sonuc olarak ya DbContextinin generic olmasindan vazgeciceksin yada Constryi DbContextinin icerisinde vericeksin.

            builder.Services.AddIdentitySettings();
            builder.Services.AddNotyfSetting();
            builder.Services.AddSpecialPolicy();
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
            builder.Services.AddScopedAll();


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
