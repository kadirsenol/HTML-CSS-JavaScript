using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Concrete;
using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.EntityConfig.Concrete
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
