using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Bussines.Abstract;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Bussines.Concrete;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.MyExtensions.Services
{
    public static class AddServices
    {
        public static IServiceCollection AddManager(this IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUrunManager, UrunManager>();
            return services;

        }
    }
}
