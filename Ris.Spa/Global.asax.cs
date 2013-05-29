﻿using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
﻿using Ris.Services;
﻿using Ris.Services.IoC;
﻿using Ris.Services.Quartz;
﻿using Rs.Dnevnik.Ris.EntityFramework;
﻿using Rs.Dnevnik.Ris.EntityFramework.Repositories;
﻿using Rs.Dnevnik.Ris.Interfaces.Repositories;
﻿using Rs.Dnevnik.Ris.Interfaces.Services;

namespace Ris.Spa
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //ValueProviderFactories.Factories.Add(new JsonValueProviderFactory());
            Container.Default.Bind<IRepositoryFactory, RepositoryFactory>();
            Container.Default.Bind<ISchedulerService, SchedulerService>();
            Container.Default.Bind<IPop3Service, OpenPopService>();
            Container.Default.Bind<ITextKonvertor, TextKonvertor>();
            
            new Bootstrapper().Start();
            
            var scheduler = Container.Default.GetInstance<ISchedulerService>();
            scheduler.Run();

            
        }
    }
}