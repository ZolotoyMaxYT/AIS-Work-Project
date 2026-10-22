using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class MinecraftMod : IDomainObject
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "[NO NAME]";
        public string Description { get; set; } = "";
        public string Author { get; set; } = "[NO NAME]";

        #region Version
        public int VersionA { get; set; } = 1;
        public int VersionB { get; set; } = 0;
        public int VersionC { get; set; } = 0;
        public TypeVersion VersionType { get; set; } = TypeVersion.Alpha;
        #endregion

        #region MinecraftVersionFirst
        public int MinecraftVersionFirstA { get; set; } = 1;
        public int MinecraftVersionFirstB { get; set; } = 0;
        public int MinecraftVersionFirstC { get; set; } = 0;
        public TypeVersion MinecraftVersionFirstType { get; set; } = TypeVersion.Alpha;
        #endregion

        #region MinecraftVersionLast
        public int MinecraftVersionLastA { get; set; } = 1;
        public int MinecraftVersionLastB { get; set; } = 0;
        public int MinecraftVersionLastC { get; set; } = 0;
        public TypeVersion MinecraftVersionLastType { get; set; } = TypeVersion.Alpha;
        #endregion

        /// <summary>
        /// true is java, false is bedrock
        /// </summary>
        public bool IsJavaMod { get; set; } = true;
        public int Rank { get; set; } = 0;
        public string Tags { get; set; } = "";
        public ModStatus Status { get; set; } = ModStatus.Active;
        
        public MinecraftMod(string id, string name, string description, string author, EntityVersion version, ModMinecraftVersion minecraftVersion, bool isJavaMod, int rank, List<string> tags, ModStatus status)
        {
            Id = FormatID(id ,minecraftVersion.First);
            Name = name; 
            Description = description;
            Author = author;
            // Version
            VersionA = version.A;
            VersionB = version.B;
            VersionC = version.C;
            VersionType = version.Type;
            // MinecraftVersionFirst
            MinecraftVersionFirstA = minecraftVersion.First.A;
            MinecraftVersionFirstB = minecraftVersion.First.B;
            MinecraftVersionFirstC = minecraftVersion.First.C;
            MinecraftVersionFirstType = minecraftVersion.First.Type;
            // MinecraftVersionLast
            MinecraftVersionLastA = minecraftVersion.Last.A;
            MinecraftVersionLastB = minecraftVersion.Last.B;
            MinecraftVersionLastC = minecraftVersion.Last.C;
            MinecraftVersionLastType = minecraftVersion.Last.Type;
            IsJavaMod = isJavaMod; 
            Rank = rank;
            Tags = string.Join('\n', tags);
            Status = status;
        }
        
        public MinecraftMod() { }

        /// <summary>
        /// Set version in one line
        /// </summary>
        /// <param name="version">new version</param>
        public void SetVersion(EntityVersion version)
        {
            VersionA = version.A;
            VersionB = version.B;
            VersionC = version.C;
            VersionType = version.Type;
        }
        
        /// <summary>
        /// Get version in one line
        /// </summary>
        public EntityVersion GetVersion()
        {
            return new(VersionType, VersionA, VersionB, VersionC);
        }

        /// <summary>
        /// Set minecraft version in one line
        /// </summary>
        /// <param name="version">new version</param>
        public void SetMinecraftVersion(ModMinecraftVersion version)
        {
            MinecraftVersionFirstA = version.First.A;
            MinecraftVersionFirstB = version.First.B;
            MinecraftVersionFirstC = version.First.C;
            MinecraftVersionFirstType = version.First.Type;
            MinecraftVersionLastA = version.Last.A;
            MinecraftVersionLastB = version.Last.B;
            MinecraftVersionLastC = version.Last.C;
            MinecraftVersionLastType = version.Last.Type;
        }
        
        /// <summary>
        /// Get minecraft version in one line
        /// </summary>
        public ModMinecraftVersion GetMinecraftVersion()
        {
            return new(new(MinecraftVersionFirstType, MinecraftVersionFirstA, MinecraftVersionFirstB, MinecraftVersionFirstC), new(MinecraftVersionLastType, MinecraftVersionLastA, MinecraftVersionLastB, MinecraftVersionLastC));
        }

        /// <summary>
        /// Get mod as string
        /// </summary>
        public override string ToString()
        {
            string prefix = Status == ModStatus.Banned ? "[BAN] " : "";
            string type = IsJavaMod ? "JAVA" : "BEDROCK";
            string version = EntityVersion.ToString(VersionType, VersionA, VersionB, VersionC);
            string minecraftVersion = ModMinecraftVersion.ToString(MinecraftVersionFirstType, MinecraftVersionFirstA, MinecraftVersionFirstB, MinecraftVersionFirstC, MinecraftVersionLastType, MinecraftVersionLastA, MinecraftVersionLastB, MinecraftVersionLastC);
            return $"{prefix}{type} [{Id}] \"{Name}\" {version} by {Author} [{minecraftVersion}]";
        }

        /// <summary>
        /// Get mod as JSON object
        /// </summary>
        public Dictionary<string, object> ToJSON()
        {
            return new()
            {
                { "Id", Id },
                { "Name", Name },
                { "Description", Description },
                { "Author", Author },
                { "Version", GetVersion() },
                { "MinecraftVersion", GetMinecraftVersion() },
                { "IsJavaMod", IsJavaMod },
                { "Rank", Rank },
                { "Tags", Tags.Split('\n') },
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
            if (minecraftVersion < new EntityVersion(TypeVersion.Beta, 1, 0, 0))
            {
                return id.ToLower();
            }
            if (minecraftVersion < new EntityVersion(TypeVersion.Release, 1, 0, 0))
            {
                return id.ToUpper();
            }
            return id;
        }
    }
}
