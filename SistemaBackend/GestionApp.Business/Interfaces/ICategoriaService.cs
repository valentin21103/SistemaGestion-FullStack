using GestionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionApp.Business.Interfaces
{
    public interface ICategoriaService
    {

        Task<IEnumerable<Categoria>> ObtenerTodasAsync();
        Task<Categoria?> ObtenerPorIdAsync(int id);
        Task<bool> CrearCategoriaAsync(Categoria categoria);
        Task<bool> ActualizarCategoriaAsync(Categoria categoria);
        Task<bool> EliminarCategoriaAsync(int id);

    }
}
