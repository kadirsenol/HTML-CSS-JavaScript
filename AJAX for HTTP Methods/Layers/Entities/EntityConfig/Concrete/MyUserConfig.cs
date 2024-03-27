using AJAX_for_HTTP_Methods.Layers.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJAX_for_HTTP_Methods.Layers.Entities.EntityConfig.Concrete
{
    public class MyUserConfig : IEntityTypeConfiguration<MyUser>
    {
        public void Configure(EntityTypeBuilder<MyUser> builder)
        {
            /* User icin temel proplari ayri tanimlamak zorunda kaldim. Cunku Useri hem baseden hemde IdentityUser den inherit alamayacagim icin BaseEntity problarini User entityme ekledim. */

            builder.Property(p => p.TcNo).HasMaxLength(11);
            builder.Property(p => p.CreateDate).HasDefaultValueSql("GetDate()");
            builder.Property(p => p.UpdateDate).HasDefaultValueSql("GetDate()");
            builder.Property(p => p.IsDelete).HasDefaultValue(false);
            builder.HasQueryFilter(p => p.IsDelete == false); // Global Query Filter. Sorgularda IsDalete fieldenin false olanlarini dikkate al. True olanlara yokmus gibi davran.
        }
    }
}
