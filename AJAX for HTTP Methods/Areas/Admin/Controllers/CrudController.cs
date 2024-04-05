using AJAX_for_HTTP_Methods.Layers.Bussines.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AJAX_for_HTTP_Methods.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CrudController(IUrunManager urunManager) : Controller
    {
        private readonly IUrunManager urunManager = urunManager;

        public async Task<IActionResult> Index()
        {
            ICollection<string> tablenames = await urunManager.GetAllTableNamesAsync();
            return View(tablenames);
        }
    }
}
