using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Concrete;
using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.EntityConfig.Concrete
{
    public class KonuConfig : BaseEntityConfig<Konu, int>
    {
        public override void Configure(EntityTypeBuilder<Konu> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.KonuAdi).HasMaxLength(20);
        }
    }
}
