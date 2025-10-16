using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosBlazor.Shared.Models
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; } = null!;
        public int PlatilloId { get; set; }
        public Platillo Platillo { get; set; } = null!;
    }
}
