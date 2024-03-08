using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Bussines.Abstract;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.DataAccess.Concrete;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.DataAccess.DBContexts;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.Concrete;
using System.Linq.Expressions;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Bussines.Concrete
{
    public class UrunManager : Repository<Urun, int, SqlDbContext>, IUrunManager
    {

        public override async Task<int> Update(Urun entity)
        {
            if (await ChackProp(p => p.UrunAdi == entity.UrunAdi && p.Id != entity.Id))
            {
                throw new Exception($"{entity.UrunAdi} isimli ürün zaten mevcut.!");
            }
            return await base.Update(entity);
        }

        public override async Task<int> Insert(Urun entity)
        {
            if (await ChackProp(p => p.UrunAdi == entity.UrunAdi))
            {
                throw new Exception($"Eklemek istediğiniz {entity.UrunAdi} ürünü zaten mevcut..");
            }
            return await base.Insert(entity);
        }

        public async Task<bool> ChackProp(Expression<Func<Urun, bool>> expression)
        {
            return await base.Any(expression);
        }


    }
}
