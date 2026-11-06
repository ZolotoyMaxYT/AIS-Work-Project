using BussinesLogic.Interfaces;
using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace BussinesLogic.Classes
{
    public class ModDatabaseModListManager : IModDatabaseModListManager
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
        public ModDatabaseModListManager(IRepository<MinecraftMod> database, IBasicModDatabase basicModDatabase)
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

        public string[] GetFullListOfIDMods()
        {
            return (from mod in Database.ReadAll() select mod.Id).ToArray();
        }

        public string[] GetListOfIDMods()
        {
            return (from mod in Database.ReadAll() where mod.Status != ModStatus.ShadowBanned select mod.Id).ToArray();
        }
    }
}
