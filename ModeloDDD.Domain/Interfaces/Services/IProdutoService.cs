using ModeloDDD.Domain.Entities;
using ModeloDDD.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ModeloDDD.Domain.Interfaces.Repositories
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
