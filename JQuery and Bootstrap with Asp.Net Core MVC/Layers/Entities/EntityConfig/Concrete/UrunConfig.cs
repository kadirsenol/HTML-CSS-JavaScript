using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.Concrete;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.EntityConfig.Concrete
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
