using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net_Core_Identity.Controllers
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
