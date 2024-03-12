namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Abstract
{
    public class BaseEntity<TId>
    {
        public TId Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
