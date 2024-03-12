using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Controllers
{
    [Authorize(Roles = "Üye")]
    public class ShoppingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
