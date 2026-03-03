using System;
using System.Collections.Generic;
using System.Text;

namespace GestionApp.Domain.Interfaces
{
    // La <T> significa que esto va a servir para Productos, Clientes, Ventas, etc.

    // Al agregarle where T : class, le estás diciendo a C#: "El comodín T puede ser cualquier cosa (Alfajor, Producto, Venta), PERO tiene que ser sí o sí una Clase".

    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveAsync();
    }
}
