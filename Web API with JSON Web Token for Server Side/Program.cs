using Web_API_with_JSON_Web_Token_for_Server_Side.MyExtensions.AutoMapper;
using Web_API_with_JSON_Web_Token_for_Server_Side.MyExtensions.Services;

namespace Web_API_with_JSON_Web_Token_for_Server_Side
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.

            builder.Services.AddManager(); //MyExtensions class
            builder.Services.AddTokenSetting(builder.Configuration); //MyExtensions class (Burada configuration nesnesi builderin içinde hazirda var. Ama baska yerde IConfiguration olarak olusturaman gerekli.)

            #region Tek Satirlik Servis Eklentileri
            #region DbContext
            //builder.Services.AddDbContext<SqlDbContext>(); // DbContexti servislerden saglamak gerekirse burayi servislere ekle. Eger dbcontext icerisinde OnConfigurin override edilip constr verilmisse burayi constrsiz, OnConfigurin override edilmemisse secret.json dosyasina "ConnectionStrings":{"constr":"xxx"} seklinde ConnectionStrings olarak belirt ve keyini servise refere gec.
            #endregion

            #region AutoMapper
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
            #endregion

            #endregion


            builder.Services.AddControllers();
            #region Db den ilgili kayitlari getirmek icin gerekli AddController eklentisi
            //Kullanicaksan, burayi extension classina ekle ve AddSwagerGen eklentisini kaldirip extension classindaki olusturdugun metodu servislere ekle. Bu eklenti ile respons, $id ve value degerleri ile geliyor.

            //builder.Services.AddControllers().AddJsonOptions(p =>
            //    p.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve
            //); 
            #endregion




            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();
            #region Swagger Authorization icin gerekli kodlar
            // Kullanicaksan, burayi extension classina ekle ve AddSwagerGen eklentisini kaldirip extension classindaki olusturdugun metodu servislere ekle. 

            //        builder.Services.AddSwaggerGen(c =>
            //        {
            //            c.SwaggerDoc("v1", new OpenApiInfo
            //            {
            //                Title = "JWTToken_Auth_API",
            //                Version = "v1"
            //            });
            //            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            //            {
            //                Name = "Authorization",
            //                Type = SecuritySchemeType.ApiKey,
            //                Scheme = "Bearer",
            //                BearerFormat = "JWT",
            //                In = ParameterLocation.Header,
            //                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
            //            });
            //            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
            //    {
            //        new OpenApiSecurityScheme {
            //            Reference = new OpenApiReference {
            //                Type = ReferenceType.SecurityScheme,
            //                    Id = "Bearer"
            //            }
            //        },
            //        new string[] {}
            //    }
            //});
            //        });
            #endregion            

            #region CORS Policy
            // Kullanicaksan burayi extension classina ekle ve extension classinda ki olsuturdugun metodu servislere ekle. Ardindan app.User() middle wareyi uygula.

            //builder.Services.AddCors(options => options.AddDefaultPolicy(builder => // Butun originlerden gelen isteklerinde kabul edilmesi icin gerekli ayarlar eklentisi.
            //                                                            builder.AllowAnyHeader() //Gelen isteklerde butun basliklarin kabul edilmesi
            //                                                            .AllowAnyMethod()
            //                                                            .AllowAnyOrigin())); //Butun originlerden gelen isteklerin kabul edilmesi
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseCors();//Cors Policy eklentisinin kullanilmasini saglayan middleware eklentisi.
            app.UseHttpsRedirection();
            app.UseAuthentication();//JWT ile login islemi icin Authentication middleware eklentisi. JWT veya Cookie kullanmazsan buna gerek yok.
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
