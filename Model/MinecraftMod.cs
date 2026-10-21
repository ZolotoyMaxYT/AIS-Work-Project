using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class MinecraftMod
    {
        public string Id { get; set; }
        public string Name;
        public string Description;
        public string Author;

        public EntityVersion Version;
        public ModMinecraftVersion MinecraftVersion;
        /// <summary>
        /// true is java, false is bedrock
        /// </summary>
        public bool IsJavaMod;
        public int Rank = 0;
        public List<string> Tags;
        public ModStatus Status = ModStatus.Active;
        

        public MinecraftMod(string id, string name, string description, string author, EntityVersion version, ModMinecraftVersion minecraftVersion, bool isJavaMod, int rank, List<string> tags, ModStatus status)
        {
            Id = FormatID(id ,minecraftVersion.First);
            Name = name; 
            Description = description;
            Author = author; 
            Version = version;
            MinecraftVersion = minecraftVersion;
            IsJavaMod = isJavaMod; 
            Rank = rank;
            Tags = tags;
            Status = status;
        }

        public override string ToString()
        {
            string prefix = Status == ModStatus.Banned ? "[BAN] " : "";
            if (IsJavaMod) 
                return prefix + $"JAVA [{Id}] \"{Name}\" {Version} by {Author} [{MinecraftVersion}]";
            return prefix + $"BEDROCK [{Id}] \"{Name}\" {Version} by {Author} [{MinecraftVersion}]";
        }

        public Dictionary<string, object> ToJSON()
        {
            return new()
            {
                { "Id", Id },
                { "Name", Name },
                { "Description", Description },
                { "Author", Author },
                { "Version", Version },
                { "MinecraftVersion", MinecraftVersion },
                { "IsJavaMod", IsJavaMod },
                { "Rank", Rank },
                { "Tags", Tags },
                { "Status", Status }
            };
        }

        /// <summary>
        /// Formating mod's ID for minecraft's version 
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="minecraftVersion">version of minecraft</param>
        /// <returns></returns>
        public static string FormatID(string id, EntityVersion minecraftVersion)
        {
            if (minecraftVersion >= new EntityVersion(TypeVersion.Release, 1, 13, 0))
            {
                return id.ToLower();
            }
            if (minecraftVersion >= new EntityVersion(TypeVersion.Release, 1, 8, 0))
            {
                return id.ToUpper();
            }
            return id;
        }
    }
}
