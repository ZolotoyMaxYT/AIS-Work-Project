using System.Data.Entity;
using System.Data.SQLite;

namespace DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DbSet<MinecraftModRawData> MinecraftMods { get; set; }

        public DataContext() : base(new SQLiteConnection(DBConnection.str), true) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MinecraftModRawData>().ToTable("Records");
            base.OnModelCreating(modelBuilder);
        }
    }
}
