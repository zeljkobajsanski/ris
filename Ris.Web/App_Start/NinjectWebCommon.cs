using Ris.Services;
using Rs.Dnevnik.Ris.EntityFramework.Repositories;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using Rs.Dnevnik.Ris.Interfaces.Services;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Ris.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Ris.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Ris.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IRepositoryFactory>().To<RepositoryFactory>();
            kernel.Bind<ITextKonvertor>().To<TextKonvertor>();
            kernel.Bind<Rs.Dnevnik.Ris.Interfaces.IBootstrapper>().To<Rs.Dnevnik.Ris.EntityFramework.Bootstrapper>();

        } 
       
        public static IRepositoryFactory GetRepositoryFactory()
        {
            return bootstrapper.Kernel.Get<IRepositoryFactory>();
        }

        public static Rs.Dnevnik.Ris.Interfaces.IBootstrapper GetBootstrapper()
        {
            return bootstrapper.Kernel.Get<Rs.Dnevnik.Ris.Interfaces.IBootstrapper>();
        }
    }
}
