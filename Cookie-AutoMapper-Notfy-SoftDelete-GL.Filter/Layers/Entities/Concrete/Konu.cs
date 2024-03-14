using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Abstract;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Concrete
{
    public class Konu : BaseEntity<int>
    {
        public string KonuAdi { get; set; }
        public ICollection<Message> Mesajlar { get; set; }

    }
}