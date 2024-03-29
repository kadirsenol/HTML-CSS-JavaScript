using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AJAX_for_HTTP_Methods.Areas.Admin.Controllers
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
