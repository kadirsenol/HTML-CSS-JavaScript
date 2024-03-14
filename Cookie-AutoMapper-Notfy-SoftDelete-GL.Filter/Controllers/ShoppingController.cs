using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Bussines.Abstract;
using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Concrete;
using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Models.VMs.MessageVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Controllers
{
    [Authorize(Policy = "TCNO")] // Burada servislere ekledigimiz TCNO adında ki bir politikayı ekliyoruz. Politikada ki TcNo su 123 olanlar sartina binaen controlöre sadece TcNo su 123 olanlar erisebilir.
    [Authorize(Roles = "Üye")] //Bu kontrolöre sadece rolü üye olanlar erişebilir.
    public class ShoppingController : Controller
    {
        private readonly IMessageManager messageManager;
        private readonly IKonuManager konuManager;

        public ShoppingController(IMessageManager messageManager, IKonuManager konuManager)
        {
            this.messageManager = messageManager;
            this.konuManager = konuManager;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Message()
        {
            ICollection<Konu> Konular = await konuManager.GetAll();
            MessageInsertVm vm = new MessageInsertVm();
            vm.Konular = Konular;
            return View(vm);

        }
    }
}
