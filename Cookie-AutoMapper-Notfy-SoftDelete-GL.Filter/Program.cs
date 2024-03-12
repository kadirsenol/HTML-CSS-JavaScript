using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.ExtensionsandConfig;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();//AddRazor extension metodu; anlik degisimleri
                                                                                    //refresh esnasinda hemen yansitiyor.



            #region DbContext
            /*builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConstr")));*/ // Normalde dbcontext icerisinde ki constr efnin cli kullanimi icindir. bu nedenle constr yi servis icin ayrý belirtmek durumundayiz.
                                                                                                                                                     // Guvenlik acisindan(Db ve server ismi) constr yi secrets dosyamýza gomduk ve "MyConstr" ile orayý refere ediyoruz.
                                                                                                                                                     // Bu kod tek satir olmasý acisindan extesions classýna eklenmesine gerek yoktur.
                                                                                                                                                     // Ama bu projede herhangi bir ctora bagimli olarak dbcontext vermedigim icin bunu comment isaretliyorum. 
                                                                                                                                                     // Servislere ilk bagýmlý nesneyi verdikten sonra ilgili nesnenin bagýmlýlýklarýný kendimiz newletebiliriz cunku bi kere ilk basta servis newleme islemini baslatti.
            #endregion
            #region AutoMapper
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
            #endregion


            #region ExtensionsandConfig
            builder.Services.AddNotyfSetting();
            builder.Services.AddCookieSetting();
            builder.Services.AddScopedAll();
            builder.Services.AddSpecialPolicy(); // TCNO adinda bir policy olusturdum ve bunu TcNo adinda ki claim im ile birlestirdim. Ve policy olustururken iceriginin 123 olmasini istedim. Bunu [Authorize(Policy ="TCNO")] ile dene.
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); //Authentication ozelligini kullanmasi icin ekliyoruz
            app.UseAuthorization();

            app.UseEndpoints(endpoints => //Admin alani icin, varsa router i ekliyoruz.
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
