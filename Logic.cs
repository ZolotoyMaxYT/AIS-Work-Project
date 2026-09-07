using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ArchIS
{
    public interface IEntity
    {
        public string Id { get; set; }
        public Dictionary<string, object> ToData();
        public IEntity SetID(string id);
        public IEntity FromData(Dictionary<string, object> data);
        public string ToString();
    }
    public interface IPublicPrivate
    {
        public bool IsPublic { get; set; }
    }
    public class MinecraftMod : IEntity, IPublicPrivate
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "Empty";
        public string Author { get; set; } = "Empty";
        public int Version { get; set; } = 0;
        public bool IsPublic { get; set; } = false;

        public MinecraftMod() { }

        public override string ToString()
        {
            return IsPublic ? $"[{Id}] Public {Name} by {Author} (v{Version})" : $"Private {Name} by {Author} (v{Version})";
        }

        public IEntity SetID(string id)
        {
            Id = id;
            return this;
        }
        public Dictionary<string, object> ToData()
        {
            return new() {
                { "Id", Id },
                { "Name", Name  },
                { "Author", Author  },
                { "Version", Version  },
                { "IsPublic", IsPublic  }
            };
        }
        public IEntity FromData(Dictionary<string, object> data)
        {
            if (IsCorrectData(data))
            {
                Name = (string)data["Name"];
                Author = (string)data["Author"];
                Version = (int)data["Version"];
                IsPublic = (bool)data["IsPublic"];
            }
            return this;
        }

        public static bool IsCorrectData(Dictionary<string, object> data)
        {
            return data.ContainsKey("Name") && 
                data.ContainsKey("Author") && 
                data.ContainsKey("Version") && data["Version"] is int &&
                data.ContainsKey("IsPublic") && data["IsPublic"] is bool;
        }

        
    }

    public static class Logic
    {
        // IEntity is MinecraftMod
        public static List<IEntity> SearchAll(List<IEntity> database, string id)
        {
            return (from item in database where item.Id == id select item).ToList();
        }

        public enum CreateResult
        {
            NoCorrectData,
            IsExist,
            Successful
        }
        public static CreateResult Create<T>(List<IEntity> database, string id, Dictionary<string, object> data) where T : IEntity, new()
        {
            if (!MinecraftMod.IsCorrectData(data)) return CreateResult.NoCorrectData;
            if (SearchAll(database, id).Count != 0) return CreateResult.IsExist;
            database.Add(new T().SetID(id).FromData(data));
            return CreateResult.Successful;
        }
        public enum DeleteResult
        {
            IsNotExist,
            Successful
        }
        public static DeleteResult Delete<T>(List<IEntity> database, string id) where T : IEntity, new()
        {
            var find = SearchAll(database, id);
            if (find.Count == 0) return DeleteResult.IsNotExist;
            database.Remove(find[0]);
            return DeleteResult.Successful;
        }
        public static Dictionary<string, object>? Read<T>(List<IEntity> database, string id) where T : IEntity, new()
        {
            var find = SearchAll(database, id);
            if (find.Count == 0) return null;
            return find[0].ToData();
        }
        public enum UpdateResult
        {
            NoCorrectData,
            IsNotExist,
            Successful
        }
        public static UpdateResult Update<T>(List<IEntity> database, string id, Dictionary<string, object> data) where T : IEntity, new()
        {
            if (!MinecraftMod.IsCorrectData(data)) return UpdateResult.NoCorrectData;
            var find = SearchAll(database, id);
            if (find.Count == 0) return UpdateResult.IsNotExist;
            find[0].FromData(data);
            return UpdateResult.Successful;
        }


        public enum SetPublicOrPrivateResult
        {
            IsNotExist,
            IsNotPublicPrivate,
            NoChanged,
            Successful
        }
        public static SetPublicOrPrivateResult SetPublic<T>(List<IEntity> database, string id) where T : IEntity, IPublicPrivate
        {
            var find = SearchAll(database, id);
            if (find.Count == 0) return SetPublicOrPrivateResult.IsNotExist;
            if (find[0] is not IPublicPrivate) return SetPublicOrPrivateResult.IsNotPublicPrivate;
            IPublicPrivate item = (IPublicPrivate)find[0];
            if (item.IsPublic) return SetPublicOrPrivateResult.NoChanged;
            item.IsPublic = true;
            return SetPublicOrPrivateResult.Successful;
        }
        public static SetPublicOrPrivateResult SetPrivate<T>(List<IEntity> database, string id) where T : IEntity, IPublicPrivate
        {
            var find = SearchAll(database, id);
            if (find.Count == 0) return SetPublicOrPrivateResult.IsNotExist;
            if (find[0] is not IPublicPrivate) return SetPublicOrPrivateResult.IsNotPublicPrivate;
            IPublicPrivate item = (IPublicPrivate)find[0];
            if (!item.IsPublic) return SetPublicOrPrivateResult.NoChanged;
            item.IsPublic = false;
            return SetPublicOrPrivateResult.Successful;
        }
    }
}
