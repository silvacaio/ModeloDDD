using ModeloDDD.Domain.Entities;
using ModeloDDD.Domain.Interfaces.Repositories;

namespace ModeloDDD.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
    }
}
