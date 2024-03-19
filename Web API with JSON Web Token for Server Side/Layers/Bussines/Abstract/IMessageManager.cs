using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Concrete;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Bussines.Abstract
{
    public interface IMessageManager : IManager<Message, int>
    {
        //Mesaj yazan kişinin adı db de yoksa mesaj yazamaz diye bir kural eklenebilir. Ve ilgili exceptionlar gonderilebilir.
    }
}
