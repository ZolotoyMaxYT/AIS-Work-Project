using Model;
using Dapper;
using System.Data;
using System.Data.SQLite;

namespace DataAccessLayer
{
    /// <summary>
    /// Repository from через Dapper
    /// </summary>
    public class DapperRepository : IRepository<MinecraftMod>
    {
        public DapperRepository()
        {
            DBConnection.CreateTable();
        }

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

        public MinecraftMod[] ReadAll()
        {
            using (SQLiteConnection con = new SQLiteConnection(DBConnection.str))
            {
                return [.. con.Query<MinecraftMod>("SELECT * FROM Records ORDER BY Id")];
            }
        }

        public MinecraftMod? ReadByID(string id)
        {
            using (SQLiteConnection con = new SQLiteConnection(DBConnection.str))
            {
                return con.QueryFirstOrDefault<MinecraftMod>("SELECT * FROM Records WHERE Id = @Id", new { Id = id });
            }
        }

        public bool Update(MinecraftMod entity)
        {
            if (entity == null) return false;
            using (SQLiteConnection con = new SQLiteConnection(DBConnection.str))
            {
                return con.Execute($"UPDATE Records SET Name = @Name, Description = @Description, Author = @Author, {GetVersionUpdate("Version")}, {GetVersionUpdate("MinecraftVersionFirst")}, {GetVersionUpdate("MinecraftVersionLast")}, IsJavaMod = @IsJavaMod, Rank = @Rank, Tags = @Tags, Status = @Status where Id = @Id", entity) > 0;
            }
        }

        /// <summary>
        /// SQL Version-type create data
        /// </summary>
        /// <param name="name">Name of Version field</param>
        /// <returns>string of SQL code</returns>
        private string GetVersion(string name) => $"{name}A, {name}B, {name}C, {name}Type";
        /// <summary>
        /// SQL Version-type update data
        /// </summary>
        /// <param name="name">Name of Version field</param>
        /// <returns>string of SQL code</returns>
        private string GetVersionUpdate(string name) => $"{name}A = @{name}A, {name}B = @{name}B, {name}C = @{name}C, {name}Type = @{name}Type";
    }
}
