using DataAccessLayer;
using Model;

namespace BussinesLogic
{

    /// <summary>
    /// All logic for work with Minecraft mods database
    /// </summary>
    public class ModDatabase : IBasicModDatabase, IModDatabaseCRUD, IModDatabaseLogic, IModDatabaseTagManager, IModDatabaseMinecraftVersionManager, IModDatabaseModListManager, IModDatabaseStringUtilities, IModDatabaseBanManager
    {
        #region Private
        private IRepository<MinecraftMod> Database;

        public ModDatabase(IRepository<MinecraftMod> database)
        {
            Database = database;
        }

        /// <summary>
        /// Get list of mods
        /// </summary>
        /// <returns>list of mods</returns>
        private MinecraftMod[] GetListOfMods()
        {
            return (from mod in Database.ReadAll() select mod).ToArray();
        }

        /// <summary>
        /// Get mod from database
        /// </summary>
        /// <returns>Mod</returns>
        private IsNotExistResult GetMod(string id, out MinecraftMod mod)
        {
            mod = null;
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            var find = Database.ReadByID(id);
            if (find is null) return IsNotExistResult.IsNotExist;
            mod = find;
            return IsNotExistResult.Successful;
        }

        #endregion // Private

        #region IModDatabase
        public IsExistResult Create(string id, string name, string description, string author, EntityVersion version, ModMinecraftVersion minecraftVersion, bool isJavaMod, int rank, List<string> tags)
        {
            if (!IsCorrectID(id)) return IsExistResult.NotID;
            return Database.Create(new MinecraftMod(id, name, description, author, version, minecraftVersion, isJavaMod, rank, tags, ModStatus.Active)) ? IsExistResult.Successful : IsExistResult.IsExist;
        }

        public IsNotExistResult Delete(string id)
        {
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            return Database.Delete(id) ? IsNotExistResult.Successful : IsNotExistResult.IsNotExist;
        }

        public IsNotExistResult Read(string id, out Dictionary<string, object> mod)
        {
            mod = null;
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            var data = Database.ReadByID(id);
            if (data is null) return IsNotExistResult.IsNotExist;
            mod = data.ToJSON();
            return IsNotExistResult.Successful;
        }

        public IsNotExistResult Update(string id, string? name = null, string? description = null, string? author = null, EntityVersion? version = null, int? rank = null, List<string>? tags = null)
        {
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            if (GetMod(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                mod.Name = name ?? mod.Name;
                mod.Description = description ?? mod.Description;
                mod.Author = author ?? mod.Author;
                mod.Version = version ?? mod.Version;
                mod.Rank = rank ?? mod.Rank;
                if (tags is not null) mod.Tags = string.Join('\n', tags);
                Database.Update(mod);
                return IsNotExistResult.Successful;
            }
            return IsNotExistResult.IsNotExist;
        }

        #endregion // IModDatabase

        #region IModDatabaseLogic
        public bool IsExist(string id)
        {
            if (Database is IRepositoryIsExist<MinecraftMod> database) return database.IsExist(id);
            return Database.ReadByID(id) is not null;
        }
        public bool IsCorrectID(string id)
        {
            return !id.IsWhiteSpace();
        }

        #endregion // IModDatabaseLogic

        #region IModDatabaseTagManager
        public IsNotExistResult HasTag(string id, string tag, out bool result)
        {
            result = false;
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            if (GetMod(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                string[] tags = mod.Tags.Split('\n');
                if (tags.IndexOf(tag) != -1) result = true;
                return IsNotExistResult.Successful;
            }
            return IsNotExistResult.IsNotExist;
        }

        public HasTagResult AddTag(string id, string tag)
        {
            if (!IsCorrectID(id)) return HasTagResult.NotID;
            if (GetMod(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                List<string> tags = mod.Tags.Split('\n').ToList();
                if (tags.IndexOf(tag) != -1) return HasTagResult.HasTag;
                tags.Add(tag);
                mod.Tags = string.Join('\n', tags);
                Database.Update(mod);
                return HasTagResult.Successful;
            }
            return HasTagResult.IsNotExist;
        }

        public HasNotTagResult RemoveTag(string id, string tag)
        {
            if (!IsCorrectID(id)) return HasNotTagResult.NotID;
            if (GetMod(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                List<string> tags = mod.Tags.Split('\n').ToList();
                if (tags.Remove(tag))
                {
                    mod.Tags = string.Join('\n', tags);
                    Database.Update(mod);
                    return HasNotTagResult.Successful;
                }
                return HasNotTagResult.HasNotTag;
            }
            return HasNotTagResult.IsNotExist;
        }

        public IsNotExistResult GetAllModsWithTag(string tag, out string[] mods)
        {
            mods = (from mod in GetListOfMods() where mod.Status != ModStatus.ShadowBanned && mod.Tags.Split('\n').Contains(tag) select mod.Id).ToArray();
            if (mods.Length == 0) return IsNotExistResult.IsNotExist;
            return IsNotExistResult.Successful;
        }

        public IsNotExistResult GetAllTags(string id, out string[] result)
        {
            result = [];
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            if (GetMod(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                result = mod.Tags.Split('\n').ToArray();
                return IsNotExistResult.Successful;
            }
            return IsNotExistResult.IsNotExist;
        }
        #endregion // IModDatabaseTagManager

        #region IModDatabaseMinecraftVersionManager
        public IsNotExistResult IsCorrectForMinecraftVersion(string id, EntityVersion version, out bool result)
        {
            result = false;
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            if (GetMod(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                result = mod.MinecraftVersion.First <= version && mod.MinecraftVersion.Last >= version;
                return IsNotExistResult.Successful;
            }
            return IsNotExistResult.IsNotExist;
        }

        public IsNotCorrectVersionResult ChangeMinecraftVersionForMod(string id, ModMinecraftVersion version, out string newId)
        {
            newId = id;
            if (!IsCorrectID(id)) return IsNotCorrectVersionResult.NotID;
            if (GetMod(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                if (mod.MinecraftVersion.First > version.First || mod.MinecraftVersion.Last > version.Last) return IsNotCorrectVersionResult.NoCorrectVersion;
                mod.MinecraftVersion = version;
                string _id = MinecraftMod.FormatID(id, version.First);
                if (_id == id)
                {
                    Database.Update(mod);
                    return IsNotCorrectVersionResult.Successful;
                }
                string nid = _id;
                int i = 1;
                while (_id != id && IsExist(nid))
                {
                    nid = _id + i.ToString();
                    i++;
                }
                mod.Id = nid;
                newId = nid;
                Database.Delete(id);
                Database.Create(mod);
                return IsNotCorrectVersionResult.Successful;
            }
            return IsNotCorrectVersionResult.IsNotExist;
        }
        #endregion // IModDatabaseMinecraftVersionManager

        #region IModDatabaseModListManager
        public string[] GetFullListOfIDMods()
        {
            return (from mod in Database.ReadAll() select mod.Id).ToArray();
        }

        public string[] GetListOfIDMods()
        {
            return (from mod in Database.ReadAll() where mod.Status != ModStatus.ShadowBanned select mod.Id).ToArray();
        }
        #endregion // IModDatabaseModListManager

        #region IModDatabaseStringUtilities
        public IsNotExistResult GetStringMod(string id, out string result)
        {
            result = "EMPTY";
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            if (GetMod(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                result = mod.ToString();
                return IsNotExistResult.Successful;
            }
            return IsNotExistResult.IsNotExist;
        }
        #endregion // IModDatabaseStringUtilities

        #region IModDatabaseBanManager
        public IsNotExistResult CheckStatusMod(string id, out ModStatus status)
        {
            status = ModStatus.Active;
            var res = GetMod(id, out MinecraftMod mod);
            if (res == IsNotExistResult.Successful) status = mod.Status;
            return res;
        }

        public IsBanResult BanMod(string id)
        {
            if (!IsCorrectID(id)) return IsBanResult.NotID;
            if (GetMod(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                if (mod.Status == ModStatus.Banned) return IsBanResult.IsBan;
                mod.Status = ModStatus.Banned;
                mod.Description = "MOD WAS BANNED\nIF YOU DEVELOPER TRY CONTACT WITH US\nXXXXXXXX@gmail.com";
                mod.Tags = "";
                Database.Update(mod);
                return IsBanResult.Successful;
            }
            return IsBanResult.IsNotExist;
        }

        public IsBanResult ShadowBan(string id)
        {
            if (!IsCorrectID(id)) return IsBanResult.NotID;
            if (GetMod(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                if (mod.Status == ModStatus.ShadowBanned) return IsBanResult.IsBan;
                mod.Status = ModStatus.ShadowBanned;
                Database.Update(mod);
                return IsBanResult.Successful;
            }
            return IsBanResult.IsNotExist;
        }
        #endregion // IModDatabaseBanManager
    }
}

