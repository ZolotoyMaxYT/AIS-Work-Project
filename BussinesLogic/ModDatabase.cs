using BussinesLogic.Classes;
using BussinesLogic.Interfaces;
using DataAccessLayer;
using Model;

namespace BussinesLogic
{

    /// <summary>
    /// All logic for work with Minecraft mods database
    /// </summary>
    public class ModDatabase : IModDatabase
    {
        protected IRepository<MinecraftMod> Database;

        public IBasicModDatabase BasicModDatabase { get; private set; }

        public IModDatabaseCRUDManager CRUDManager { get; private set; }

        public IModDatabaseTagManager TagManager { get; private set; }

        public IModDatabaseBanManager BanManager { get; private set; }

        public IModDatabaseMinecraftVersionManager MinecraftVersionManager { get; private set; }

        public IModDatabaseModListManager ModListManager { get; private set; }

        public ModDatabase(
            IRepository<MinecraftMod> database,
            IBasicModDatabase basicModDatabase,
            IModDatabaseCRUDManager databaseCRUDManager,
            IModDatabaseMinecraftVersionManager databaseMinecraftVersionManager,
            IModDatabaseModListManager databaseModListManager,
            IModDatabaseBanManager databaseBanManager,
            IModDatabaseTagManager databaseTagManager)
        {
            Database = database;
            BasicModDatabase = basicModDatabase;
            CRUDManager = databaseCRUDManager;
            MinecraftVersionManager = databaseMinecraftVersionManager;
            ModListManager = databaseModListManager;
            BanManager = databaseBanManager;
            TagManager = databaseTagManager;
        }

        #region BasicModDatabase

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

        #region BanManager
        public IsBanResult BanMod(string id)
        {
            return BanManager.BanMod(id);
        }
        public IsBanResult ShadowBan(string id)
        {
            return BanManager.ShadowBan(id);
        }
        public IsNotExistResult CheckStatusMod(string id, out ModStatus status)
        {
            return BanManager.CheckStatusMod(id, out status);
        }
        #endregion

        #region TagManager
        public HasTagResult AddTag(string id, string tag)
        {
            return TagManager.AddTag(id, tag);
        }
        public IsNotExistResult GetAllModsWithTag(string tag, out string[] mods)
        {
            return TagManager.GetAllModsWithTag(tag, out mods);
        }
        public IsNotExistResult GetAllTags(string id, out string[] result)
        {
            return TagManager.GetAllTags(id, out result);
        }
        public IsNotExistResult HasTag(string id, string tag, out bool result)
        {
            return TagManager.HasTag(id, tag, out result);
        }
        public HasNotTagResult RemoveTag(string id, string tag)
        {
            return TagManager.RemoveTag(id, tag);
        }
        #endregion

        #region CRUDManager
        public IsExistResult Create(string id, string name, string description, string author, EntityVersion version, ModMinecraftVersion minecraftVersion, bool isJavaMod, int rank, List<string> tags)
        {
            return CRUDManager.Create(id, name, description, author, version, minecraftVersion, isJavaMod, rank, tags);
        }
        public IsNotExistResult Delete(string id)
        {
            return CRUDManager.Delete(id);
        }
        public IsNotExistResult Read(string id, out Dictionary<string, object> mod)
        {
            return CRUDManager.Read(id, out mod);
        }
        public IsNotExistResult Update(string id, string? name = null, string? description = null, string? author = null, EntityVersion? version = null, int? rank = null, List<string>? tags = null)
        {
            return CRUDManager.Update(id, name, description, author, version, rank, tags);
        }
        #endregion

        #region ModListManager
        public string[] GetFullListOfIDMods()
        {
            return ModListManager.GetFullListOfIDMods();
        }
        public string[] GetListOfIDMods()
        {
            return ModListManager.GetListOfIDMods();
        }
        #endregion

        #region MinecraftVersionManager
        public IsNotCorrectVersionResult ChangeMinecraftVersionForMod(string id, ModMinecraftVersion version, out string newId)
        {
            return MinecraftVersionManager.ChangeMinecraftVersionForMod(id, version, out newId);
        }
        public IsNotExistResult IsCorrectForMinecraftVersion(string id, EntityVersion version, out bool result)
        {
            return MinecraftVersionManager.IsCorrectForMinecraftVersion(id, version, out result);
        }
        #endregion
    }
}

