using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic
{
    public interface IModDatabase : IBasicModDatabase, IModDatabaseCRUD, IModDatabaseLogic, IModDatabaseTagManager, IModDatabaseMinecraftVersionManager, IModDatabaseModListManager, IModDatabaseStringUtilities, IModDatabaseBanManager
    {
    }
}
