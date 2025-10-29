using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosBlazor.Shared.Models
{
    public class ItemPedido
    {
        public int Id { get; set; }

        [Required]
        public int PedidoId { get; set; }

        [Required]
        public int PlatilloId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; } = 1;

        [NotMapped]
        public decimal Subtotal => (Platillo?.Precio ?? 0) * Cantidad;

        [ForeignKey("PlatilloId")]
        public Platillo? Platillo { get; set; }
    }
}
