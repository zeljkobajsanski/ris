using System.Web.Mvc;
using System.Web.Routing;
using Ris.Services;
using Ris.Services.IoC;
using Ris.Services.Quartz;
using Ris.Web.App_Start;
using Rs.Dnevnik.Ris.EntityFramework;
using Rs.Dnevnik.Ris.EntityFramework.Repositories;
using Rs.Dnevnik.Ris.Interfaces.Repositories;
using Rs.Dnevnik.Ris.Interfaces.Services;

namespace Ris.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ashx/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
			
			ModelBinders.Binders.DefaultBinder = new DevExpress.Web.Mvc.DevExpressEditorsBinder();
            NinjectWebCommon.GetBootstrapper().Start();
            Container.Default.Bind<IRepositoryFactory, RepositoryFactory>();
            Container.Default.Bind<IPop3Service, OpenPopService>();
            Container.Default.Bind<ISchedulerService, SchedulerService>();
            new Bootstrapper().Start();
            // Start scheduler
            Container.Default.GetInstance<ISchedulerService>().Run();
        }
    }
}