namespace Model
{
    public class MinecraftMod : IDomainObject
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "[NO NAME]";
        public string Description { get; set; } = "";
        public string Author { get; set; } = "[NO NAME]";

        #region Version
        public EntityVersion Version = new(TypeVersion.Alpha, 1, 0, 0);
        public int VersionA 
        {
            get => Version.A; 
            set => Version.A = value; 
        }
        public int VersionB
        {
            get => Version.B;
            set => Version.B = value;
        }
        public int VersionC
        {
            get => Version.C;
            set => Version.C = value;
        }
        public TypeVersion VersionType
        {
            get => Version.Type;
            set => Version.Type = value;
        }
        #endregion

        public ModMinecraftVersion MinecraftVersion = new(new(TypeVersion.Alpha, 1, 0, 0), new(TypeVersion.Alpha, 1, 0, 0));
        #region MinecraftVersionFirst
        public int MinecraftVersionFirstA
        {
            get => MinecraftVersion.First.A;
            set => MinecraftVersion.First.A = value;
        }
        public int MinecraftVersionFirstB
        {
            get => MinecraftVersion.First.B;
            set => MinecraftVersion.First.B = value;
        }
        public int MinecraftVersionFirstC
        {
            get => MinecraftVersion.First.C;
            set => MinecraftVersion.First.C = value;
        }
        public TypeVersion MinecraftVersionFirstType
        {
            get => MinecraftVersion.First.Type;
            set => MinecraftVersion.First.Type = value;
        }
        #endregion

        #region MinecraftVersionLast
        public int MinecraftVersionLastA
        {
            get => MinecraftVersion.Last.A;
            set => MinecraftVersion.Last.A = value;
        }
        public int MinecraftVersionLastB
        {
            get => MinecraftVersion.Last.B;
            set => MinecraftVersion.Last.B = value;
        }
        public int MinecraftVersionLastC
        {
            get => MinecraftVersion.Last.C;
            set => MinecraftVersion.Last.C = value;
        }
        public TypeVersion MinecraftVersionLastType
        {
            get => MinecraftVersion.Last.Type;
            set => MinecraftVersion.Last.Type = value;
        }
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
        /// Get mod as string
        /// </summary>
        public override string ToString()
        {
            string prefix = Status == ModStatus.Banned ? "[BAN] " : "";
            string type = IsJavaMod ? "JAVA" : "BEDROCK";
            return $"{prefix}{type} [{Id}] \"{Name}\" {Version} by {Author} [{MinecraftVersion}]";
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
                { "Version", Version },
                { "MinecraftVersion", MinecraftVersion },
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
