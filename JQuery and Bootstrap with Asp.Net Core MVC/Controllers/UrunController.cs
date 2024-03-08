using AutoMapper;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Bussines.Abstract;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Controllers
{
    public class UrunController : Controller
    {
        private readonly IUrunManager _urunManager;
        private readonly IMapper _mapper;

        public UrunController(IUrunManager urunManager, IMapper mapper)
        {
            _urunManager = urunManager;
            _mapper = mapper;
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


        public async Task<IActionResult> Update(int id)
        {
            Urun result1 = await _urunManager.GetById(id);
            return View(result1);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Update(Urun urun)
        //{

        //}
    }
}
