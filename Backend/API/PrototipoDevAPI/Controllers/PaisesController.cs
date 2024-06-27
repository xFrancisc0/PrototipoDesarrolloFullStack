using Microsoft.AspNetCore.Mvc;
using PrototipoDevAPI.Services;

namespace PrototipoDevAPI.Controllers
{
    [ApiController]
    [Route("api/paises")]
    public class PaisesController : ControllerBase
    {
        private readonly PaisService _paisService;

        public PaisesController(PaisService paisService)
        {
            _paisService = paisService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaisesPaginados(int pageNumber = 1, int pageSize = 10)
        {
            var paises = await _paisService.GetPaisesPaginadosConEFCoreAsync(pageNumber, pageSize);
            return Ok(paises);
        }

        // Otros endpoints y métodos relacionados con países
    }
}