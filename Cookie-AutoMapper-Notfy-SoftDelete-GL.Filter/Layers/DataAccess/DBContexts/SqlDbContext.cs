using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.DataAccess.DBContexts
{
    public class SqlDbContext : DbContext
    {

        public DbSet<Urun> Urunler { get; set; }
        public DbSet<User> Kullanıcılar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=CookieExample;Trusted_Connection=True; Trust Server Certificate=true; MultipleActiveResultSets=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
