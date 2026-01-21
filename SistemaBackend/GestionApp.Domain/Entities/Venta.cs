using System;
using System.Collections.Generic;
using System.Text;
using static GestionApp.Domain.Enums;

namespace GestionApp.Domain.Entities
{
    public class Venta
    {
        public int Id { get; set; }

        public DateTime fecha { get; set; }

        public MetodoDePago metodoDePago { get; set; }

        public decimal Total { get; set; }

        public int ClienteId { get; set; }

        public required virtual Clientes Cliente  { get; set; }

        public required  virtual ICollection<DetalleVenta> Detalles { get;set; }


    }
}
