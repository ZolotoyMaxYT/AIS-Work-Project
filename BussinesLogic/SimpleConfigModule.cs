using BussinesLogic.Classes;
using BussinesLogic.Interfaces;
using DataAccessLayer;
using Model;
using Ninject.Modules;

namespace BussinesLogic
{
    /// <summary>
    /// IoC container? config for Ninject
    /// </summary>
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            // Repository bind
            Bind<IRepository<MinecraftMod>>().To<DapperRepository>().InSingletonScope();
            //Bind<IRepository<MinecraftMod>>().To<EntityRepository>().InSingletonScope();

            // ModDatabase bind
            Bind<IBasicModDatabase>().To<BasicModDatabase>().InSingletonScope();
            Bind<IModDatabaseBanManager>().To<ModDatabaseBanManager>().InSingletonScope();
            Bind<IModDatabaseCRUDManager>().To<ModDatabaseCRUDManager>().InSingletonScope();
            Bind<IModDatabaseMinecraftVersionManager>().To<ModDatabaseMinecraftVersionManager>().InSingletonScope();
            Bind<IModDatabaseModListManager>().To<ModDatabaseModListManager>().InSingletonScope();
            Bind<IModDatabaseTagManager>().To<ModDatabaseTagManager>().InSingletonScope();
            Bind<IModDatabase>().To<ModDatabase>().InSingletonScope();
        }
    }
}
