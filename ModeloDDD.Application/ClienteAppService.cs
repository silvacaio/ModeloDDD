using System.Collections.Generic;
using ModeloDDD.Application.Interfaces;
using ModeloDDD.Domain.Entities;
using ModeloDDD.Domain.Interfaces.Repositories;

namespace ModeloDDD.Application
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService)
            : base(clienteService)
        {
            _clienteService = clienteService;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais()
        {
            return _clienteService.ObterClientesEspeciais(_clienteService.GetAll());
        }
    }
}
