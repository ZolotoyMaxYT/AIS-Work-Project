using Model;
using static Dapper.SqlMapper;

namespace DataAccessLayer
{
    /// <summary>
    /// Репозиторий через Entity Framework.
    /// </summary>
    public class EntityRepository : IRepository<MinecraftModRawData>
    {
        public EntityRepository()
        {
            DBConnection.CreateTable();
        }

        /// <summary>
        /// Добавляет объект в базу.
        /// </summary>
        public bool Create(MinecraftModRawData entity)
        {
            if (entity == null || IsExist(entity.Id)) return false;
            using (DataContext db = new())
            {
                db.Set<MinecraftModRawData>().Add(entity);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Удаляет объект с указанным ID.
        /// </summary>
        public bool Delete(string id)
        {
            using (DataContext db = new())
            {
                MinecraftModRawData entity = db.Set<MinecraftModRawData>().Find(id);
                if (entity == null) return false;
                db.Set<MinecraftModRawData>().Remove(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool IsExist(string id)
        {
            using (DataContext db = new())
            {
                return db.MinecraftMods.Any(e => e.Id == id);
            }
        }

        /// <summary>
        /// Возвращает все объекты.
        /// </summary>
        public List<MinecraftModRawData> ReadAll()
        {
            using (DataContext db = new())
            {
                return db.Set<MinecraftModRawData>().ToList();
            }
        }

        /// <summary>
        /// Возвращает объект с указанным ID или null.
        /// </summary>
        public MinecraftModRawData? ReadByID(string id)
        {
            using (DataContext db = new())
            {
                return db.Set<MinecraftModRawData>().Find(id);
            }
        }

        /// <summary>
        /// Сохраняет изменения объекта.
        /// </summary>
        public bool Update(MinecraftModRawData entity)
        {
            if (entity == null) return false;
            using (DataContext db = new())
            {
                MinecraftModRawData e = db.Set<MinecraftModRawData>().Find(entity.Id);
                if (e == null) return false;
                db.Entry(e).CurrentValues.SetValues(entity);
                db.SaveChanges();
                return true;
            }
        }
    }
}
