using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.DataAccess.Abstract;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.Concrete;
using System.Linq.Expressions;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Bussines.Abstract
{
    public interface IUrunManager : IRepository<Urun, int>
    {
        public Task<bool> ChackProp(Expression<Func<Urun, bool>> expression);

    }
}
