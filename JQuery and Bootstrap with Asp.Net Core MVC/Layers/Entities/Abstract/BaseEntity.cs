namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.Abstract
{
    public class BaseEntity<TId>
    {
        public TId Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
