using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Abstract;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Concrete
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
