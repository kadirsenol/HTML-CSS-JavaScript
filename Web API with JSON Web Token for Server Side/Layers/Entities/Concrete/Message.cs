using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Abstract;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Concrete
{
    public class Message : BaseEntity<int>
    {
        public string Ad { get; set; }
        public string Email { get; set; }
        public string Mesaj { get; set; }
        public int KonuId { get; set; }
        public Konu? Konu { get; set; }
        public byte[]? Data { get; set; } // Alacagın mesajda ki file i eger db de tutmak istersen bu probu kullanmalisin. Yok eger localde wwwroot icinde bir klasörde tutucaksan buna gerek yok. Tercih etmedigim icin kendi projemde bu probu kaldiracagim.
        public string? FilePath { get; set; }
    }
}
