namespace Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Abstract
{
    public class BaseEntity<TId>
    {
        public TId Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow.AddHours(3); // Sqlden baska bir db ye geciste config islemine gerek kalmamasini saglar.
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow.AddHours(3);
        public bool IsDelete { get; set; } = false;
    }
}
