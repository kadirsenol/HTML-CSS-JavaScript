using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Bussines.Abstract;
using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Concrete;
using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Models.VMs.UserVM;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager userManager;
        private readonly IMapper mapper;
        private readonly INotyfService notyf;

        public AccountController(IUserManager userManager, IMapper mapper, INotyfService notyf)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.notyf = notyf;
        }
        public IActionResult Index()
        {
            UserLoginVM loginvm = new UserLoginVM();
            return View(loginvm);
        }

        [ValidateAntiForgeryToken] // asp-action tag helperi ve metodu post olan form tarafindan olusturulmus bir asptokeni cookie ile karsilastiriyor eger. Eger kendi urettigi token ile esit ise erisime izin veriyor.
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM loginVM)
        {
            if (ModelState.IsValid) // Tarayicinin JS kullanimi kapatilma ihtimaline karsin koruma. Kapatilirsa validjquery kodlari calismayacagindan oturu.
            {
                try
                {
                    User user = mapper.Map<User>(loginVM);
                    User user1 = await userManager.ChackUser(user);

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Email,user1.Email),
                        new Claim(ClaimTypes.Name,user1.Ad),
                        new Claim("TcNo",user1.TcNo.ToString()),
                        new Claim(ClaimTypes.Role,user1.Rol)
                    };

                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authenticationProperty = new AuthenticationProperties()
                    {
                        IsPersistent = loginVM.Rememberme
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity),
                        authenticationProperty);

                    if ((User.IsInRole("Admin")) && (User.Identity.IsAuthenticated))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else if ((User.IsInRole("Üye")) && (User.Identity.IsAuthenticated))
                    {
                        return RedirectToAction("Index", "Shopping");

                    }

                }
                catch (Exception ex)
                {
                    notyf.Error("Hata:" + ex.Message);
                }
            }
            else
            {
                notyf.Error("Hata: Tarayıcınızın JavaScript kullanım iznini kontrol edin, kapalı ise izin verin");
            }

            return RedirectToAction("Index", "Account");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");

        }
    }
}
