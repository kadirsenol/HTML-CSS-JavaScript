using Asp.Net_Core_Identity.Layers.Entities.Concrete;
using ASP.Net_Core_Identity.Models.VMs.Account;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Core_Identity.Controllers
{
    public class AccountController(UserManager<MyUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<MyUser> signInManager, INotyfService notyf) : Controller
    {
        private readonly UserManager<MyUser> userManager = userManager;
        private readonly RoleManager<IdentityRole> roleManager = roleManager;
        private readonly SignInManager<MyUser> signInManager = signInManager;
        private readonly INotyfService notyf = notyf;

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Register()
        {
            RegisterVm registerVm = new RegisterVm();
            return View(registerVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVm registerVm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(registerVm);
                }
                MyUser myUser = new MyUser()
                {
                    Email = registerVm.Email,
                    UserName = registerVm.UserName
                };


                var result = await userManager.CreateAsync(myUser, registerVm.Password); // Parolayi hash leyerek kaydediyor.
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        if (item.Code.Contains("DuplicateEmail"))
                        {
                            throw new Exception($"{registerVm.Email} mail adresi zaten mevcut !");
                        }
                    }

                }

                if (await roleManager.FindByIdAsync("Üye") == null) // Eger Uye adinda rol yoksa uye rolu olustur
                {
                    IdentityRole role = new IdentityRole("Üye");
                    await roleManager.CreateAsync(role);
                }

                var result2 = await userManager.AddToRoleAsync(myUser, "Üye"); //Kayıt olan kullanici rolu uye olarak atandi.
                if (!result2.Succeeded)
                {
                    throw new Exception($"Kayıt sırasında bir hata olustu: {result2.Errors.First().Description}");
                }

                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                notyf.Error(ex.Message);
            }
            return View();
        }

        public async Task<IActionResult> Login()
        {
            LoginVm loginVm = new LoginVm();
            return View(loginVm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            return View();
        }
    }
}
