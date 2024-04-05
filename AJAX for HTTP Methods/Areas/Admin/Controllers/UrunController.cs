using AJAX_for_HTTP_Methods.Layers.Bussines.Abstract;
using AJAX_for_HTTP_Methods.Layers.Entities.Concrete;
using AJAX_for_HTTP_Methods.Models.VMs.Urun;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AJAX_for_HTTP_Methods.Areas.Admin.Controllers
{
    [Area("Admin")] // Area alanını belirtmen gerekiyor. Yoksa bulamiyor.
    [Authorize(Roles = "Admin")]
    public class UrunController(IUrunManager urunManager, IMapper mapper) : Controller
    {
        private readonly IUrunManager urunManager = urunManager;
        private readonly IMapper mapper = mapper;

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

        public async Task<IActionResult> GetPropNamesAndTypes()
        {
            ICollection<string> propname = await urunManager.GelAllTablePropsNamesAndTypes();
            return Ok(propname);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UrunCreateVm urunCreateVm)
        {
            if (ModelState.IsValid)
            {
                Urun urun = mapper.Map<Urun>(urunCreateVm);
                return Ok(await urunManager.Insert(urun));
            }
            var errorMessage = ModelState.Values.SelectMany(p => p.Errors.Select(e => e.ErrorMessage));
            return BadRequest(errorMessage);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UrunUpdateVm urunUpdateVm)
        {
            if (ModelState.IsValid)
            {
                Urun urun = mapper.Map<Urun>(urunUpdateVm);

                await urunManager.update(urun);

                return Ok();
            }
            var errorMessage = ModelState.Values.SelectMany(p => p.Errors.Select(e => e.ErrorMessage));
            return BadRequest(errorMessage);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string urunadi)
        {
            if (string.IsNullOrEmpty(urunadi))
            {
                ICollection<Urun> uruns = await urunManager.GetAll();
                return Ok(uruns);
            }
            else
            {
                var result = urunManager._repo.dbContext.Urunler.Where(p => p.UrunAdi.Contains(urunadi)).ToList();
                return Ok(result);
            }


        }
    }
}
