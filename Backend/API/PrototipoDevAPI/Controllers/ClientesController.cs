using Microsoft.AspNetCore.Mvc;
using PrototipoDevAPI.Services;

namespace PrototipoDevAPI.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientesPaginados(int pageNumber = 1, int pageSize = 10)
        {
            var clientes = await _clienteService.GetClientesPaginadosConEFCoreAsync(pageNumber, pageSize);
            return Ok(clientes);
        }

        // Otros endpoints y métodos relacionados con clientes
    }
}