using System;
using System.Collections.Generic;
using System.Text;

namespace GestionApp.Domain.Entities
{
    public class DetalleVenta
    {

        public int Id { get; set; } 

        public int VentaId { get; set; }

        public required virtual Venta Venta { get; set; }

        public int ProductoId { get; set; }

        public required virtual Productos Productos { get; set; }
        
        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal ImporteTotal => Cantidad * PrecioUnitario;
    }
}
