using ModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ModeloDDD.Application.Interfaces
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
