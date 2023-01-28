using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static readonly List<Filme> filmes = new();
        
        private FilmeContext _context;
        private IMapper _mapper;

        public  FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um filme ao banco de dados
        /// </summary>
        /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscarFilmeId),
               new { id = filme.Id },
               filme);
        }

        /// <summary>
        /// Retorna lista de filmes do banco de dados
        /// </summary>
        /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso inserção seja feita com sucesso</response>
        [HttpGet]
        public IEnumerable<ReadFilmeDto> BuscarFilmes([FromQuery] int skip = 0,
            [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip
                (skip).Take(take));
        }

        /// <summary>
        /// Adiciona um filme ao banco de dados
        /// </summary>
        /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpGet("{id}")]
        public IActionResult BuscarFilmeId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
            return Ok(filmeDto);
        }

        /// <summary>
        /// Atualiza dados de um filme ao banco de dados
        /// </summary>
        /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso inserção seja feita com sucesso</response>
        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody]
            UpdateFilmeDto filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(
                filme => filme.Id == id);
            if (filme == null) return NotFound();
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Atualiza dados de um  filme de forma parcial no banco de dados
        /// </summary>
        /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso inserção seja feita com sucesso</response>
        [HttpPatch("{id}")]
        public IActionResult AtualizaFilmeParcial(int id,
            JsonPatchDocument<UpdateFilmeDto> patch)
        {
            var filme = _context.Filmes.FirstOrDefault(
                filme => filme.Id == id);
            if (filme == null) return NotFound();

            var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

            patch.ApplyTo(filmeParaAtualizar, ModelState);

            if(!TryValidateModel(filmeParaAtualizar))
            {
                return ValidationProblem(ModelState);

            }

            _mapper.Map(filmeParaAtualizar, filme);
            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Remove um filme ao banco de dados
        /// </summary>
        /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso a remoção seja feita com sucesso</response>
        [HttpDelete]
        public IActionResult DeletaFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(
                filme=> filme.Id == id);
            if (filme == null) return NotFound();
            _context.Filmes.Remove(filme);
            _context.SaveChanges();
            return NoContent();

        }

    }
}
