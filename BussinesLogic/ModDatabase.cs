using Entity;

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
    public enum InModPackResult
    {
        NotID,
        IsNotExist,
        InModPack,
        Successful
    }
    public enum NotInModPackResult
    {
        NotID,
        IsNotExist,
        NotInModPack,
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
        public int IndexOf(string id)
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
        /// Is mod exist?
        /// </summary>
        /// <returns>true if mod is exist, false if not</returns>
        public bool Has(string id)
        {
            return IndexOf(id) != -1;
        }

        /// <summary>
        /// Get list of mods' id
        /// </summary>
        /// <returns>list of mods' id</returns>
        public string[] ListOfIDMods()
        {
            return (from mod in Database select mod.Id).ToArray();
        }
        /// <summary>
        /// Get list of mods
        /// </summary>
        /// <returns>list of mods</returns>
        public MinecraftMod[] ListOfMods()
        {
            return (from mod in Database select mod).ToArray();
        }

        public bool IsCorrectID(string id)
        {
            return !id.IsWhiteSpace();
        }
        #endregion // Base

        #region DatabaseWork

        /// <summary>
        /// Create new mod in database
        /// </summary>
        /// <returns></returns>
        public IsExistResult Create(string id, string name, string description, string author, ModVersion version, bool isJavaMod, int rank, List<string> modPacks)
        {
            if (!IsCorrectID(id)) return IsExistResult.NotID;
            if (Has(id)) return IsExistResult.IsExist;
            Database.Add(new(id, name, description, author, version, isJavaMod, rank, modPacks));
            return IsExistResult.Successful;
        }

        /// <summary>
        /// Delete mod from database
        /// </summary>
        /// <returns></returns>
        public IsNotExistResult Delete(string id)
        {
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            int find = IndexOf(id);
            if (find == -1) return IsNotExistResult.IsNotExist;
            Database.RemoveAt(find);
            return IsNotExistResult.Successful;
        }

        /// <summary>
        /// Read mod from database
        /// </summary>
        /// <returns></returns>
        public IsNotExistResult Read(string id, out MinecraftMod mod)
        {
            mod = null;
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            int find = IndexOf(id);
            if (find == -1) return IsNotExistResult.IsNotExist;
            mod = Database[find];
            return IsNotExistResult.Successful;
        }

        /// <summary>
        /// Update mod from database
        /// </summary>
        /// <returns></returns>
        public IsNotExistResult Update(string id, string? name = null, string? description = null, string? author = null, ModVersion? version = null, int? rank = null, List<string>? modPacks = null)
        {
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            if (Read(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                mod.Name = name ?? mod.Name;
                mod.Description = description ?? mod.Description;
                mod.Author = author ?? mod.Author;
                mod.Version = version ?? mod.Version;
                mod.Rank = rank ?? mod.Rank;
                mod.ModPacks = modPacks ?? mod.ModPacks;
                return IsNotExistResult.Successful;
            }
            return IsNotExistResult.IsNotExist;
        }

        public IsNotExistResult InModPack(string id, string modPack, out bool result)
        {
            result = false;
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            if (Read(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                if (mod.ModPacks.IndexOf(modPack) != -1) result = true;
                return IsNotExistResult.Successful;
            }
            return IsNotExistResult.IsNotExist;
        }
        public InModPackResult AddToModPack(string id, string modPack)
        {
            if (!IsCorrectID(id)) return InModPackResult.NotID;
            if (Read(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                if (mod.ModPacks.IndexOf(modPack) != -1) return InModPackResult.InModPack;
                mod.ModPacks.Add(modPack);
                return InModPackResult.Successful;
            }
            return InModPackResult.IsNotExist;
        }
        public NotInModPackResult RemoveFromModPack(string id, string modPack)
        {
            if (!IsCorrectID(id)) return NotInModPackResult.NotID;
            if (Read(id, out MinecraftMod mod) == IsNotExistResult.Successful)
            {
                if (mod.ModPacks.Remove(modPack)) return NotInModPackResult.Successful;
                return NotInModPackResult.NotInModPack;
            }
            return NotInModPackResult.IsNotExist;
        }
        public IsNotExistResult GetAllModsFromModPack(string modPack, out MinecraftMod[] mods)
        {
            List<MinecraftMod> result = new();
            for (int i = 0; i < Database.Count; i++)
            {
                var mod = Database[i];
                if (mod.ModPacks.IndexOf(modPack) != -1) result.Add(mod);
            }
            mods = result.ToArray();
            if (mods.Length == 0) return IsNotExistResult.IsNotExist;
            return IsNotExistResult.Successful;
        }
        #endregion // DatabaseWork
    }
}

