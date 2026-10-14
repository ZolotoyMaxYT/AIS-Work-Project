namespace BussinesLogic
{
    
    public class ModDatabase
    {
        #region Base
        private List<MinecraftMod> Database = new();
        /// <summary>
        /// Get index of mod
        /// </summary>
        /// <returns>index of mod or -1 if mod is not exist</returns>
        private int GetIndexOf(string id)
        {
            var count = Database.Count;
            for (int i = 0; i < count; i++)
            {
                if (Database[i].Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Get list of mods
        /// </summary>
        /// <returns>list of mods</returns>
        private MinecraftMod[] GetListOfMods()
        {
            return (from mod in Database select mod).ToArray();
        }

        /// <summary>
        /// Get mod from database
        /// </summary>
        /// <returns>Mod</returns>
        private IsNotExistResult GetMod(string id, out MinecraftMod mod)
        {
            mod = null;
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            int find = GetIndexOf(id);
            if (find == -1) return IsNotExistResult.IsNotExist;
            mod = Database[find];
            return IsNotExistResult.Successful;
        }

        /// <summary>
        /// ID is correct for this DataBase?
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>true if ID is correct</returns>
        public bool IsCorrectID(string id)
        {
            return !id.IsWhiteSpace();
        }
        #endregion // Base

        #region DatabaseWork

        /// <summary>
        /// Is mod exist?
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <returns>true if mod is exist, false if not</returns>
        public bool IsExist(string id)
        {
            return GetIndexOf(id) != -1;
        }

        /// <summary>
        /// Get list of mods' id (with shadow banned mod)
        /// </summary>
        /// <returns>list of mods' id</returns>
        public string[] GetFullListOfIDMods()
        {
            return (from mod in Database select mod.Id).ToArray();
        }

        /// <summary>
        /// Get list of mods' id (not shadow banned mod)
        /// </summary>
        /// <returns>list of mods' id</returns>
        public string[] GetListOfIDMods()
        {
            return (from mod in Database where mod.Status != ModStatus.ShadowBanned select mod.Id).ToArray();
        }

        /// <summary>
        /// Check status of mod (Active/Ban/Shadow ban)
        /// </summary>
        /// <param name="id">ID of mod</param>
        /// <param name="status">Status of mod <see cref="ModStatus"/></param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
        public IsNotExistResult CheckStatusMod(string id, out ModStatus status)
        {
            status = ModStatus.Active;
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            int find = GetIndexOf(id);
            if (find == -1) return IsNotExistResult.IsNotExist;
            status = Database[find].Status;
            return IsNotExistResult.Successful;
        }

        /// <summary>
        /// Create new mod in database
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="name">Name of mod</param>
        /// <param name="description">Description of mod</param>
        /// <param name="author">Author of mod</param>
        /// <param name="version">Version of mod</param>
        /// <param name="minecraftVersion">Range of Minecraft's versions</param>
        /// <param name="isJavaMod">is java mod? else bedrock mod</param>
        /// <param name="rank">Rank of mod</param>
        /// <param name="tags">List of mod's tags</param>
        /// <returns>Status of work <see cref="IsExistResult"/></returns>
        public IsExistResult Create(string id, string name, string description, string author, EntityVersion version, ModMinecraftVersion minecraftVersion, bool isJavaMod, int rank, List<string> tags)
        {
            if (!IsCorrectID(id)) return IsExistResult.NotID;
            if (IsExist(id)) return IsExistResult.IsExist;
            Database.Add(new(id, name, description, author, version, minecraftVersion, isJavaMod, rank, tags));
            return IsExistResult.Successful;
        }

        /// <summary>
        /// Delete mod from database
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
        public IsNotExistResult Delete(string id)
        {
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            int find = GetIndexOf(id);
            if (find == -1) return IsNotExistResult.IsNotExist;
            Database.RemoveAt(find);
            return IsNotExistResult.Successful;
        }

        /// <summary>
        /// Read mod from database
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="mod">const JSON object of mod</param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
        public IsNotExistResult Read(string id, out Dictionary<string, object> mod)
        {
            mod = null;
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            int find = GetIndexOf(id);
            if (find == -1) return IsNotExistResult.IsNotExist;
            mod = Database[find].ToJSON();
            return IsNotExistResult.Successful;
        }

        /// <summary>
        /// Update mod from database
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="name">Name of mod</param>
        /// <param name="description">Description of mod</param>
        /// <param name="author">Author of mod</param>
        /// <param name="version">Version of mod</param>
        /// <param name="rank">Rank of mod</param>
        /// <param name="tags">List of mod's tags</param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
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
                mod.Tags = tags ?? mod.Tags;
                return IsNotExistResult.Successful;
            }
            return IsNotExistResult.IsNotExist;
        }

        /// <summary>
        /// Mod has this tag?
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="tag">tag</param>
        /// <param name="result">has tag?</param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
        public IsNotExistResult HasTag(string id, string tag, out bool result)
        {
            result = false;
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            if (GetMod(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                if (mod.Tags.IndexOf(tag) != -1) result = true;
                return IsNotExistResult.Successful;
            }
            return IsNotExistResult.IsNotExist;
        }

        /// <summary>
        /// Add new tag to mod
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="tag">new tag</param>
        /// <returns>Status of work <see cref="HasTagResult"/></returns>
        public HasTagResult AddTag(string id, string tag)
        {
            if (!IsCorrectID(id)) return HasTagResult.NotID;
            if (GetMod(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                if (mod.Tags.IndexOf(tag) != -1) return HasTagResult.HasTag;
                mod.Tags.Add(tag);
                return HasTagResult.Successful;
            }
            return HasTagResult.IsNotExist;
        }

        /// <summary>
        /// Remove tag from mod
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="tag">old tag</param>
        /// <returns>Status of work <see cref=" HasNotTagResult"/></returns>
        public HasNotTagResult RemoveTag(string id, string tag)
        {
            if (!IsCorrectID(id)) return HasNotTagResult.NotID;
            if (GetMod(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                if (mod.Tags.Remove(tag)) return HasNotTagResult.Successful;
                return HasNotTagResult.HasNotTag;
            }
            return HasNotTagResult.IsNotExist;
        }

        /// <summary>
        /// Get list of mods with this tag
        /// </summary>
        /// <param name="tag">tag</param>
        /// <param name="mods">result list of mods</param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
        public IsNotExistResult GetAllModsWithTag(string tag, out string[] mods)
        {
            List<string> result = new();
            for (int i = 0; i < Database.Count; i++)
            {
                var mod = Database[i];
                if (mod.Status != ModStatus.ShadowBanned && mod.Tags.IndexOf(tag) != -1) result.Add(mod.Id);
            }
            mods = result.ToArray();
            if (mods.Length == 0) return IsNotExistResult.IsNotExist;
            return IsNotExistResult.Successful;
        }

        /// <summary>
        /// Get all tags of mod
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="result">result list of tags</param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
        public IsNotExistResult GetAllTags(string id, out string[] result)
        {
            result = [];
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            if (GetMod(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                result = mod.Tags.ToArray();
                return IsNotExistResult.Successful;
            }
            return IsNotExistResult.IsNotExist;
        }

        /// <summary>
        /// Get mod as string
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="result">result mod info as string</param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
        public IsNotExistResult GetStringMod(string id, out string result)
        {
            result = "EMPTY";
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            int find = GetIndexOf(id);
            if (find == -1) return IsNotExistResult.IsNotExist;
            result = Database[find].ToString();
            return IsNotExistResult.Successful;
        }

        /// <summary>
        /// Checks whether this mod is compatible with the current version of Minecraft. 
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="version">version of minecraft</param>
        /// <param name="result">result. Mod is compatible?</param>
        /// <returns>Status of work <see cref="IsNotExistResult"/></returns>
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

        /// <summary>
        /// Change the mod's Minecraft version to a more up‑to‑date one. And update id style for new versions
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <param name="version">Range of new minecraft's versions </param>
        /// <param name="newId">The new mod ID (or the old one, if it hasn’t changed)</param>
        /// <returns>Status of work <see cref="IsNotCorrectVersionResult"/></returns>
        public IsNotCorrectVersionResult ChangeMinecraftVersionForMod(string id, ModMinecraftVersion version, out string newId)
        {
            newId = id;
            if (!IsCorrectID(id)) return IsNotCorrectVersionResult.NotID;
            if (GetMod(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                if (mod.MinecraftVersion.First > version.First || mod.MinecraftVersion.Last > version.Last) return IsNotCorrectVersionResult.NoCorrectVersion;
                mod.MinecraftVersion = version;
                string _id = MinecraftMod.FormatID(id, version.First);
                string nid = _id;
                int i = 1;
                while (_id != id && IsExist(nid))
                {
                    nid = _id + i.ToString();
                    i++;
                }
                mod.Id = nid;
                newId = nid;
                return IsNotCorrectVersionResult.Successful;
            }
            return IsNotCorrectVersionResult.IsNotExist;
        }

        /// <summary>
        /// Ban mod. Update description and tags.
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <returns>Status of work <see cref="IsBanResult"/></returns>
        public IsBanResult BanMod(string id)
        {
            if (!IsCorrectID(id)) return IsBanResult.NotID;
            if (GetMod(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                if (mod.Status == ModStatus.Banned) return IsBanResult.IsBan;
                mod.Status = ModStatus.Banned;
                mod.Description = "MOD WAS BANNED\nIF YOU DEVELOPER TRY CONTACT WITH US\nXXXXXXXX@gmail.com";
                mod.Tags.Clear();
                return IsBanResult.Successful;
            }
            return IsBanResult.IsNotExist;
        }

        /// <summary>
        /// Shadow ban mod.
        /// </summary>
        /// <param name="id">id of mod</param>
        /// <returns>Status of work <see cref="IsBanResult"/></returns>
        public IsBanResult ShadowBan(string id)
        {
            if (!IsCorrectID(id)) return IsBanResult.NotID;
            if (GetMod(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                if (mod.Status == ModStatus.ShadowBanned) return IsBanResult.IsBan;
                mod.Status = ModStatus.ShadowBanned;
                return IsBanResult.Successful;
            }
            return IsBanResult.IsNotExist;
        }
        #endregion // DatabaseWork
    }
}

