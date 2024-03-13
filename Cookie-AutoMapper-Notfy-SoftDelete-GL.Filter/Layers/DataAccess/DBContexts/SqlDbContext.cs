using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Abstract;
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

        // Bu constucter'i Mvc Projesinde Servis'e register ederken kullanacagiz
        //public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }


        // Soft delete olarak calistigimiz veritabanimizda delete islemi gerceklestiginde changetracker kayıt olan deleted islemlerini
        // savechange metodunu ezerek durumun bir delete degil update oldugunu belirtip update olacak propları tanimliyoruz.
        // artik butun delete islemleri bir update olarak algilanacak ve sadece isdelete ile updatedate fieldleri degisecek. 
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {

            var changes = ChangeTracker.Entries().Where(p => p.State == EntityState.Deleted).ToList();

            foreach (var item in changes)
            {
                item.State = EntityState.Modified;
                BaseEntity<int> baseEntity = item.Entity as BaseEntity<int>;
                baseEntity.IsDelete = true;
                baseEntity.UpdateDate = DateTime.UtcNow.AddHours(3);
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
