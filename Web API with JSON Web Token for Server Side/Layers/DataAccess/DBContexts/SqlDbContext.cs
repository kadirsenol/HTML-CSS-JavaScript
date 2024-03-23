using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Abstract;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Concrete;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.Layers.DataAccess.DBContexts
{
    public class SqlDbContext : DbContext
    {

        #region DBCONTEXT I CONSTR SIZ SERVISLERE EKLEYEBILDIGIN ICIN BURAYI KULLANMA SIL. EGER DBCONTEXT I BIR YERDE BAGIMLI YAPARSAN, BURAYI SILIP SERVISLERE DBCONTEXT I CONSTRSIZ EKLE.
        //public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { } //Bu constucter MVC projesinde DbContext i servise ekleyebilmek için gerekli oluyor.
        //public SqlDbContext() { }                                                       //Bununla birlikte birde parametresiz ctor da eklenmeli. Eger dbcontex e ihtiyac yok ise ctorlara gerek yok 
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
