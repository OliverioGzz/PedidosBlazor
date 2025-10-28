using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosBlazor.Shared.Interfaces;
using PedidosBlazor.Shared.Models;

namespace PedidosBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesasController : ControllerBase
    {
        private readonly IMesaService _mesaService;
        private readonly ILogger<MesasController> _logger;

        public MesasController(IMesaService mesaService, ILogger<MesasController> logger)
        {
            _mesaService = mesaService;
            _logger = logger;
        }

        // GET: api/Mesas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mesa>>> GetMesas()
        {
            _logger.LogInformation("🔵 GetMesas llamado");
            try
            {
                _logger.LogInformation("🔵 Llamando a _mesaService.ObtenerTodasAsync()");
                var mesas = await _mesaService.ObtenerTodasAsync();
                _logger.LogInformation($"🔵 Mesas obtenidas: {mesas?.Count ?? 0}");
                return Ok(mesas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "🔴 Error al obtener las mesas.");
                return StatusCode(500, "Error interno al obtener las mesas.");
            }
        }

        // GET: api/Mesas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mesa>> GetMesa(int id)
        {
            try
            {
                var mesa = await _mesaService.ObtenerPorIdAsync(id);

                if (mesa == null)
                    return NotFound();

                return Ok(mesa);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la mesa {MesaId}", id);
                return StatusCode(500, "Error interno al obtener la mesa.");
            }
        }

        // PUT: api/Mesas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMesa(int id, Mesa mesa)
        {
            if (id != mesa.Id)
                return BadRequest("El ID de la URL no coincide con el del cuerpo de la solicitud.");

            try
            {
                await _mesaService.ActualizarAsync(mesa);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogWarning(ex, "Error de concurrencia al actualizar la mesa {MesaId}", id);
                return Conflict(new { message = "Conflicto de concurrencia al actualizar la mesa." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar la mesa {MesaId}", id);
                return StatusCode(500, "Error interno al actualizar la mesa.");
            }
        }

        // POST: api/Mesas
        [HttpPost]
        public IActionResult PostMesa()
        {
            return StatusCode(501, "El método POST no está implementado. Agrega CrearAsync en IMesaService si deseas habilitarlo.");
        }

        // DELETE: api/Mesas/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMesa(int id)
        {
            return StatusCode(501, "El método DELETE no está implementado. Agrega EliminarAsync en IMesaService si deseas habilitarlo.");
        }
    }
}
