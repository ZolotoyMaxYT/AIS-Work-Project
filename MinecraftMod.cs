using System;
using System.Collections.Generic;
using System.Text;

namespace ArchIS
{
    public class MinecraftMod
    {
        public string Id { get; set; } = "";
        public string Author { get; set; } = "Empty";
        public int Version { get; set; } = 0;
        public bool IsPublic { get; set; } = false;

        public MinecraftMod(string id, string author, int version, bool isPublic) 
        {
            Id = id; 
            Author = author; 
            Version = version; 
            IsPublic = isPublic;
        }

        public MinecraftMod(Dictionary<string, object> data)
        {
            Id = (string)data["Id"];
            Author = (string)data["Author"];
            Version = (int)data["Version"];
            IsPublic = (bool)data["IsPublic"];
        }

        public static MinecraftMod? Create(Dictionary<string, object> data)
        {
            if (!IsCorrectData(data)) return null;
            return new MinecraftMod((string)data["Id"], (string)data["Author"], (int)data["Version"], (bool)data["IsPublic"]);
        }

        public override string ToString()
        {
            return IsPublic ? $"Public {Id} by {Author} (v{Version})" : $"Private {Id} by {Author} (v{Version})";
        }

        public MinecraftMod SetID(string id)
        {
            Id = id;
            return this;
        }

        public MinecraftMod UpdateData(Dictionary<string, object> data)
        {
            if (IsCorrectData(data))
            {
                Id = (string)data["Id"];
                Author = (string)data["Author"];
                Version = (int)data["Version"];
                IsPublic = (bool)data["IsPublic"];
            }
            return this;
        }

        public Dictionary<string, object> GetData()
        {
            return new() {
                { "Id", Id },
                { "Author", Author  },
                { "Version", Version  },
                { "IsPublic", IsPublic  }
            };
        }

        public static bool IsCorrectData(Dictionary<string, object> data)
        {
            return data.ContainsKey("Id") &&
                data.ContainsKey("Author") &&
                data.ContainsKey("Version") && data["Version"] is int &&
                data.ContainsKey("IsPublic") && data["IsPublic"] is bool;
        }
    }
}
