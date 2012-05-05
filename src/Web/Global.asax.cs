namespace BeerConf.Web
{
    using System.Web.Hosting;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Application.Infrastructure;

    using Brandy.Web;

    using Migrations;
    using MvcExtensions;
    using MvcExtensions.Windsor;

    public class MvcApplication : WindsorMvcApplication
    {
        public MvcApplication()
        {
            Bootstrapper.BootstrapperTasks
                .Include<RegisterModelMetadata>()
                .Include<RegisterControllers>()
                .Include<RegisterMappings>()/*
                         .Include<ConfigureFilterAttributes>()
                         .Include<ConfigureModelBinders>()*/
                /*.Include<RegisterMapProfiles>()
				.Include<RegisterRoutes>()*/;
        }

        private static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }

        protected override void OnStart()
        {
            MigrationsRunner.Run();

            AreaRegistration.RegisterAllAreas();

            var pathProvider = new EmbeddedResourceVirtualPathProvider();
            pathProvider.AddNamespaceMapping("/Views/Account", "Brandy.Security.Web.Views.Account");
            HostingEnvironment.RegisterVirtualPathProvider(pathProvider);

            RegisterGlobalFilters(GlobalFilters.Filters);

            RegisterRoutes(RouteTable.Routes);
        }
    }
}
