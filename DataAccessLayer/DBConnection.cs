using System.Data.SQLite;

namespace DataAccessLayer
{
    /// <summary>
    /// Pref SQLite for EF and Dapper.
    /// </summary>
    public static class DBConnection
    {
        static string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AIS", "Mods");
        static bool ready = false;

        /// <summary>
        /// Connection to %LOCALAPPDATA%\AIS\Mods\Minecraft.db.
        /// </summary>
        public static string str = "Data Source=" + Path.Combine(folder, "Minecraft.db");

        /// <summary>
        /// Create table, if it's not exist
        /// </summary>
        public static void CreateTable()
        {
            if (ready) return;

            Directory.CreateDirectory(folder);
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Records ("+
                    /* ID, Name, Description, Author */ "Id text primary key, Name text, Description text, Author text, " +
                    /* Version */ GetVersionSQL("Version") +
                    /* MinecraftVersionFirst */ GetVersionSQL("MinecraftVersionFirst") +
                    /* MinecraftVersionLast */ GetVersionSQL("MinecraftVersionLast") +
                    /* IsJavaMod, Rank, Tags, Status */ "IsJavaMod integer not null, Rank integer not null, Tags text, Status integer not null" + 
                    ")", con);
                cmd.ExecuteNonQuery();
            }
            ready = true;
        }

        /// <summary>
        /// SQL Version-type data for create table
        /// </summary>
        /// <param name="name">Name of Version field</param>
        /// <returns>string of SQL code</returns>
        private static string GetVersionSQL(string name) => $"{name}A integer not null, {name}B integer not null, {name}C integer not null, {name}Type integer not null, ";
    }
}
