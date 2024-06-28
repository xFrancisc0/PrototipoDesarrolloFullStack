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

        // Ruta para clientes usando LINQ
        [HttpGet]
        [Route("Linq")]
        public async Task<IActionResult> GetClientesLINQ()
        {
            var clientes = await _clienteService.GetClientesConLINQ();
            return Ok(clientes);
        }

        // Ruta para clientes usando Stored Procedure (SP)
        [HttpGet]
        [Route("SP")]
        public async Task<IActionResult> GetClientesSP()
        {
            var clientes = await _clienteService.GetClientesConSP();
            return Ok(clientes);
        }
    }
}
