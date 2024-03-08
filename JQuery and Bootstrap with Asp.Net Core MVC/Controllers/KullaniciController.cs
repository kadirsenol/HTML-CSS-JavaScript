using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Bussines.Abstract;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.Concrete;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Models.KullaniciVM;
using Microsoft.AspNetCore.Mvc;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly IKullaniciManager _kullanicimanager;
        private readonly INotyfService _notyf;
        private readonly IMapper _mapper;

        public KullaniciController(IKullaniciManager kullaniciManager, INotyfService notyf, IMapper mapper)
        {
            _kullanicimanager = kullaniciManager;
            _notyf = notyf;
            _mapper = mapper;
        }

        public async Task<IActionResult> UserCreate()
        {
            KullaniciCreateVM kullanici = new();
            return View(kullanici);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Token siresi oluşturarak, ilgili formun yabanci tarafindan gonderilip gonderilmedigini kontrol ediyor.
                                   // Formun baska bir kaynak tarafinda gonderilmesi halinde dolandiriciliga karsi alinmis bir onlem.
        public async Task<IActionResult> UserCreate(KullaniciCreateVM kullaniciVm)
        {
            if (ModelState.IsValid) // Validation, ilgili VM'in uygun olup olmamadigini daha ilgili actiona gitmeden kontrol ediyor ve
                                    // uygun olmamasi halinde client tarafina iligli hatayi gonderiyor ve ilgili actiona gitmesini durduruyor
                                    // Fakat tarayicinin JS kullanimi kapatildiginda, VM' in uygun olmamasi halinde hatalari client tarafina
                                    // gondermesiyle birlikte ilgili actiona gitmesini durduramiyor ve haliyle client tarafinda kontrolü ezerek
                                    // server tarafina ulasmis oluyor. Bu sadece ekranda client hatasi gorunse bile verinin bissunes filtresine 
                                    // bissunes filtresine ulasmasi gibi mantiksiz bir olaya yol aciyor. Burada ki if sarti ise bu mantiksizligin
                                    // onune gecmek icin yani; VM uygun olmamasi halinde JS kapali olsa bile bissunes filtresine ulastirmamayi saglar.
            {
                try
                {
                    Kullanici kullanici = new Kullanici()
                    {
                        Ad = kullaniciVm.Ad,
                        City = kullaniciVm.City,
                        Password = kullaniciVm.Password,
                        TcNo = kullaniciVm.TcNo
                    };
                    //_mapper.Map<Kullanici>(kullaniciVm); // Mapper kullanimi

                    await _kullanicimanager.Insert(kullanici);
                    TempData["Basarili Kayit"] = "Kullanıcı Başarıyla Oluşturuldu.";
                    return RedirectToAction("UserCreate");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    _notyf.Error("Hata ! = " + ex.Message);
                    return View(kullaniciVm);
                }
            }
            else
            {
                return View(kullaniciVm);
            }
        }

        public async Task<IActionResult> UserLogin()
        {
            KullaniciLoginVM kullaniciVM = new();
            return View(kullaniciVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserLogin(KullaniciLoginVM kullaniciLoginVm)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    bool sonuc = await _kullanicimanager.Any(p => p.TcNo == kullaniciLoginVm.TcNo);
                    bool sonuc1 = await _kullanicimanager.Any(p => p.Password == kullaniciLoginVm.Password);

                    if (sonuc1 && sonuc)
                    {
                        return RedirectToAction("Profil");
                    }
                    else
                    {
                        TempData["Basarili Giris"] = "Kullanıcı Girişi Başarılı...";
                        return RedirectToAction("UserLogin");
                    }

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", ex.Message);
                    #region Notyf
                    _notyf.Error("Hata! = " + ex.Message);
                    #endregion
                    return View(kullaniciLoginVm);
                }
            }
            else
            {
                return View(kullaniciLoginVm);
            }
        }



        public async Task<IActionResult> Profil()
        {
            return View();
        }

    }
}
