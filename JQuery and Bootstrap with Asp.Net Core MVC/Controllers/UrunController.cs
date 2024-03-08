using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Bussines.Abstract;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.Concrete;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Models.UrunVM;
using Microsoft.AspNetCore.Mvc;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Controllers
{
    public class UrunController : Controller
    {
        private readonly IUrunManager _urunManager;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;
        public UrunController(IUrunManager urunManager, IMapper mapper, INotyfService notyf)
        {
            _urunManager = urunManager;
            _mapper = mapper;
            _notyf = notyf;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Urun> urunler = await _urunManager.Get();
            return View(urunler);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            _urunManager.DeleteById(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id)
        {
            Urun result = await _urunManager.GetById(id);
            UrunInsertVM result1 = _mapper.Map<UrunInsertVM>(result);
            return View(result1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePost(UrunInsertVM result)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Urun urun = _mapper.Map<Urun>(result);

                    await _urunManager.Update(urun);
                    TempData["Güncelleme Başarılı"] = "Ürün Güncellenmesi Tamamlandı..";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    _notyf.Error("Hata!: " + ex.Message);
                    return RedirectToAction("Index"); // Tekrar updateye gonderebilmem icin post istegi gondermem gerekiyor.
                }
            }
            else
            {
                ModelState.AddModelError("", "Tarayıcınızın JavaScript kullanımı kapalı olabilir, lütfen kontrol edin.");
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Create()
        {
            UrunInsertVM urunvm = new UrunInsertVM();
            return View(urunvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UrunInsertVM ınsertVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Urun urun = _mapper.Map<Urun>(ınsertVM);
                    await _urunManager.Insert(urun);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    _notyf.Error("Hata: " + ex.Message);
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Tarayıcınızın JavaScript kullanımı engellenmiş olabilir, lütfen kontrol edin.");
                return View();
            }
        }

    }
}
