using AJAX_for_HTTP_Methods.Layers.Entities.Abstract;
using AJAX_for_HTTP_Methods.Layers.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AJAX_for_HTTP_Methods.Layers.DataAccess.DBContexts
{
    public class SqlDbContext : IdentityDbContext<MyUser> //MyUseri IdentityUser olarak kabul et.
    {
        //public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }
        //public SqlDbContext() { }


        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Konu> Konular { get; set; }
        public DbSet<Message> Mesajlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=AjaxExample;Trusted_Connection=True; Trust Server Certificate=true; MultipleActiveResultSets=True");
        }

        // Soft delete olarak calistigimiz veritabanimizda delete islemi gerceklestiginde changetracker kayıt olan deleted islemlerini
        // savechange metodunu ezerek durumun bir delete degil update oldugunu belirtip update olacak propları tanimliyoruz.
        // artik butun delete islemleri bir update olarak algilanacak ve sadece isdelete ile updatedate fieldleri degisecek. 
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {

            var changes = ChangeTracker.Entries().Where(p => p.State == EntityState.Deleted).ToList();

            foreach (var item in changes)
            {
                if (item.GetType() == typeof(MyUser))
                {
                    MyUser userEntity = item.Entity as MyUser; // IdentityUserimi genislettigim icin QueryFilter duzenlemesini buraya da ayri olarak ekledim.
                    userEntity.IsDelete = true;
                    userEntity.UpdateDate = DateTime.UtcNow.AddHours(3);
                }
                else
                {
                    item.State = EntityState.Modified;
                    BaseEntity<int> baseEntity = item.Entity as BaseEntity<int>;
                    baseEntity.IsDelete = true;
                    baseEntity.UpdateDate = DateTime.UtcNow.AddHours(3);
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
