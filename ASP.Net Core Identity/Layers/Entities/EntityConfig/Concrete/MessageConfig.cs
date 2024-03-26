using Asp.Net_Core_Identity.Layers.Entities.Concrete;
using Asp.Net_Core_Identity.Layers.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asp.Net_Core_Identity.Layers.Entities.EntityConfig.Concrete
{
    public class MessageConfig : BaseEntityConfig<Message, int>
    {
        public override void Configure(EntityTypeBuilder<Message> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Mesaj).HasMaxLength(500);
            builder.Property(p => p.Ad).HasMaxLength(50);
            builder.Property(p => p.Email).HasMaxLength(50);
            //dosya icin maks byte kurali var mı arastir.

        }
    }
}
