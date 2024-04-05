using AJAX_for_HTTP_Methods.Layers.Bussines.Abstract;
using AJAX_for_HTTP_Methods.Layers.Entities.Concrete;
using AJAX_for_HTTP_Methods.Models.VMs.Message;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AJAX_for_HTTP_Methods.Areas.Admin.Controllers
{
    [Area("Admin")] // Area alanını belirtmen gerekiyor. Yoksa bulamiyor.
    [Authorize(Roles = "Admin")]
    public class MessageController(IMessageManager messageManager, IMapper mapper) : Controller
    {
        private readonly IMessageManager messageManager = messageManager;
        private readonly IMapper mapper = mapper;

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

        [HttpPost]
        public async Task<IActionResult> Create(MessageCreateVm messageCreateVm)
        {
            if (ModelState.IsValid)
            {
                Message message = mapper.Map<Message>(messageCreateVm);
                return Ok(await messageManager.Insert(message));
            }
            var errorMessage = ModelState.Values.SelectMany(p => p.Errors.Select(e => e.ErrorMessage));
            return BadRequest(errorMessage);
        }

        public async Task<IActionResult> GetPropNamesAndTypes()
        {
            ICollection<string> propname = await messageManager.GelAllTablePropsNamesAndTypes();
            return Ok(propname);
        }

        [HttpPut]
        public async Task<IActionResult> Update(MessageUpdateVm messageUpdateVm)
        {
            if (ModelState.IsValid)
            {
                Message message = mapper.Map<Message>(messageUpdateVm);
                return Ok(await messageManager.update(message));
            }
            var errorMessage = ModelState.Values.SelectMany(p => p.Errors.Select(e => e.ErrorMessage));
            return BadRequest(errorMessage);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string ad)
        {
            if (string.IsNullOrEmpty(ad))
            {
                ICollection<Message> messages = await messageManager.GetAll();
                return Ok(messages);
            }
            else
            {
                var result = messageManager._repo.dbContext.Mesajlar.Where(p => p.Ad.Contains(ad)).ToList();
                return Ok(result);
            }

        }
    }
}
