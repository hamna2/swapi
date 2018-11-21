using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using SwapiApiChallenge.Interfaces;

namespace SwapiApiChallenge.Common
{
    public static class NinjectServiceBinder
    {
        private static StandardKernel _kernel;


        public static void RegisterServices()

        {
            _kernel = new StandardKernel();
            _kernel.Bind<ISwapiOrchestrator>().To<SwapiOrchestrator>();
            _kernel.Bind<ISwapiServiceProxy>().To<ServiceProxy>();
            _kernel.Bind<IShipTransformer>().To<ShipTransformer>();
            _kernel.Bind<IAppConfigReader>().To<AppConfigReader>();
            _kernel.Bind<IConsumableConverter>().To<ConusmableConverter>();
            _kernel.Bind<IStarShipConsumableAggregartion>().To<StarShipConsumableAggregartion>();
            _kernel.Bind<ShipModel>().ToSelf();



        }

        public static T Resolve<T>()
        {

            return _kernel.Get<T>();
        }

    }
}