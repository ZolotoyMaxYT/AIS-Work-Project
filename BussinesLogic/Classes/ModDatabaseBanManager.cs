using BussinesLogic.Interfaces;
using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace BussinesLogic.Classes
{
    public class ModDatabaseBanManager : IModDatabaseBanManager
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

        public ModDatabaseBanManager(IRepository<MinecraftMod> database, IBasicModDatabase basicModDatabase)
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
    }
}
