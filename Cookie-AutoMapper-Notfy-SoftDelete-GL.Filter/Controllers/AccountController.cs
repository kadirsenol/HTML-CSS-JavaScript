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

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM loginVM)
        {
            if (ModelState.IsValid)
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
                        IsPersistent = true // Buraya modelden bir user1.rememberme fielde ekleyebilirsin.
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity),
                        authenticationProperty);

                    if (user1.Rol == "Admin")
                    {

                        //return RedirectToRoute(new { area = "Admin", controller = "Home", action = "Index" });
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else if (user1.Rol == "Üye")
                    {
                        return RedirectToAction("Index", "Shopping");
                    }

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    notyf.Error("Hata:" + ex.Message);
                }
            }
            else
            {
                notyf.Error("Hata: Tarayıcınızın JavaScript kullanım iznini kontrol edin, kapalı ise izin verin");
                ModelState.AddModelError("", "Hata: Tarayıcınızın JavaScript kullanım iznini kontrol edin, kapalı ise izin verin");

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
