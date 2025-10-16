using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosBlazor.Shared.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Estado { get; set; } = "Pendiente"; // Pendiente, EnPreparacion, Entregado, Pagado
        public decimal Total { get; set; }

        // Relaciones
        public int MesaId { get; set; }
        public Mesa Mesa { get; set; } = null!;
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; } = null!;

        public List<ItemPedido> Items { get; set; } = new List<ItemPedido>();
    }
}
