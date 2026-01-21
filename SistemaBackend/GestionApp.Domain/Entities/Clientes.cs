using System;
using System.Collections.Generic;
using System.Text;

namespace GestionApp.Domain.Entities
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string? Dni { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }

        // (Opcional) Para ver el historial de compras de este cliente
        public required virtual ICollection<Venta> Compras { get; set; }
    }
}
