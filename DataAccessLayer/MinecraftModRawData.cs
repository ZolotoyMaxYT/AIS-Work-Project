using Model;

namespace DataAccessLayer
{
    public class MinecraftModRawData : IDomainObject
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "[NoName]";
        public string Description { get; set; } = "";
        public string Author { get; set; } = "[NoAuthor]";
        public string Version { get; set; } = "v1.0.0r";
        public string MinecraftVersionFirst { get; set; } = "v1.0.0r";
        public string MinecraftVersionLast { get; set; } = "v1.0.0r";
        public int IsJavaMod { get; set; } = 1;
        public int Rank { get; set; } = 0;
        public string Tags { get; set; } = "";
        public ModStatus Status { get; set; } = ModStatus.Active;

        public MinecraftModRawData() { }
        public MinecraftModRawData(MinecraftMod mod) 
        {
            Id = mod.Id;
            Name = mod.Name;
            Description = mod.Description;
            Author = mod.Author;
            Version = mod.Version.ToString();
            MinecraftVersionFirst = mod.MinecraftVersion.First.ToString();
            MinecraftVersionLast = mod.MinecraftVersion.Last.ToString();
            IsJavaMod = mod.IsJavaMod ? 1 : 0;
            Rank = mod.Rank;
            Tags = string.Join('\n', mod.Tags);
            Status = mod.Status;
        }

        public MinecraftMod ToMinecraftMod()
        {
            EntityVersion.TryParse(Version, out var ver);
            EntityVersion.TryParse(MinecraftVersionFirst, out var mvf);
            EntityVersion.TryParse(MinecraftVersionLast, out var mvl);
            return new(Id, Name, Description, Author, ver, new(mvf, mvl), IsJavaMod == 1, Rank, Tags.Split('\n').ToList(), Status);
        }
    }
}
