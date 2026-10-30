using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace BussinesLogic
{
    /// <summary>
    /// Interface for all basic MinecraftModList logic of ModDatabase
    /// </summary>
    public interface IModDatabaseModListManager : IBasicModDatabase
    {
        /// <summary>
        /// Get list of mods' id (with shadow banned mod)
        /// </summary>
        /// <returns>list of mods' id</returns>
        public string[] GetFullListOfIDMods();

        /// <summary>
        /// Get list of mods' id (not shadow banned mod)
        /// </summary>
        /// <returns>list of mods' id</returns>
        public string[] GetListOfIDMods();
    }
}
