using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Abstract;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Concrete;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.Layers.DataAccess.DBContexts
{
    public class SqlDbContext : DbContext
    {

        #region DBCONTEXT I CONSTR SIZ SERVISLERE EKLEYEBILDIGIN ICIN BURAYI KULLANMA SIL. EGER DBCONTEXT I BIR YERDE BAGIMLI YAPARSAN, BURAYI SILIP SERVISLERE DBCONTEXT I CONSTRSIZ EKLE.
        //public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { } // Bu ctro, eger constr yi secret.json dosyasina eklemek istersen ilgili dbcontext sinifinin constr sinin program.cs de tanimlandigini bildirmek icin base gonderiyoruz. Eger bunu kullaniyorsan assagida ki OnConfiguring metodunu ovverride etmene gerek yok. 
        //public SqlDbContext() { }                                                       // Proje icerisinde DbContextin eger parametresiz olarakta instancesi alinmasini istersen birde ek olarak bunu eklemelisin ve bu sefer OnConfigurin metodunu burada override etmelisin. Mesela benim tasarladigim repository imde DbContexti generic yapmak adina parametresiz instancesini aldigim icin burada onconfiguringi override etmek zorundayim. Bu sefer eger servislere dbcontext eklemek gerekirse basede constr belirtmeden dbcontext servislere eklenebilir cunku constr burada override edilip bildirilmis.
        #endregion


        public DbSet<Urun> Urunler { get; set; }
        public DbSet<User> Kullanıcılar { get; set; }
        public DbSet<Konu> Konular { get; set; }
        public DbSet<Message> Mesajlar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=ApiExample;Trusted_Connection=True; Trust Server Certificate=true; MultipleActiveResultSets=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }



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
