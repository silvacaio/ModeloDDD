using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using ModeloDDD.Application;
using ModeloDDD.Application.Interfaces;
using ModeloDDD.Domain.Interfaces.Repositories;
using ModeloDDD.Domain.Interfaces.Services;
using ModeloDDD.Domain.Services;
using ModeloDDD.Infra.Data.Repositories;
using ModeloDDD.MVC.App_Start;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using System;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]


namespace ModeloDDD.MVC.App_Start
{
    public class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }

        //O correto é criar um modulo/outra camada pra IOC
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IClienteAppService>().To<ClienteAppService>();
            kernel.Bind<IProdutoAppService>().To<ProdutoAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IClienteService>().To<ClienteService>();
            kernel.Bind<IProdutoService>().To<ProdutoService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IClienteRepository>().To<ClienteRepository>();
            kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();
        }
    }
}