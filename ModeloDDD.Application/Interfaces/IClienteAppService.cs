using ModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ModeloDDD.Application.Interfaces
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais();
    }
}
