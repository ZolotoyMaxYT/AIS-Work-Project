using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Interfaces
{
    public interface IModDatabase : IModDatabaseCRUDManager, IModDatabaseTagManager, IModDatabaseMinecraftVersionManager, IModDatabaseBanManager, IModDatabaseModListManager
    {
        /// <summary>
        /// CRUD functions for ModDatabase
        /// </summary>
        public IModDatabaseCRUDManager CRUDManager { get; }

        /// <summary>
        /// Tag functions for ModDatabase
        /// </summary>
        public IModDatabaseTagManager TagManager { get; }

        /// <summary>
        /// Ban functions for ModDatabase
        /// </summary>
        public IModDatabaseBanManager BanManager { get; }

        /// <summary>
        /// MinecraftVersion functions for ModDatabase
        /// </summary>
        public IModDatabaseMinecraftVersionManager MinecraftVersionManager { get; }

        /// <summary>
        /// ModList functions for ModDatabase
        /// </summary>
        public IModDatabaseModListManager ModListManager { get; }
    }
}
