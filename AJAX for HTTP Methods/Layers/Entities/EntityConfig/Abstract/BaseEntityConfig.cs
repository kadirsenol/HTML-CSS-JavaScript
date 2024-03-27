using AJAX_for_HTTP_Methods.Layers.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AJAX_for_HTTP_Methods.Layers.Entities.EntityConfig.Abstract
{
    public class BaseEntityConfig<T, TId> : IEntityTypeConfiguration<T> where T : BaseEntity<TId>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(p => p.CreateDate).HasDefaultValueSql("GetDate()");
            builder.Property(p => p.UpdateDate).HasDefaultValueSql("GetDate()");
            builder.Property(p => p.IsDelete).HasDefaultValue(false);
            builder.HasQueryFilter(p => p.IsDelete == false); // Global Query Filter. Sorgularda IsDalete fieldenin false olanlarini dikkate al. True olanlara yokmus gibi davran.          
        }

    }
}
