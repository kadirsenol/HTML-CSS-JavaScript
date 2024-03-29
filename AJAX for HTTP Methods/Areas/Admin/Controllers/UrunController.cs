using AJAX_for_HTTP_Methods.Layers.Bussines.Abstract;
using AJAX_for_HTTP_Methods.Layers.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AJAX_for_HTTP_Methods.Areas.Admin.Controllers
{
    [Area("Admin")] // Area alanını belirtmen gerekiyor. Yoksa bulamiyor.
    [Authorize(Roles = "Admin")]
    public class UrunController(IUrunManager urunManager) : Controller
    {
        private readonly IUrunManager urunManager = urunManager;


        public async Task<IActionResult> Index()
        {
            ICollection<string> tablename = await urunManager.GetAllTableNamesAsync();
            return View(tablename);
        }

        public async Task<IActionResult> UrunGet()
        {
            ICollection<Urun> uruns = await urunManager.GetAll();
            return Ok(uruns);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            int sonuc = await urunManager.DeleteByPK(id);
            return Ok(sonuc);
        }
    }
}
