using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.Concrete;
using JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JQuery_and_Bootstrap_with_Asp.Net_Core_MVC.Layers.Entities.EntityConfig.Concrete
{
    public class KullaniciConfig : BaseEntityConfig<Kullanici, int>
    {
        public override void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.TcNo).HasMaxLength(11);
            builder.Property(p => p.Ad).HasMaxLength(20);
            builder.Property(p => p.City).HasMaxLength(15);
            builder.Property(p => p.Password).HasMaxLength(50);

        }
    }
}
