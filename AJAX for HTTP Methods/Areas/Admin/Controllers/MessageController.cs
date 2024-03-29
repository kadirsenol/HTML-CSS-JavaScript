using AJAX_for_HTTP_Methods.Layers.Bussines.Abstract;
using AJAX_for_HTTP_Methods.Layers.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AJAX_for_HTTP_Methods.Areas.Admin.Controllers
{
    [Area("Admin")] // Area alanını belirtmen gerekiyor. Yoksa bulamiyor.
    [Authorize(Roles = "Admin")]
    public class MessageController(IMessageManager messageManager) : Controller
    {
        private readonly IMessageManager messageManager = messageManager;


        public async Task<IActionResult> Index()
        {
            ICollection<string> tablename = await messageManager.GetAllTableNamesAsync();
            return View(tablename);
        }

        public async Task<IActionResult> MessageGet()
        {
            ICollection<Message> uruns = await messageManager.GetAll();
            return Ok(uruns);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            int sonuc = await messageManager.DeleteByPK(id);
            return Ok(sonuc);
        }
    }
}
