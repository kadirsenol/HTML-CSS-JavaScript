using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Concrete;
using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Models.VMs.UserVM;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.ExtensionsandConfig.Cookies
{
    public class CookieManager()
    {

        public async Task CookieCreate(HttpContext HttpContext, User user, UserLoginVM loginVM)
        {
            var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.Name,user.Ad),
                        new Claim("TcNo",user.TcNo.ToString()),
                        new Claim(ClaimTypes.Role,user.Rol)
                    };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authenticationProperty = new AuthenticationProperties()
            {
                IsPersistent = loginVM.Rememberme
            };


            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                  new ClaimsPrincipal(claimIdentity),
                  authenticationProperty);

        }
    }
}
