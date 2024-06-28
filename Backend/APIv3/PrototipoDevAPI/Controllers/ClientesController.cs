using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrototipoDevAPI.DatabaseContext;
using PrototipoDevAPI.Services;

namespace PrototipoDevAPI.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClienteService _clienteService;

        public ClientesController(ILogger<HomeController> logger, ClienteService clienteService)
        {
            _logger = logger;
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
