using BussinesLogic.Interfaces;
using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace BussinesLogic.Classes
{
    public class ModDatabaseCRUDManager : IModDatabaseCRUDManager
    {
        #region Protected
        /// <summary>
        /// Repository of mods <br/>
        /// </summary>
        protected IRepository<MinecraftMod> Database;

        /// <summary>
        /// Get list of mods
        /// </summary>
        /// <returns>list of mods</returns>
        protected MinecraftMod[] GetListOfMods()
        {
            return (from mod in Database.ReadAll() select mod).ToArray();
        }

        /// <summary>
        /// Get mod from database
        /// </summary>
        /// <returns>Mod</returns>
        protected IsNotExistResult GetMod(string id, out MinecraftMod mod)
        {
            mod = null;
            if (!IsCorrectID(id)) return IsNotExistResult.NotID;
            var find = Database.ReadByID(id);
            if (find is null) return IsNotExistResult.IsNotExist;
            mod = find;
            return IsNotExistResult.Successful;
        }

        #endregion 
        public ModDatabaseCRUDManager(IRepository<MinecraftMod> database, IBasicModDatabase basicModDatabase)
        {
            Database = database;
            BasicModDatabase = basicModDatabase;
        }

        #region BasicModDatabase
        public IBasicModDatabase BasicModDatabase { get; private set; }

        public IsNotExistResult GetStringMod(string id, out string result)
        {
            return BasicModDatabase.GetStringMod(id, out result);
        }

        public bool IsCorrectID(string id)
        {
            return BasicModDatabase.IsCorrectID(id);
        }

        public bool IsExist(string id)
        {
            return BasicModDatabase.IsExist(id);
        }
        #endregion

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
    }
}
