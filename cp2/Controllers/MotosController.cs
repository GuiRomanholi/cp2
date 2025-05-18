using cp2.Application.DTOs.Request;
using cp2.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace cp2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotosController : ControllerBase
    {
        private readonly MotoUseCase _useCase;

        public MotosController(MotoUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _useCase.ListarTodos());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var moto = await _useCase.BuscarPorId(id);
                return Ok(moto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MotoRequest request)
        {
            var result = await _useCase.Criar(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] MotoRequest request)
        {
            await _useCase.Atualizar(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _useCase.Excluir(id);
            return NoContent();
        }
    }
}
