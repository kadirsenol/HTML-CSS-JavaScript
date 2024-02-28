namespace ASP.Net_Core_Empty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();


            app.UseStaticFiles();//root klasorunun public edilmesi.

            app.MapGet("/", async context =>
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/html/Index.html");
                var content = await File.ReadAllTextAsync(filePath);
                await context.Response.WriteAsync(content);
            });

            app.Run();
        }
    }
}
