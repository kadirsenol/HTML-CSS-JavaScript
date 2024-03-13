using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Controllers
{
    [Authorize(Policy = "TCNO")] // Burada servislere ekledigimiz TCNO adında ki bir politikayı ekliyoruz. Politikada ki TcNo su 123 olanlar sartina binaen controlöre sadece TcNo su 123 olanlar erisebilir.
    [Authorize(Roles = "Üye")] //Bu kontrolöre sadece rolü üye olanlar erişebilir.
    public class ShoppingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
