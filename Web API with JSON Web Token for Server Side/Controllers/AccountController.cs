using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Bussines.Abstract;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Concrete;
using Web_API_with_JSON_Web_Token_for_Server_Side.Models.VMs.UserVM;
using Web_API_with_JSON_Web_Token_for_Server_Side.MyExtensions.Tokens;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserManager userManager;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public AccountController(IUserManager userManager, IMapper mapper, IConfiguration configuration) // Key degerini secrets dosyasina gecebilmek adini IConfigi istedik
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<string> Login(UserLoginVm userLoginVm) // IActionResult olarak dönüp return kisminda Ok(userWithToken.AccessToke) olarak donebilirsin. Else kısmına da Problem("Kullanici adi sifre hatali")
        {
            User user = mapper.Map<User>(userLoginVm);
            User user1 = await userManager.ChackUser(user);
            if (user1 != null)
            {
                TokenManager tokenManager = new TokenManager();
                User userwithToken = await tokenManager.CreateToken(user1, configuration);
                userManager.Update(userwithToken); // Token ve refresh token bilgileri db de tutulsun refresh sorugusu olacak mı arastir.
                return userwithToken.AccessToken;
            }
            else
            {
                return null;
            }

        }

        //Register kısmını web site uzerinden gerceklestirecegim icin api tarafinda yazmadim.
    }
}
