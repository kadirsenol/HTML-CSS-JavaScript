using AJAX_for_HTTP_Methods.Layers.Entities.Concrete;
using AJAX_for_HTTP_Methods.Layers.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJAX_for_HTTP_Methods.Layers.Entities.EntityConfig.Concrete
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
