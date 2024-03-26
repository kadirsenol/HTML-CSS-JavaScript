using Asp.Net_Core_Identity.Layers.Bussines.Abstract;
using Asp.Net_Core_Identity.Layers.Entities.Concrete;

namespace Asp.Net_Core_Identity.Layers.Bussines.Concrete
{
    public class MessageManager : Manager<Message, int>, IMessageManager
    {

    }
}
