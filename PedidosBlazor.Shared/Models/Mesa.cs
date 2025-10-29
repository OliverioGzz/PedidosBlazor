using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosBlazor.Shared.Models
{
    public class Mesa
    {
        public int Id { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        [MaxLength(50)]
        public string Estado { get; set; } = "Disponible";

        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
