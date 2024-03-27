using AJAX_for_HTTP_Methods.Layers.Entities.Concrete;

namespace AJAX_for_HTTP_Methods.Layers.Bussines.Abstract
{
    public interface IMessageManager : IManager<Message, int>
    {
        //Mesaj yazan kişinin adı db de yoksa mesaj yazamaz diye bir kural eklenebilir. Ve ilgili exceptionlar gonderilebilir.
    }
}
