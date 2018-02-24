using ModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ModeloDDD.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        //IQueryable<Produto> BuscarPorNome(string nome);
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
