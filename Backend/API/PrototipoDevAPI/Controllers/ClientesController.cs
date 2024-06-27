using Microsoft.AspNetCore.Mvc;
using PrototipoDevAPI.Data.Entities;
using PrototipoDevAPI.Services;
using PrototipoDevAPI.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrototipoDevAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesController _clientesService;

        public ClientesController(ClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        [HttpGet("GetClientesPaginadosEF")]
        public async Task<ActionResult<List<Cliente>>> GetClientesPaginadosEF(int pageNumber, int pageSize)
        {
            var clientes = await _clientesService.GetClientesPaginadosAsync(pageNumber, pageSize);
            return Ok(clientes);
        }

        // Aquí puedes agregar otro endpoint para el stored procedure si lo deseas
    }
}