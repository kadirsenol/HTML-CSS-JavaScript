using Asp.Net_Core_Identity.Layers.Entities.Abstract;

namespace Asp.Net_Core_Identity.Layers.Entities.Concrete
{
    public class Konu : BaseEntity<int>
    {
        public string KonuAdi { get; set; }
        public ICollection<Message> Mesajlar { get; set; }

    }
}