using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
//using SimpleInjector;
//using SimpleInjector.Integration.WebApi;
//using SimpleInjector.Lifestyles;

namespace CadastroFuncionario.WebApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfiguration.Configure();

            //Always Json
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            #region SimpleInjector
            //Container container = new Container();
            //container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            //CrossCutting.SimpleInjectorDependencyRegister.Configure(container);
            //container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            //container.Verify();

            //GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            #endregion


            #region Autofac
            ContainerBuilder builder = new ContainerBuilder();

            HttpConfiguration config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterWebApiModelBinderProvider();
            CrossCutting.AutoFacDependencyRegister.Configure(builder);

            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            #endregion
        }
    }
}
