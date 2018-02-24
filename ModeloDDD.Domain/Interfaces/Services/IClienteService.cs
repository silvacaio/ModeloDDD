using ModeloDDD.Domain.Entities;
using ModeloDDD.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ModeloDDD.Domain.Interfaces.Repositories
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes);
    }
}
