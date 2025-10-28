using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosBlazor.Shared.Interfaces;
using PedidosBlazor.Shared.Models;

namespace PedidosBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatilloesController : ControllerBase
    {
        private readonly IPlatilloService _platilloService;
        private readonly ILogger<PlatilloesController> _logger;

        public PlatilloesController(IPlatilloService platilloService, ILogger<PlatilloesController> logger)
        {
            _platilloService = platilloService;
            _logger = logger;
        }

        // GET: api/Platilloes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Platillo>>> GetPlatillos()
        {
            try
            {
                var platillos = await _platilloService.ObtenerTodosAsync();
                return Ok(platillos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de platillos.");
                return StatusCode(500, "Error interno al obtener los platillos.");
            }
        }

        // GET: api/Platilloes/5
        [HttpGet("{id}")]
        public IActionResult GetPlatillo(int id)
        {
            return StatusCode(501, "El método GET por ID no está implementado. Agrega ObtenerPorIdAsync en IPlatilloService si deseas habilitarlo.");
        }

        // PUT: api/Platilloes/5
        [HttpPut("{id}")]
        public IActionResult PutPlatillo(int id, Platillo platillo)
        {
            return StatusCode(501, "El método PUT no está implementado. Agrega ActualizarAsync en IPlatilloService si deseas habilitarlo.");
        }

        // POST: api/Platilloes
        [HttpPost]
        public IActionResult PostPlatillo(Platillo platillo)
        {
            return StatusCode(501, "El método POST no está implementado. Agrega CrearAsync en IPlatilloService si deseas habilitarlo.");
        }

        // DELETE: api/Platilloes/5
        [HttpDelete("{id}")]
        public IActionResult DeletePlatillo(int id)
        {
            return StatusCode(501, "El método DELETE no está implementado. Agrega EliminarAsync en IPlatilloService si deseas habilitarlo.");
        }
    }
}
