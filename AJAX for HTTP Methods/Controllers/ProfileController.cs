using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AJAX_for_HTTP_Methods.Controllers
{
    [Authorize(Policy = "TCNO")]
    [Authorize(Roles = "Üye")]
    public class ProfileController : Controller
    {

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
