using System.Collections.Generic;
using System.Linq;
using ModeloDDD.Domain.Entities;
using ModeloDDD.Domain.Interfaces.Repositories;

namespace ModeloDDD.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> BuscarPorNome(string nome) =>
             _context.Produtos.Where(p => p.Nome == nome);
    }
}
