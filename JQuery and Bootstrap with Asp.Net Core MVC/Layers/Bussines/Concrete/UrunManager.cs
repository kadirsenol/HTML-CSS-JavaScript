using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Bussines.Abstract;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.DataAccess.Concrete;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.DataAccess.DBContexts;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.Concrete;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Bussines.Concrete
{
    public class UrunManager : Repository<Urun, int, SqlDbContext>, IUrunManager
    {
    }
}
