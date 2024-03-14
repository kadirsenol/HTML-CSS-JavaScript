using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Concrete;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Bussines.Abstract
{
    public interface IMessageManager : IManager<Message, int>
    {
        //Mesaj yazan kişinin adı db de yoksa mesaj yazamaz diye bir kural eklenebilir.
    }
}
