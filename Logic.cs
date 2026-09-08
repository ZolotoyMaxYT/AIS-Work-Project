using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Xml.Linq;

namespace ArchIS
{
    
    public static class Logic
    {
        public static List<MinecraftMod> SearchAll(List<MinecraftMod> database, string id)
        {
            return (from item in database where item.Id == id select item).ToList();
        }

        public enum CreateResult
        {
            NoCorrectData,
            IsExist,
            Successful
        }
        public static CreateResult Create(List<MinecraftMod> database, Dictionary<string, object> data)
        {
            if (!MinecraftMod.IsCorrectData(data)) return CreateResult.NoCorrectData;
            if (SearchAll(database, (string)data["Id"]).Count != 0) return CreateResult.IsExist;
            database.Add(new(data));
            return CreateResult.Successful;
        }
        public enum DeleteResult
        {
            IsNotExist,
            Successful
        }
        public static DeleteResult Delete(List<MinecraftMod> database, string id)
        {
            var find = SearchAll(database, id);
            if (find.Count == 0) return DeleteResult.IsNotExist;
            database.Remove(find[0]);
            return DeleteResult.Successful;
        }
        public static Dictionary<string, object>? Read(List<MinecraftMod> database, string id)
        {
            var find = SearchAll(database, id);
            if (find.Count == 0) return null;
            return find[0].GetData();
        }
        public enum UpdateResult
        {
            NoCorrectData,
            IsNotExist,
            Successful
        }
        public static UpdateResult Update(List<MinecraftMod> database, string id, Dictionary<string, object> data)
        {
            if (!MinecraftMod.IsCorrectData(data)) return UpdateResult.NoCorrectData;
            var find = SearchAll(database, id);
            if (find.Count == 0) return UpdateResult.IsNotExist;
            find[0].UpdateData(data);
            return UpdateResult.Successful;
        }


        public enum SetPublicOrPrivateResult
        {
            IsNotExist,
            NoChanged,
            Successful
        }
        public static SetPublicOrPrivateResult SetPublic(List<MinecraftMod> database, string id)
        {
            var find = SearchAll(database, id);
            if (find.Count == 0) return SetPublicOrPrivateResult.IsNotExist;
            if (find[0].IsPublic) return SetPublicOrPrivateResult.NoChanged;
            find[0].IsPublic = true;
            return SetPublicOrPrivateResult.Successful;
        }
        public static SetPublicOrPrivateResult SetPrivate(List<MinecraftMod> database, string id)
        {
            var find = SearchAll(database, id);
            if (find.Count == 0) return SetPublicOrPrivateResult.IsNotExist;
            if (!find[0].IsPublic) return SetPublicOrPrivateResult.NoChanged;
            find[0].IsPublic = false;
            return SetPublicOrPrivateResult.Successful;
        }
    }
}
