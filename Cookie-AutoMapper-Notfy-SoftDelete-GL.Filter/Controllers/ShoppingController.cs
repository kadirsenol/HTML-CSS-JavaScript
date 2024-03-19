using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
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
        private readonly IMapper mapper;
        private readonly INotyfService notyf;

        public ShoppingController(IMessageManager messageManager, IKonuManager konuManager, IMapper mapper, INotyfService notyf)
        {
            this.messageManager = messageManager;
            this.konuManager = konuManager;
            this.mapper = mapper;
            this.notyf = notyf;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Message()
        {
            ICollection<Konu> Konular = await konuManager.GetAll();
            MessageInsertVm vm = new MessageInsertVm();
            vm.Konular = Konular.ToList();
            return View(vm);

        }

        [HttpPost]
        public async Task<IActionResult> Message(MessageInsertVm insertVm)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    #region Db path-aslı localde
                    string fileextension = Path.GetExtension(insertVm.File.FileName);
                    string filename = Guid.NewGuid().ToString() + fileextension;
                    string filepath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/files/{filename}");
                    using var filestream = new FileStream(filepath, FileMode.Create); // Dosyayı almak ve locale yani diske yazmak.
                    await insertVm.File.CopyToAsync(filestream);
                    #endregion

                    #region Db de data olarak tutmak
                    using MemoryStream memoryStream = new MemoryStream(); // Dosyayi almak ve memorye yani db ye yazmak.
                    await insertVm.File.CopyToAsync(memoryStream);
                    #endregion


                    Message message = mapper.Map<Message>(insertVm);
                    message.FilePath = $"/files/{filename}";
                    message.Data = memoryStream.ToArray(); // DB de data olarak tutulacaksa. Ama bu yontem db de sismelere neden oldugundan tercih etmedigim icin bunu, data probunu ve memorystreami uygulamicam.

                    await messageManager.Insert(message);

                    return RedirectToAction("Message"); // Buraya rolü üye mi ve autotatication olmus mu if kontrolünü de ekle.
                }
                catch (Exception ex)
                {
                    notyf.Error("Hata:" + ex.Message);
                }
            }

            return View(insertVm);

        }
    }
}
