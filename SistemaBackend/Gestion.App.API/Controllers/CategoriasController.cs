using GestionApp.Business.Interfaces;
using GestionApp.Business.Services;
using GestionApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gestion.App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriasService;

        public CategoriasController(ICategoriaService categoriasService)
        {
            _categoriasService = categoriasService;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var categorias = await _categoriasService.ObtenerTodasAsync();
            return Ok(categorias);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await _categoriasService.ObtenerPorIdAsync(id);
            if (categoria == null) return NotFound("Categoria no encontrada");
            return Ok(categoria);
        }


        [HttpPost]

        public async Task<IActionResult> post([FromBody] Categoria categoria)
        {
            try
            {
                var result = await _categoriasService.CrearCategoriaAsync(categoria);

                if (result)
                    return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);

                return BadRequest("No se pudo guardar la categoría en la base de datos.");

            }

            catch (ArgumentException ex) 
            {
                    return BadRequest(new { mensaje = ex.Message } );
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.Id)
                return BadRequest("El ID de la URL no coincide con el ID del cuerpo."); 

            var result = await _categoriasService.ActualizarCategoriaAsync(categoria);

            if (!result)
                return BadRequest("No se pudo actualizar la categoría.");

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoriasService.EliminarCategoriaAsync(id);

            if (!result)
                return NotFound(new { mensaje = "Categoría no encontrada o ya eliminada." });

            return NoContent();

        }
    }

}
