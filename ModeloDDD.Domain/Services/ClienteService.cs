using System.Collections.Generic;
using System.Linq;
using ModeloDDD.Domain.Entities;
using ModeloDDD.Domain.Interfaces.Repositories;

namespace ModeloDDD.Domain.Services
{
    //Servico pega a inteligencia/regra de negocio 
    //e executa algo a fim de retornar os valores solicitados

    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes)
        {
            return clientes.Where(c => c.ClienteEspecial());
        }
    }
}
