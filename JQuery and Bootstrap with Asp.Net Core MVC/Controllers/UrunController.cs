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
    }
}
