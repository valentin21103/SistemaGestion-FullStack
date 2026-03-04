using GestionApp.Business.Interfaces;
using GestionApp.Domain.Entities;
using GestionApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionApp.Business.Services
{
    public class CategoriaService : ICategoriaService
    {

        private readonly IGenericRepository<Categoria> _repository;

        public CategoriaService(IGenericRepository<Categoria> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Categoria>> ObtenerTodasAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Categoria?> ObtenerPorIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> CrearCategoriaAsync(Categoria categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.Nombre))
                throw new ArgumentException("El nombre de la categoría es obligatorio.");

            await _repository.AddAsync(categoria);
            return await _repository.SaveAsync();
        }

        public async Task<bool> ActualizarCategoriaAsync(Categoria categoria)
        {
            _repository.Update(categoria);
            return await _repository.SaveAsync();
        }

        public async Task<bool> EliminarCategoriaAsync(int id)
        {
            var categoria = await _repository.GetByIdAsync(id);

            if (categoria == null) return false;

            _repository.Delete(categoria);
            return await _repository.SaveAsync();
        }


    }
}
