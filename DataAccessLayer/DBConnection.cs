using System.Data.SQLite;

namespace DataAccessLayer
{
    /// <summary>
    /// Настройки базы SQLite для EF и Dapper.
    /// </summary>
    public static class DBConnection
    {
        static string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AIS", "Mods");
        static bool ready = false;

        /// <summary>
        /// Строка подключения к файлу %LOCALAPPDATA%\AIS\Mods\Minecraft.db.
        /// </summary>
        public static string str = "Data Source=" + Path.Combine(folder, "Minecraft.db");

        /// <summary>
        /// Создает папку, файл базы и таблицу Records, если их еще нет.
        /// </summary>
        public static void CreateTable()
        {
            if (ready)
                return;

            Directory.CreateDirectory(folder);
            using (SQLiteConnection con = new SQLiteConnection(str))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Records ("+
                    /* ID, Name, Description, Author */ "Id text primary key, Name text, Description text, Author text, " +
                    /* Version,  MinecraftVersionFirst, MinecraftVersionLast */ "Version text, MinecraftVersionFirst text, MinecraftVersionLast text, " +
                    /* IsJavaMod, Rank, Tags, Status */ "IsJavaMod integer not null, Rank integer not null, Tags text, Status integer not null" + 
                    ")", con);
                cmd.ExecuteNonQuery();
            }
            ready = true;
        }
    }
}
