using Model;
using Dapper;
using System.Data;
using System.Data.SQLite;

namespace DataAccessLayer
{
    /// <summary>
    /// Репозиторий записей через Dapper
    /// </summary>
    public class DapperRepository : IRepository<MinecraftModRawData>
    {
        public DapperRepository()
        {
            DBConnection.CreateTable();
        }

        /// <summary>
        /// Добавляет запись в базу и записывает ей новый ID.
        /// </summary>
        public bool Create(MinecraftModRawData entity)
        {
            if (entity == null || IsExist(entity.Id)) return false;

            using (SQLiteConnection con = new SQLiteConnection(DBConnection.str))
            {
                con.Execute(@"
                    INSERT INTO Records (Id, Name, Description, Author, Version, MinecraftVersionFirst, MinecraftVersionLast, IsJavaMod, Rank, Tags, Status)
                    VALUES (@Id, @Name, @Description, @Author, @Version, @MinecraftVersionFirst, @MinecraftVersionLast, @IsJavaMod, @Rank, @Tags, @Status)", entity);
                }
            return true;
        }

        /// <summary>
        /// Удаляет запись с указанным ID.
        /// </summary>
        public bool Delete(string id)
        {
            using (SQLiteConnection con = new SQLiteConnection(DBConnection.str))
            {
                return con.Execute("DELETE FROM Records WHERE Id = @Id", new { Id = id }) > 0;
            }
        }

        public bool IsExist(string id)
        {
            using (SQLiteConnection con = new SQLiteConnection(DBConnection.str))
            {
                return con.QueryFirstOrDefault("SELECT * FROM Records WHERE Id = @Id", new { Id = id }) is not null;
            }
        }

        /// <summary>
        /// Возвращает все записи.
        /// </summary>
        public List<MinecraftModRawData> ReadAll()
        {
            using (SQLiteConnection con = new SQLiteConnection(DBConnection.str))
            {
                return [.. con.Query<MinecraftModRawData>("SELECT * FROM Records ORDER BY Id")];
            }
        }

        /// <summary>
        /// Возвращает запись с указанным ID или null.
        /// </summary>
        public MinecraftModRawData? ReadByID(string id)
        {
            using (SQLiteConnection con = new SQLiteConnection(DBConnection.str))
            {
                return con.QueryFirstOrDefault<MinecraftModRawData>("SELECT * FROM Records WHERE Id = @Id", new { Id = id });
            }
        }

        /// <summary>
        /// Сохраняет изменения записи.
        /// </summary>
        public bool Update(MinecraftModRawData entity)
        {
            if (entity == null) return false;
            using (SQLiteConnection con = new SQLiteConnection(DBConnection.str))
            {
                return con.Execute("UPDATE Records SET Name = @Name, Description = @Description, Author = @Author, Version = @Version, MinecraftVersionFirst = @MinecraftVersionFirst, MinecraftVersionLast = @MinecraftVersionLast, IsJavaMod = @IsJavaMod, Rank = @Rank, Tags = @Tags, Status = @Status where Id = @Id", entity) > 0;
            }
        }
    }
}
