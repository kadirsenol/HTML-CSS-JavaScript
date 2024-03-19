using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Concrete;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.EntityConfig.Abstract;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.EntityConfig.Concrete
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
