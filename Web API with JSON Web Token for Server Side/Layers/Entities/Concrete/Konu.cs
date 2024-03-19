using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Abstract;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Concrete
{
    public class Konu : BaseEntity<int>
    {
        public string KonuAdi { get; set; }
        public ICollection<Message> Mesajlar { get; set; }

    }
}