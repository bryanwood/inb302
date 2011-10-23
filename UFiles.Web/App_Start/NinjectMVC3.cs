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
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IRepository<File>>().To<Repository<File>>();
            
            kernel.Bind<IRepository<Event>>().To<Repository<Event>>();
            kernel.Bind<IRepository<Group>>().To<Repository<Group>>();
            kernel.Bind<IRepository<IPAddress>>().To<Repository<IPAddress>>();
            kernel.Bind<IRepository<Location>>().To<Repository<Location>>();
            kernel.Bind<IRepository<Restriction>>().To<Repository<Restriction>>();
            kernel.Bind<IRepository<Role>>().To<Repository<Role>>();
            kernel.Bind<IRepository<TimeRange>>().To<Repository<TimeRange>>();
            kernel.Bind<IRepository<Transmittal>>().To<Repository<Transmittal>>();
            kernel.Bind<IRepository<User>>().To<Repository<User>>();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IGroupService>().To<GroupService>();
            kernel.Bind<ITransmittalService>().To<TransmittalService>();
        }
        private static void OnApplicationStarted()
        {
            bootstrapper.Kernel.Inject(Membership.Provider);
            bootstrapper.Kernel.Inject(Roles.Provider);
        }
    }
}
