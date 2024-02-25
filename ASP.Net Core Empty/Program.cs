namespace ASP.Net_Core_Empty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();


            app.UseStaticFiles();//root klasorunun public edilmesi.

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
