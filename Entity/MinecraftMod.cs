namespace Entity
{
    public enum TypeVersion : byte
    {
        Alpha,
        Beta,
        Release
    }
    public struct ModVersion
    {
        public TypeVersion Type;
        public int A;
        public int B;
        public int C;

        public ModVersion(TypeVersion type, int a, int b, int c)
        {
            Type = type;
            A = a;
            B = b;
            C = c;
        }

        public override string ToString()
        {
            return $"v{A}.{B}.{C} ({Type})";
        }
    }
    public class MinecraftMod
    {
        public string Id;
        public string Name;
        public string Description;
        public string Author;
        public ModVersion Version;
        /// <summary>
        /// true is java, false is bedrock
        /// </summary>
        public bool IsJavaMod;
        public int Rank;
        public List<string> ModPacks;

        public MinecraftMod(string id, string name, string description, string author, ModVersion version, bool isJavaMod, int rank, List<string> modPacks)
        {
            Id = id;
            Name = name; 
            Description = description;
            Author = author; 
            Version = version; 
            IsJavaMod = isJavaMod; 
            Rank = rank;
            ModPacks = modPacks;
        }

        public override string ToString()
        {
            return IsJavaMod ? $"JAVA [{Id}] {Name} {Version} by {Author}" : $"BEDROCK [{Id}] {Name} {Version} by {Author}";
        }
    }
}
