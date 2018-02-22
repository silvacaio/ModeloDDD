using ModeloDDD.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ModeloDDD.Domain.Interfaces
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        //IQueryable<Produto> BuscarPorNome(string nome);
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
