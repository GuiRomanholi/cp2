using cp2.Application.DTOs.Request;
using cp2.Application.DTOs.Response;
using cp2.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace cp2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioUseCase _usuarioUseCase;

        public UsuarioController(UsuarioUseCase usuarioUseCase)
        {
            _usuarioUseCase = usuarioUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponse>>> Get()
        {
            var usuarios = await _usuarioUseCase.ListarTodos();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponse>> GetById(Guid id)
        {
            var usuario = await _usuarioUseCase.BuscarPorId(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioResponse>> Post([FromBody] UsuarioRequest request)
        {
            var novoUsuario = await _usuarioUseCase.Criar(request);
            return CreatedAtAction(nameof(GetById), new { id = novoUsuario.Id }, novoUsuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UsuarioRequest request)
        {
            try
            {
                await _usuarioUseCase.Atualizar(id, request);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Usuário não encontrado para atualização.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _usuarioUseCase.Excluir(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Usuário não encontrado para exclusão.");
            }
        }
    }
}
