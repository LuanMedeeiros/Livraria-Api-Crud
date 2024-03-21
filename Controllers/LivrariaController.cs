using Livraria_Api;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LivrariaController : ControllerBase
{
    public static List<Livros> _livros = new List<Livros>();
    protected static int _ultimoId = 1;

    [HttpGet] // Read
    public IActionResult MostrarLivros()
    {
        return Ok(_livros);
    }

    [HttpPost] // Create
    public ActionResult<IEnumerable<Livros>> SalvarLivros(Livros livros)
    {
        livros.Id = _ultimoId++; //Incrementa o Id Automaticamente
        _livros.Add(livros);
        return Ok(livros);
    }


    [HttpPut("{id}")] // Update
    public IActionResult AlterarLivros(int id, Livros livroAtualizado)
    {
        var livro = _livros.FirstOrDefault(x => x.Id == id);

        if (livro == null)
        {
            return NotFound();
        }

        livro.Titulo = livroAtualizado.Titulo;
        livro.Genero = livroAtualizado.Genero;
        livro.Autor = livroAtualizado.Autor;

        return NoContent();
    }

    [HttpDelete("{id}")] // Delete
    public IActionResult DeletarLivros(int id)
    {
        var lixeira = _livros.FirstOrDefault(x => x.Id == id);

        if (lixeira == null)
        {
            return NotFound();
        }

        if (lixeira.Id == id)
        {
            _livros.Remove(lixeira);
        }

        return NoContent();
    }
}