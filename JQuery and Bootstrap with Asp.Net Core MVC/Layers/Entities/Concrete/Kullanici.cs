using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.Abstract;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.Concrete
{
    public class Kullanici : BaseEntity<int>
    {
        public string Ad { get; set; }
        public int TcNo { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
    }
}
