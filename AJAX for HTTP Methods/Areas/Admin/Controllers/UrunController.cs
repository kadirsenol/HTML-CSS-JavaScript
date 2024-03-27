using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AJAX_for_HTTP_Methods.Areas.Admin.Controllers
{
    [Area("Admin")] // Area alanını belirtmen gerekiyor. Yoksa bulamiyor.
    [Authorize(Roles = "Admin")]
    public class UrunController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
