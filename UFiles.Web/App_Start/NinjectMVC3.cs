[assembly: WebActivator.PreApplicationStartMethod(typeof(UFiles.Web.App_Start.NinjectMVC3), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(UFiles.Web.App_Start.NinjectMVC3), "Stop")]
[assembly: WebActivator.PostApplicationStartMethod(typeof(UFiles.Web.App_Start.NinjectMVC3), "OnApplicationStarted")]

namespace UFiles.Web.App_Start
{
    using System.Reflection;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Mvc;
    using UFiles.Domain.Abstract;
    using UFiles.Domain.Entities;
    using UFiles.Domain.Concrete;
    using System.Web.Security;

    public static class NinjectMVC3 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestModule));
            DynamicModuleUtility.RegisterModule(typeof(HttpApplicationInitializationModule));
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
            var kernel = new StandardKernel(new UFilesModule());
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
           
        }
        private static void OnApplicationStarted()
        {
            bootstrapper.Kernel.Inject(Membership.Provider);
            bootstrapper.Kernel.Inject(Roles.Provider);
        }
    }
}
