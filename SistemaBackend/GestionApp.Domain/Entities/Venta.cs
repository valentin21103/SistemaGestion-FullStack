using System;
using System.Collections.Generic;
using System.Text;
using static GestionApp.Domain.Enums;

namespace GestionApp.Domain.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public MetodoDePago MetodoDePago { get; set; } 
        public decimal Total { get; set; }

        // Vendedor
        public int UsuarioId { get; set; }
        public  Usuario? Usuario { get; set; }

        // Cliente
        public int ClienteId { get; set; }
        public  Cliente? Cliente { get; set; }

        public  ICollection<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();


    }
}
