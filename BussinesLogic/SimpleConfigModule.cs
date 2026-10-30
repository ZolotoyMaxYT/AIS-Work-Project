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
            Bind<IRepository<MinecraftMod>>().To<DapperRepository>().InSingletonScope();
            //Bind<IRepository<MinecraftMod>>().To<EntityRepository>().InSingletonScope();
        }
    }
}
