using Asp.Net_Core_Identity.Layers.Entities.Concrete;

namespace Asp.Net_Core_Identity.Layers.Bussines.Abstract
{
    public interface IMessageManager : IManager<Message, int>
    {
        //Mesaj yazan kişinin adı db de yoksa mesaj yazamaz diye bir kural eklenebilir. Ve ilgili exceptionlar gonderilebilir.
    }
}
