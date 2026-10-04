namespace BussinesLogic
{
    public enum IsExistResult
    {
        NotID,
        IsExist,
        Successful
    }
    public enum IsNotExistResult
    {
        NotID,
        IsNotExist,
        Successful
    }
    public enum HasTagResult
    {
        NotID,
        IsNotExist,
        HasTag,
        Successful
    }
    public enum HasNotTagResult
    {
        NotID,
        IsNotExist,
        HasNotTag,
        Successful
    }
    public enum IsNotCorrectVersionResult
    {
        NotID,
        IsNotExist,
        NoCorrectVersion,
        Successful
    }
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
        /// Read mod from database
        /// </summary>
        /// <returns></returns>
        private IsNotExistResult GetMod(string id, out MinecraftMod mod)
        {
            mod = null;
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            int find = GetIndexOf(id);
            if (find == -1) return IsNotExistResult.IsNotExist;
            mod = Database[find];
            return IsNotExistResult.Successful;
        }

        public bool IsCorrectID(string id)
        {
            return !id.IsWhiteSpace();
        }
        #endregion // Base

        #region DatabaseWork

        /// <summary>
        /// Is mod exist?
        /// </summary>
        /// <returns>true if mod is exist, false if not</returns>
        public bool IsExist(string id)
        {
            return GetIndexOf(id) != -1;
        }

        /// <summary>
        /// Get list of mods' id
        /// </summary>
        /// <returns>list of mods' id</returns>
        public string[] GetListOfIDMods()
        {
            return (from mod in Database select mod.Id).ToArray();
        }

        /// <summary>
        /// Create new mod in database
        /// </summary>
        /// <returns></returns>
        public IsExistResult Create(string id, string name, string description, string author, EntityVersion version, MinecraftVersion minecraftVersion, bool isJavaMod, int rank, List<string> tags)
        {
            if (!IsCorrectID(id)) return IsExistResult.NotID;
            if (IsExist(id)) return IsExistResult.IsExist;
            Database.Add(new(id, name, description, author, version, minecraftVersion, isJavaMod, rank, tags));
            return IsExistResult.Successful;
        }

        /// <summary>
        /// Delete mod from database
        /// </summary>
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <returns></returns>
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
        public IsNotExistResult GetAllModsWithTag(string tag, out string[] mods)
        {
            List<string> result = new();
            for (int i = 0; i < Database.Count; i++)
            {
                var mod = Database[i];
                if (mod.Tags.IndexOf(tag) != -1) result.Add(mod.Id);
            }
            mods = result.ToArray();
            if (mods.Length == 0) return IsNotExistResult.IsNotExist;
            return IsNotExistResult.Successful;
        }
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
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// Change the mod's Minecraft version to a more up‑to‑date one.
        /// </summary>
        /// <returns></returns>
        public IsNotCorrectVersionResult ChangeMinecraftVersionForMod(string id, MinecraftVersion version)
        {
            if (!IsCorrectID(id)) return IsNotCorrectVersionResult.NotID;
            if (GetMod(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                if (mod.MinecraftVersion.First > version.First || mod.MinecraftVersion.Last > version.Last) return IsNotCorrectVersionResult.NoCorrectVersion;
                mod.MinecraftVersion = version;
                return IsNotCorrectVersionResult.Successful;
            }
            return IsNotCorrectVersionResult.IsNotExist;
        }
        #endregion // DatabaseWork
    }
}

