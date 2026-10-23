using Model;
using static Dapper.SqlMapper;

namespace DataAccessLayer
{
    /// <summary>
    /// Repository from Entity Framework.
    /// </summary>
    public class EntityRepository : IRepository<MinecraftMod>
    {
        public EntityRepository()
        {
            DBConnection.CreateTable();
        }

        public bool Create(MinecraftMod entity)
        {
            if (entity == null || IsExist(entity.Id)) return false;
            using (DataContext db = new())
            {
                db.Set<MinecraftMod>().Add(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(string id)
        {
            using (DataContext db = new())
            {
                MinecraftMod entity = db.Set<MinecraftMod>().Find(id);
                if (entity == null) return false;
                db.Set<MinecraftMod>().Remove(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool IsExist(string id)
        {
            using (DataContext db = new())
            {
                return db.Set<MinecraftMod>().Any(e => e.Id == id);
            }
        }

        public MinecraftMod[] ReadAll()
        {
            using (DataContext db = new())
            {
                return db.Set<MinecraftMod>().ToArray();
            }
        }

        public MinecraftMod? ReadByID(string id)
        {
            using (DataContext db = new())
            {
                return db.Set<MinecraftMod>().Find(id);
            }
        }

        public bool Update(MinecraftMod entity)
        {
            if (entity == null) return false;
            using (DataContext db = new())
            {
                MinecraftMod e = db.Set<MinecraftMod>().Find(entity.Id);
                if (e == null) return false;
                db.Entry(e).CurrentValues.SetValues(entity);
                db.SaveChanges();
                return true;
            }
        }
    }
}
