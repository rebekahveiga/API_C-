using AutoMapper;
using FilmesApi.Dataset;
using FilmesApi.Dataset.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private readonly FilmeContext _context;
    private readonly IMapper _mapper;

    // Único construtor que aceita tanto IMapper quanto FilmeContext
    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um Filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto"></param> Objetos com os campos necessarios para criacao de um filme
    /// <returns></returns>
    
    // Método Adicionar Filme
    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
    }

    /// <summary>
    /// Método Leitura de um Filme na lista
    /// </summary>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <returns></returns>

    // Método Leitura de um Filme na lista
    [HttpGet]
    public IEnumerable<ReadFilmeDto> LerFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
    }

    // Método Recupera filme por id
    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    /// <summary>
    /// Metodo Atualizar Filme
    /// </summary>
    /// <param name="id"></param>
    /// <param name="filmeDto"></param>
    /// <returns></returns>

    //Metodo AtualizaFilme

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto) 
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if(filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    
    }

    /// <summary>
    /// Metodo Atualizar filme parcialmente
    /// </summary>
    /// <param name="id"></param>
    /// <param name="patch"></param>
    /// <returns></returns>
    // Metodo Atualiza filme parcialmente

    [HttpPatch("{id}")]

    public IActionResult AtualizaParcialFilme(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

        patch.ApplyTo(filmeParaAtualizar, Modelstate);
        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();

    }

    private void Modelstate(JsonPatchError error)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    ///  Metodo Exclui Filme
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    // Metodo Exclui Filme

    [HttpDelete("{id}")]

    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(
          filme => filme.Id == id);
        if (filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }

}
