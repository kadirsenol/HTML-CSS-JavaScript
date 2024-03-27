using AJAX_for_HTTP_Methods.Layers.Entities.Abstract;

namespace AJAX_for_HTTP_Methods.Layers.Entities.Concrete
{
    public class Konu : BaseEntity<int>
    {
        public string KonuAdi { get; set; }
        public ICollection<Message> Mesajlar { get; set; }

    }
}