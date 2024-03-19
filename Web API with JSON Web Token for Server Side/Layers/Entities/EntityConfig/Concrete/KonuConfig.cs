using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Concrete;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.EntityConfig.Abstract;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.EntityConfig.Concrete
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
