using Model;
using Dapper;
using System.Data;
using System.Data.SQLite;

namespace DataAccessLayer
{
    /// <summary>
    /// Репозиторий записей через Dapper
    /// </summary>
    public class DapperRepository : IRepository<MinecraftMod>
    {
        public DapperRepository()
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

            using (SQLiteConnection con = new SQLiteConnection(DBConnection.str))
            {
                con.Execute($@"
                    INSERT INTO Records (Id, Name, Description, Author, {GetVersion("Version")}, {GetVersion("MinecraftVersionFirst")}, {GetVersion("MinecraftVersionLast")}, IsJavaMod, Rank, Tags, Status)
                    VALUES (@Id, @Name, @Description, @Author, {GetVersion("@Version")}, {GetVersion("@MinecraftVersionFirst")}, {GetVersion("@MinecraftVersionLast")}, @IsJavaMod, @Rank, @Tags, @Status)", entity);
                }
            return true;
        }

        /// <summary>
        /// Удаляет запись с указанным ID.
        /// <param name="id">ID записи</param>
        /// <returns>true - если успешно, иначе - false</returns>
        /// </summary>
        public bool Delete(string id)
        {
            using (SQLiteConnection con = new SQLiteConnection(DBConnection.str))
            {
                return con.Execute("DELETE FROM Records WHERE Id = @Id", new { Id = id }) > 0;
            }
        }

        /// <summary>
        /// Проверить, существует ли запись с указанным ID.
        /// </summary>
        /// <param name="id">ID записи</param>
        /// <returns>true - если существует, иначе - false</returns>
        public bool IsExist(string id)
        {
            using (SQLiteConnection con = new SQLiteConnection(DBConnection.str))
            {
                return con.QueryFirstOrDefault("SELECT * FROM Records WHERE Id = @Id", new { Id = id }) is not null;
            }
        }

        /// <summary>
        /// Возвращает все записи.
        /// <returns>Список всех записей</returns>
        /// </summary>
        public MinecraftMod[] ReadAll()
        {
            using (SQLiteConnection con = new SQLiteConnection(DBConnection.str))
            {
                return [.. con.Query<MinecraftMod>("SELECT * FROM Records ORDER BY Id")];
            }
        }

        /// <summary>
        /// Возвращает запись с указанным ID или null.
        /// <param name="id">ID записи</param>
        /// <returns>Найденная запись или null</returns>
        /// </summary>
        public MinecraftMod? ReadByID(string id)
        {
            using (SQLiteConnection con = new SQLiteConnection(DBConnection.str))
            {
                return con.QueryFirstOrDefault<MinecraftMod>("SELECT * FROM Records WHERE Id = @Id", new { Id = id });
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
            using (SQLiteConnection con = new SQLiteConnection(DBConnection.str))
            {
                return con.Execute($"UPDATE Records SET Name = @Name, Description = @Description, Author = @Author, {GetVersionUpdate("Version")}, {GetVersionUpdate("MinecraftVersionFirst")}, {GetVersionUpdate("MinecraftVersionLast")}, IsJavaMod = @IsJavaMod, Rank = @Rank, Tags = @Tags, Status = @Status where Id = @Id", entity) > 0;
            }
        }

        private string GetVersion(string name) => $"{name}A, {name}B, {name}C, {name}Type";
        private string GetVersionUpdate(string name) => $"{name}A = @{name}A, {name}B = @{name}B, {name}C = @{name}C, {name}Type = @{name}Type";
    }
}
