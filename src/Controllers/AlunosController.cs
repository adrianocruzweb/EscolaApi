using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EscolaApi.Models;

[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
    private readonly EscolaContext _context;

    public AlunosController(EscolaContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarAluno([FromBody] Aluno aluno)
    {
        _context.Alunos.Add(aluno);
        await _context.SaveChangesAsync();
        return Ok(aluno);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
    {
        return Ok(await _context.Alunos.ToListAsync());
    }

    // Nova rota para login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginViewModelInput loginInput)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Email ou senha inválidos.");
        }

        // Procurar o aluno pelo email e senha
        var aluno = await _context.Alunos
            .FirstOrDefaultAsync(a => a.Email == loginInput.Email && a.Senha == loginInput.Senha);

        if (aluno == null)
        {
            return Unauthorized("Credenciais incorretas.");
        }

        return Ok("Login bem-sucedido.");
    }
}
