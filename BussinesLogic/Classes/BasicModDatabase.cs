using BussinesLogic.Interfaces;
using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Classes
{
    public class BasicModDatabase : IBasicModDatabase
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

        public BasicModDatabase(IRepository<MinecraftMod> database)
        {
            Database = database;
        }

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

        public bool IsExist(string id)
        {
            if (Database is IRepositoryIsExist<MinecraftMod> database) return database.IsExist(id);
            return Database.ReadByID(id) is not null;
        }

        public bool IsCorrectID(string id)
        {
            return !id.IsWhiteSpace();
        }
    }
}
