using ModeloDDD.Application;
using ModeloDDD.Application.Interfaces;
using ModeloDDD.Domain.Interfaces.Repositories;
using ModeloDDD.Domain.Interfaces.Services;
using ModeloDDD.Domain.Services;
using ModeloDDD.Infra.Data.Repositories;
using SimpleInjector;

namespace ModeloDDD.Infra.CrossCutting.Ioc
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register(typeof(IAppServiceBase<>), new[] { typeof(AppServiceBase<>).Assembly }, Lifestyle.Scoped);
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
            container.Register<IProdutoAppService, ProdutoAppService>(Lifestyle.Scoped);

            container.Register(typeof(IServiceBase<>), new[] { typeof(ServiceBase<>).Assembly }, Lifestyle.Scoped);
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);
            container.Register<IProdutoService, ProdutoService>(Lifestyle.Scoped);

            container.Register(typeof(IRepositoryBase<>), new[] { typeof(RepositoryBase<>).Assembly }, Lifestyle.Scoped);
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
        }
    }
}
