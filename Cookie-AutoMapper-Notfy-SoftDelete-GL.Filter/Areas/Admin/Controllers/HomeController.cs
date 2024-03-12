using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Areas.Admin.Controllers
{
    [Area("Admin")] // İki adet homecontrolleri birbirinden ayırmak icin
    [Authorize(Roles = "Admin")] // Buraya giris yapilmadan ve giris yapilanlardan ise sadece admin olanlar girebilir.
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
