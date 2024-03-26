using Asp.Net_Core_Identity.Layers.Entities.Concrete;
using Asp.Net_Core_Identity.Layers.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asp.Net_Core_Identity.Layers.Entities.EntityConfig.Concrete
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
