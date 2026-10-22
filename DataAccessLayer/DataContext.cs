using System.Data.Entity;
using System.Data.SQLite;
using Model;

namespace DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DbSet<MinecraftMod> MinecraftMods { get; set; }

        public DataContext() : base(new SQLiteConnection(DBConnection.str), true) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MinecraftMod>().ToTable("Records");
            base.OnModelCreating(modelBuilder);
        }
    }
}
