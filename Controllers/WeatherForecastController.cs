using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace PaginaBlog.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class BlogEntryController : ControllerBase
    {
        // Lista en memoria para almacenar las entradas de blog
        private static List<BlogEntry> blogEntries = new List<BlogEntry>();

        [HttpPost(Name = "CreateBlogEntry")]
        public IActionResult Create(BlogEntry entry)
        {
            // Accede a los valores de la entrada y guárdalos en la lista
            blogEntries.Add(entry);

            // Realiza operaciones adicionales si es necesario

            // Si no necesitas retornar una respuesta específica, simplemente retorna un Ok().
            return Ok();
        }

        // Endpoint adicional para obtener todas las entradas de blog
        [HttpGet(Name = "GetAllBlogEntries")]
        public IActionResult GetAll()
        {
            // Retorna todas las entradas de blog almacenadas en la lista
            return Ok(blogEntries);
        }

        // Endpoint para realizar búsquedas
        [HttpGet("Search", Name = "SearchBlogEntries")]
        public IActionResult Search(string searchTerm)
        {
            // Filtra las entradas de blog por título, contenido o autor
            var results = blogEntries.Where(entry =>
                entry.Titulo.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                entry.Contenido.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                entry.Autor.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            // Retorna los resultados de la búsqueda
            return Ok(results);
        }
    }
}