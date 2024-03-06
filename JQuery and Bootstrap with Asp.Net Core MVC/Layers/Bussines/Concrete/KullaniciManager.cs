using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Bussines.Abstract;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.DataAccess.Concrete;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.DataAccess.DBContexts;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.Concrete;
using System.Linq.Expressions;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Bussines.Concrete
{
    public class KullaniciManager : Repository<Kullanici, int, SqlDbContext>, IKullaniciManager
    {
        public override async Task<int> Insert(Kullanici entity)
        {
            if (await (ChackProp(p => p.TcNo == entity.TcNo)))
            {
                throw new Exception($"{entity.TcNo} TC Numaralı Kullanıcı Mevcut");
            }
            return await base.Insert(entity);
        }

        public async override Task<bool> Any(Expression<Func<Kullanici, bool>> expression)
        {
            if (!await ChackProp(expression))
            {
                throw new Exception("Tc No veya Paralo Hatalı!");
            }

            return true;
        }

        public async Task<bool> ChackProp(Expression<Func<Kullanici, bool>> expression)
        {
            return await base.Any(expression);
        }
    }
}
