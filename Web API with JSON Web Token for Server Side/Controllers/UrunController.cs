using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Bussines.Abstract;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Concrete;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.Controllers
{
    //Note==> Metotlar icerisinde ki kurallar bussines layer de tanimlanacak ve burasida try catch icerisinde olusturulacak !.

    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController(IUrunManager urunmanager) : ControllerBase
    {
        private readonly IUrunManager urunManager = urunmanager;


        [HttpGet("[action]")] //Action belirtirsen actionsuz ulasamazsin, action belirtmezsen action yazarsan ulasamazsin.
        public async Task<IActionResult> GetAll() // Geri donusu IActionResult ta gondersen model olarakda gondersen jsonlayip gonderiyor. Client tarafindan readstringasyc metodu ile contenti jsonstring olarak okuyup ardindan bunu istedigin modele deserialize edebilirsin.
        {
            ICollection<Urun> uruns = await urunManager.GetAll();

            if (uruns.Count > 0)
            {
                return Ok(uruns.ToList());
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("[action]/{id}")] // Burada ki id route yi / seklini kazandiriyor
        public async Task<IActionResult> GetById(int id) // Burada ki parametre router de ?id=1 seklinde davraniyor.
        {
            Urun urun = await urunManager.GetByPK(id);

            if (urun != null)
            {
                return Ok(urun);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost] // Bir adet post oldugundan action belirtmemize gerek yok
        public async Task<IActionResult> Insert(Urun urun)
        {
            try
            {
                int efected = await urunManager.Insert(urun);
                if (efected > 0)
                {
                    return Created("", urun); //Status code 201, olusturulan nesnenin urisine giderek ozelliklerini okuyup geri donduruyor
                    //return CreatedAtAction("GetById", new { id = urun.Id }, urun); // İstenilen nesnenin olusturulup farkli bir actiona yonlendirilmesi
                }
                else
                {
                    return Problem("Bir problem meydana geldi..");
                }
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message}"); // Bussines layer de is kurali belirtilmesi akabinde kullanilir.
            }
        }

        [HttpPut] // Bir tane put islemi oldugundan action belirtmedim. Id degeri degistirilemeyecegi icin route de id belirtilmesine gerek yok.
        public async Task<IActionResult> Update(Urun urun)
        {
            var chack = await urunManager.Any(p => p.Id == urun.Id);

            if (chack)
            {
                urunManager._repo.dbContext.Entry(urun).State = EntityState.Modified;
                await urunManager._repo.dbContext.SaveChangesAsync();

                return Ok(urun);
            }
            else
            {
                return Problem($"{urun.Id} id numaralı kayıt bulunmamaktadır. Lütfen güncellemek istediğiniz kayıtın id numarasını kontrol ediniz.");
            }

        }

        [HttpDelete("{id}")] // Bir tane delete islemi oldugu icin action belirtmedim.
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Urun chack = await urunManager.GetByPK(id);
                if (chack != null)
                {
                    await urunManager.DeleteByPK(id);
                    return Ok();
                }
                else
                {
                    return Problem($"{id} numaralı kayıt mevcut değil. !");
                }
            }
            catch (DbUpdateException ex) // İliskili kayitlarin silinmesi esnasinda verilen exception
            {

                return Problem($"Silmeyi arzuladığınız kayıtın diğer kayıtlar ile ilişkisi bulunduğundan talebiniz reddedildi. + {ex.Message}");
            }

        }
    }
}
