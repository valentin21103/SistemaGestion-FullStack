using System;
using System.Collections.Generic;
using System.Text;

namespace GestionApp.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }

        public required string Nombre { get; set; } 


        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
