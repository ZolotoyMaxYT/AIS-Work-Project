namespace BussinesLogic
{
    public enum TypeVersion : byte
    {
        Alpha,
        Beta,
        Release
    }
    public struct EntityVersion
    {
        public TypeVersion Type;
        public int A;
        public int B;
        public int C;

        public EntityVersion(TypeVersion type, int a, int b, int c)
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

        public static bool operator==(EntityVersion x, EntityVersion y)
        {
            return x.Type == y.Type && x.A == y.A && x.B == y.B && x.C == y.C;
        }
        public static bool operator !=(EntityVersion x, EntityVersion y)
        {
            return x.Type != y.Type || x.A != y.A || x.B != y.B || x.C != y.C;
        }
        public static bool operator >(EntityVersion x, EntityVersion y)
        {
            return x.Type > y.Type || (x.Type == y.Type && x.A > y.A) || (x.Type == y.Type && x.A == y.A && x.B > y.B) || (x.Type == y.Type && x.A == y.A && x.B == y.B && x.C > y.C);
        }
        public static bool operator <(EntityVersion x, EntityVersion y)
        {
            return x.Type < y.Type || (x.Type == y.Type && x.A < y.A) || (x.Type == y.Type && x.A == y.A && x.B < y.B) || (x.Type == y.Type && x.A == y.A && x.B == y.B && x.C < y.C);
        }
        public static bool operator >=(EntityVersion x, EntityVersion y)
        {
            return x > y || x == y;
        }
        public static bool operator <=(EntityVersion x, EntityVersion y)
        {
            return x < y || x == y;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not null && obj is EntityVersion vers)
            {
                return this == vers;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Type.GetHashCode() + A.GetHashCode() + B.GetHashCode() + C.GetHashCode();
        }
    }
    public struct MinecraftVersion
    {
        public EntityVersion First;
        public EntityVersion Last;

        public MinecraftVersion(EntityVersion first, EntityVersion last)
        {
            First = first;
            Last = last;
        }

        public override string ToString()
        {
            return $"{First} - {Last}";
        }
    }
    public class MinecraftMod
    {
        public string Id;
        public string Name;
        public string Description;
        public string Author;
        public EntityVersion Version;
        public MinecraftVersion MinecraftVersion;
        /// <summary>
        /// true is java, false is bedrock
        /// </summary>
        public bool IsJavaMod;
        public int Rank;
        public List<string> Tags;

        public MinecraftMod(string id, string name, string description, string author, EntityVersion version, MinecraftVersion minecraftVersion, bool isJavaMod, int rank, List<string> tags)
        {
            Id = id;
            Name = name; 
            Description = description;
            Author = author; 
            Version = version;
            MinecraftVersion = minecraftVersion;
            IsJavaMod = isJavaMod; 
            Rank = rank;
            Tags = tags;
        }

        public override string ToString()
        {
            return IsJavaMod ? $"JAVA [{Id}] \"{Name}\" {Version} by {Author} [{MinecraftVersion}]" : $"BEDROCK [{Id}] \"{Name}\" {Version} by {Author} [{MinecraftVersion}]";
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
            };
        }
    }
}
