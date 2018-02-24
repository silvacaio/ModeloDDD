using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;
using ModeloDDD.Infra.CrossCutting.Ioc;
using ModeloDDD.MVC.App_Start;
using WebActivatorEx;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitialize), "Initialize")]


namespace ModeloDDD.MVC.App_Start
{
    public static class SimpleInjectorInitialize
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();

            DependencyResolver.SetResolver(
               new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}