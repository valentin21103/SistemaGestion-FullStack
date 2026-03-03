using System;
using System.Collections.Generic;
using System.Text;

namespace GestionApp.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string NombreUsuario { get; set; }
        public required string Contrasena { get; set; }

        // Relación: Un usuario puede tener muchas ventas
        public  ICollection<Venta> Ventas { get; set; } = new List<Venta>();



    }
}
