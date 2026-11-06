using BussinesLogic.Interfaces;
using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Classes
{
    public class ModDatabaseMinecraftVersionManager : IModDatabaseMinecraftVersionManager
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
        public ModDatabaseMinecraftVersionManager(IRepository<MinecraftMod> database, IBasicModDatabase basicModDatabase)
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
    }
}
