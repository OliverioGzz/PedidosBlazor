using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosBlazor.Shared.Models
{
    public class Mesa
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Estado { get; set; } = "Libre"; // Libre, Ocupada, Reservada
    }
}
