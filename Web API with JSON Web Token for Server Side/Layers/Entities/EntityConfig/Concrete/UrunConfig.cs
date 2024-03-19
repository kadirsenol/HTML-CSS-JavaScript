using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Concrete;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.EntityConfig.Abstract;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.EntityConfig.Concrete
{
    public class UrunConfig : BaseEntityConfig<Urun, int>
    {
        public override void Configure(EntityTypeBuilder<Urun> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.UrunAdi).HasMaxLength(50);
            builder.Property(p => p.UrunFiyati).HasMaxLength(10);
            builder.Property(p => p.KategoriAdi).HasMaxLength(50);
            builder.Property(p => p.StokAdet).HasMaxLength(7);
        }
    }
}
