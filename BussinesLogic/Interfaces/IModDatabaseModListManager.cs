using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Interfaces
{
    /// <summary>
    /// Interface for all basic ModList logic of ModDatabase
    /// </summary>
    public interface IModDatabaseModListManager : IBasicModDatabase
    {
        /// <summary>
        /// Basic functions for ModDatabase
        /// </summary>
        public IBasicModDatabase BasicModDatabase { get; }

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
