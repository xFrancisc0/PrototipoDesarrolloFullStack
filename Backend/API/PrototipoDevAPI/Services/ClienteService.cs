using PrototipoDevAPI.Data.Repositories;
using PrototipoDevAPI.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApiProject.Services
{
    public class ClienteService
    {
        private readonly IClientesRepository _clienteRepository;

        public ClienteService(IClientesRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Task<List<Cliente>> GetClientesPaginadosAsync(int pageNumber, int pageSize)
        {
            return _clienteRepository.GetClientesPaginadosAsync(pageNumber, pageSize);
        }
    }
}