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

        //LINQ
        [HttpGet]
        public async Task<IActionResult> GetClientesLINQ()
        {
            var clientes = await _clienteService.GetClientesConLINQ();
            return Ok(clientes);
        }

        //SP
        [HttpGet]
        public async Task<IActionResult> GetClientesSP()
        {
            var clientes = await _clienteService.GetClientesConSP();
            return Ok(clientes);
        }
    }
}