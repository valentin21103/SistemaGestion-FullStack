using System;
using System.Collections.Generic;
using System.Text;

namespace GestionApp.Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; }

        public required string Nombre { get; set; }

        public decimal Precio { get; set; }

        public int CantidadStock { get; set; }
        public required string Descripcion { get; set; }

        public int Categoriaid {  get; set; }

        public required virtual Categoria Categoría { get; set; }
    }
}
