using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.DataAccess.Abstract;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.Concrete;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Bussines.Abstract
{
    public interface IUrunManager : IRepository<Urun, int>
    {
    }
}
