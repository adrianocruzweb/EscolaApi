using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using EscolaApi.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CursosController : ControllerBase
{
    private readonly EscolaContext _context;

    public CursosController(EscolaContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> InserirCurso([FromBody] Curso curso)
    {
        _context.Cursos.Add(curso);
        await _context.SaveChangesAsync();
        return Ok(curso);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
    {
        return Ok(await _context.Cursos.ToListAsync());
    }
}
