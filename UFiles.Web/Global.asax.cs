using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using Ninject;
using Ninject.Infrastructure;
using Ninject.Extensions.Wcf;
using System.ServiceModel;

namespace UFiles.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class UFilesWebApp : System.Web.HttpApplication, IHaveKernel
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
        protected IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel(new UFilesModule());
            return kernel;
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Overview", id = UrlParameter.Optional }, // Parameter defaults,
                  new string[]{"UFiles.Web.Controllers"}
            );

        }

        protected void Application_Start()
        {
            Database.SetInitializer<UFiles.Domain.Concrete.UFileContext>(new UFiles.Domain.Entities.UFileInitializer());

            lock(this){
                kernel = CreateKernel();
                KernelContainer.Kernel = Kernel;
                RegisterCustomBehavior();
            }

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
        protected virtual void RegisterCustomBehavior()
        {
            if (kernel.GetBindings(typeof(ServiceHost)).Count() == 0)
            {
                kernel.Bind<ServiceHost>().To<NinjectServiceHost>();
            }
        }
        
        private static IKernel kernel;
        public IKernel Kernel
        {
            get { return kernel; }
        }
    }
}