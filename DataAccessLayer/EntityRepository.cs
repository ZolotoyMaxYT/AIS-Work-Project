using Model;
using static Dapper.SqlMapper;

namespace DataAccessLayer
{
    /// <summary>
    /// Репозиторий через Entity Framework.
    /// </summary>
    public class EntityRepository : IRepository<MinecraftMod>
    {
        public EntityRepository()
        {
            DBConnection.CreateTable();
        }

        /// <summary>
        /// Добавляет новую запись в базу с уникальным ID.
        /// <param name="entity">данные для записи</param>
        /// <returns>true - если успешно, иначе - false</returns>
        /// </summary>
        public bool Create(MinecraftMod entity)
        {
            if (entity == null || IsExist(entity.Id)) return false;
            using (DataContext db = new())
            {
                db.Set<MinecraftMod>().Add(entity);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Удаляет запись с указанным ID.
        /// <param name="id">ID записи</param>
        /// <returns>true - если успешно, иначе - false</returns>
        /// </summary>
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

        /// <summary>
        /// Проверить, существует ли запись с указанным ID.
        /// </summary>
        /// <param name="id">ID записи</param>
        /// <returns>true - если существует, иначе - false</returns>
        public bool IsExist(string id)
        {
            using (DataContext db = new())
            {
                return db.Set<MinecraftMod>().Any(e => e.Id == id);
            }
        }

        /// <summary>
        /// Возвращает все записи.
        /// <returns>Список всех записей</returns>
        /// </summary>
        public MinecraftMod[] ReadAll()
        {
            using (DataContext db = new())
            {
                return db.Set<MinecraftMod>().ToArray();
            }
        }

        /// <summary>
        /// Возвращает запись с указанным ID или null.
        /// <param name="id">ID записи</param>
        /// <returns>Найденная запись или null</returns>
        /// </summary>
        public MinecraftMod? ReadByID(string id)
        {
            using (DataContext db = new())
            {
                return db.Set<MinecraftMod>().Find(id);
            }
        }

        /// <summary>
        /// Сохраняет изменения записи.
        /// <param name="entity">данные для записи</param>
        /// <returns>true - если успешно, иначе - false</returns>
        /// </summary>
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
