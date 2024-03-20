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

            #region Tek Satirlik Servis Eklentileri
            #region DbContext
            //builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConstr"))); // DBContext i servisler vasitasi ile saglamak mantikli oldugunda burayi kullan ve constr yi guvenlik acisindan screet dosyasina ekle. 
            #endregion 
            #endregion


            builder.Services.AddControllers(); //AddJsonOptions eklentisi ile Db den iliskili kayitlari da getirmek icin gerekli ayar. Bu eklenti ile respons, $id ve value degerleri ile geliyor.
            //builder.Services.AddControllers().AddJsonOptions(p =>
            //    p.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve
            //);




            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();
            #region Swagger Authorization icin gerekli kodlar
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
            app.UseAuthentication();//JWT ile login islemi icin Authentication middleware eklentisi
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
