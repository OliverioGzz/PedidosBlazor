using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosBlazor.Shared.Interfaces;
using PedidosBlazor.Shared.Models;

namespace PedidosBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoesController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        private readonly ILogger<PedidoesController> _logger;

        public PedidoesController(IPedidoService pedidoService, ILogger<PedidoesController> logger)
        {
            _pedidoService = pedidoService;
            _logger = logger;
        }

        // GET: api/Pedidoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            try
            {
                var pedidos = await _pedidoService.ObtenerTodosAsync();
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de pedidos.");
                return StatusCode(500, "Error interno al obtener los pedidos.");
            }
        }

        // GET: api/Pedidoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            try
            {
                var pedido = await _pedidoService.ObtenerPorIdAsync(id);

                if (pedido == null)
                    return NotFound();

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el pedido {PedidoId}", id);
                return StatusCode(500, "Error interno al obtener el pedido.");
            }
        }

        // GET: api/Pedidoes/PorMesaYEstado?mesaId=1&estado=Abierto
        [HttpGet("PorMesaYEstado")]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidosPorMesaYEstado([FromQuery] int? mesaId, [FromQuery] string? estado)
        {
            try
            {
                var pedidos = await _pedidoService.ObtenerPorMesaYEstadoAsync(mesaId, estado);
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener pedidos filtrados por mesa y estado.");
                return StatusCode(500, "Error interno al filtrar los pedidos.");
            }
        }

        // GET: api/Pedidoes/5/Items
        [HttpGet("{id}/Items")]
        public async Task<ActionResult<IEnumerable<ItemPedido>>> GetItemsPorPedido(int id)
        {
            try
            {
                var items = await _pedidoService.ObtenerItemsPorPedidoIdAsync(id);
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los items del pedido {PedidoId}", id);
                return StatusCode(500, "Error interno al obtener los items del pedido.");
            }
        }

        // PUT: api/Pedidoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.Id)
                return BadRequest("El ID del pedido no coincide con el de la solicitud.");

            try
            {
                await _pedidoService.ActualizarAsync(pedido);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogWarning(ex, "Conflicto de concurrencia al actualizar el pedido {PedidoId}", id);
                return Conflict(new { message = "Conflicto de concurrencia al actualizar el pedido." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el pedido {PedidoId}", id);
                return StatusCode(500, "Error interno al actualizar el pedido.");
            }
        }

        // POST: api/Pedidoes
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            try
            {
                var creado = await _pedidoService.CrearAsync(pedido);
                return CreatedAtAction(nameof(GetPedido), new { id = creado.Id }, creado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo pedido.");
                return StatusCode(500, "Error interno al crear el pedido.");
            }
        }

        // DELETE: api/Pedidoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            try
            {
                var eliminado = await _pedidoService.EliminarAsync(id);

                if (!eliminado)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el pedido {PedidoId}", id);
                return StatusCode(500, "Error interno al eliminar el pedido.");
            }
        }
    }
}
