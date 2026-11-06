using BussinesLogic.Interfaces;
using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Classes
{
    internal class ModDatabaseTagManager : IModDatabaseTagManager
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
        public ModDatabaseTagManager(IRepository<MinecraftMod> database, IBasicModDatabase basicModDatabase)
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
    }
}
