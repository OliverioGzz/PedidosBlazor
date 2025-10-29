using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosBlazor.Shared.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        [Required]
        public int MesaId { get; set; }

        [Required]
        public int EmpleadoId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Estado { get; set; } = "Pendiente";

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [NotMapped]
        public decimal Total => Items?.Sum(i => (i.Platillo?.Precio ?? 0) * i.Cantidad) ?? 0;

        [ForeignKey("MesaId")]
        public Mesa? Mesa { get; set; }

        [ForeignKey("EmpleadoId")]
        public Empleado? Empleado { get; set; }

        public ICollection<ItemPedido> Items { get; set; } = new List<ItemPedido>();
    }
}
