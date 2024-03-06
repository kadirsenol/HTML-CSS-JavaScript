using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.EntityConfig.Abstract
{
    public class BaseEntityConfig<T, TId> : IEntityTypeConfiguration<T> where T : BaseEntity<TId>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(p => p.CreateDate).HasDefaultValueSql("GetDate()");

        }
    }
}
