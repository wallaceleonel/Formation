using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static readonly List<Filme> filmes = new();

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filmes.Add(filme);
            return CreatedAtAction(nameof(BuscarFilmeId),
               new { id = filme.Id },
               filme);
        }

        [HttpGet]
        public IEnumerable<Filme> BuscarFilmes([FromQuery] int skip = 0,
            [FromQuery] int take = 50)
        {
            return filmes.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarFilmeId(int id)
        {
            var filme = filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }
    }
}
