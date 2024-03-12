using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Abstract;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Concrete
{
    public class User : BaseEntity<int>
    {
        public string Ad { get; set; }
        public string Email { get; set; }
        public int TcNo { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
    }
}
