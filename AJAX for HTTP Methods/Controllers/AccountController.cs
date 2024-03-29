using AAJAX_for_HTTP_Methods.MyExtensions.Email;
using AJAX_for_HTTP_Methods.Layers.Entities.Concrete;
using AJAX_for_HTTP_Methods.Models.VMs.Account;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace AJAX_for_HTTP_Methods.Controllers
{
    public class AccountController(UserManager<MyUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<MyUser> signInManager, INotyfService notyf, IMapper mapper) : Controller
    {
        private readonly UserManager<MyUser> userManager = userManager;
        private readonly RoleManager<IdentityRole> roleManager = roleManager;
        private readonly SignInManager<MyUser> signInManager = signInManager;
        private readonly INotyfService notyf = notyf;
        private readonly IMapper mapper = mapper;

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
                    throw new Exception("Tarayıcınızın JavaScript kullanımı devre dışı bırakılmış olabilir, lütfen kontrol edin. !");
                }

                MyUser myUser = mapper.Map<MyUser>(registerVm);

                var result = await userManager.CreateAsync(myUser, registerVm.Password); // Parolayi hash leyerek kaydediyor.
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        if (item.Code.Contains("DuplicateEmail"))
                        {
                            throw new Exception($"{registerVm.Email} mail adresi zaten mevcut !");
                        }
                        if (item.Code.Contains("DuplicateName"))
                        {
                            throw new Exception($"{registerVm.UserName} kullanıcı adı zaten mevcut !");
                        }
                        if (item.Code.Contains("PasswordTooShort"))
                        {
                            throw new Exception($"Şifre en az 6 karakterden oluşmalıdır. !"); //Bunu validation atribute ile yapabilirsin.
                        }
                        else
                        {
                            throw new Exception($"Kullanıcı kayıt sırasında bir hata olustu, lütfen tekrar deneyiniz. !");
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

                var code = await userManager.GenerateEmailConfirmationTokenAsync(myUser);
                StringBuilder message = new();
                message.AppendLine("<html>");
                message.AppendLine("<head>")
                    .AppendLine("<meta charset='UTF-8'")
                    .AppendLine("</head>");
                message.AppendLine($"<p> Merhaba {myUser.UserName} </p> <br>");
                message.AppendLine("<p> Üyeliğini tamamlamak için aşşağıda ki linke tıklaman yeterli olucak. </p>");
                message.AppendLine($"<a href='http://localhost:5257/ConfirmEmail?uid={myUser.Id}&code={code}'> Tıklayın. </a>");
                message.AppendLine("</body>");
                message.AppendLine("</html>");

                EmailHelper emailHelper = new EmailHelper();
                bool sonuc = await emailHelper.SendEmail(myUser.Email, message.ToString());
                if (sonuc)
                {
                    notyf.Information($"{myUser.Email} adresine bir doğrulama linki gönderdik, üyeliğinin tamamlanması için mail içerisinde ki linke tıklamalısın.");
                }
                else
                {
                    throw new Exception("Mail gönderimi sırasında bir hata oluştu. Lütfen tekrar deneyin.");
                }

            }
            catch (Exception ex)
            {
                notyf.Error(ex.Message);
            }
            return View();
        }

        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string uid, string code)
        {
            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(code))
            {
                var user = await userManager.FindByIdAsync(uid);
                code = code.Replace(' ', '+');
                var result = await userManager.ConfirmEmailAsync(user, code);

                if (result.Succeeded)
                {
                    notyf.Success("Üyelik işlemi başarıyla tamamlandı, giriş yapabilirsin. :)");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    notyf.Error("Mail onaylama işlemi başarısız, lütfen tekrar deneyin. !");
                }
            }
            else
            {
                notyf.Error("Mail onaylama sırasında bir hata oluştu, lütfen tekrar deneyiniz. !");
            }
            return RedirectToAction("Register", "Account");
        }

        public async Task<IActionResult> Login()
        {
            LoginVm loginVm = new LoginVm();
            return View(loginVm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Tarayıcınızın JavaScript kullanımı devre dışı bırakılmış olabilir, lütfen kontrol edin. !");
                }
                else
                {
                    var user = await userManager.FindByEmailAsync(loginVm.Email);
                    if (user == null)
                    {
                        throw new Exception($"{loginVm.Email} adresli kullanıcı mevcut değil. !");
                    }
                    if (!await userManager.IsEmailConfirmedAsync(user))
                    {
                        throw new Exception($"{user.Email} mail adresi onaylanmamış. !");
                    }

                    await signInManager.SignOutAsync(); // Her ihtimale karşın çıkış yapilir
                    var result = await signInManager.PasswordSignInAsync(user, loginVm.Password, loginVm.RememberMe, false);

                    #region AddClaims
                    List<Claim> claims = new List<Claim>()
                    {
                        //new Claim(ClaimTypes.Name,user.UserName),
                        new Claim("TcNo",user.TcNo.ToString())
                    };
                    await userManager.AddClaimsAsync(user, claims);
                    var claim = await userManager.GetClaimsAsync(user);
                    #endregion

                    if (result.Succeeded)
                    {
                        ICollection<string> rol = new List<string>();
                        rol = await userManager.GetRolesAsync(user);
                        if (rol.First().Contains("Admin"))
                        {
                            notyf.Success("Giriş işlemi başarılı.!");
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else if (rol.First().Contains("Üye"))
                        {
                            notyf.Success("Giriş işlemi başarılı.!");
                            return RedirectToAction("Index", "Profile", new { area = "" });
                        }

                    }
                    else
                    {
                        throw new Exception("Kullanıcı adı veya parola hatalı. !");
                    }
                }
            }
            catch (Exception ex)
            {
                notyf.Error(ex.Message);
            }

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
