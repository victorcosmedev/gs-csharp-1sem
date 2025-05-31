using GlobalSolution1Sem.Application.Dto;
using GlobalSolution1Sem.Application.Interfaces;
using GlobalSolution1Sem.Utils;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GlobalSolution1Sem.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _service;
        public EnderecoController(IEnderecoService service)
        {
            _service = service;
        }

        [HttpPost]
        [SwaggerOperation(Summary = ApiDoc.CadastrarEnderecoSummary, Description = ApiDoc.CadastrarEnderecoDescription)]
        [SwaggerResponse(StatusCodes.Status201Created, "Endereço cadastrado com sucesso", typeof(EnderecoDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dados inválidos")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> CadastrarEndereco([FromBody] EnderecoDto endereco)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { Errors = errors });
            }

            try
            {
                var enderecoCadastrado = await _service.CadastrarEnderecoAsync(endereco);
                return CreatedAtAction(nameof(BuscarEnderecoPorId), new { id = enderecoCadastrado.Id }, enderecoCadastrado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = ApiDoc.AtualizarEnderecoSummary, Description = ApiDoc.AtualizarEnderecoDescription)]
        [SwaggerResponse(StatusCodes.Status200OK, "Endereço atualizado com sucesso", typeof(EnderecoDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "IDs inconsistentes ou dados inválidos")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Endereço não encontrado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> AtualizarEndereco(int id, [FromBody] EnderecoDto endereco)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { Errors = errors });
            }

            try
            {
                if (id != endereco.Id)
                {
                    return BadRequest("ID do endereço não corresponde ao ID na URL");
                }

                var enderecoAtualizado = await _service.AtualizarEnderecoAsync(id, endereco);
                return Ok(enderecoAtualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar o endereço");
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = ApiDoc.RemoverEnderecoSummary, Description = ApiDoc.RemoverEnderecoDescription)]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Endereço removido com sucesso")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Endereço não encontrado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> RemoverEndereco(int id)
        {
            try
            {
                var sucesso = await _service.RemoverEnderecoAsync(id);
                if (!sucesso)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao remover o endereço");
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = ApiDoc.BuscarEnderecoPorIdSummary, Description = ApiDoc.BuscarEnderecoPorIdDescription)]
        [SwaggerResponse(StatusCodes.Status200OK, "Endereço encontrado", typeof(EnderecoDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Endereço não encontrado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> BuscarEnderecoPorId(int id)
        {
            try
            {
                var endereco = await _service.BuscarEnderecoPorIdAsync(id);
                if (endereco == null)
                {
                    return NotFound();
                }
                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao buscar o endereço");
            }
        }

        [HttpGet("por-cep-numero")]
        [SwaggerOperation(Summary = ApiDoc.ObterEnderecoPorCepNumeroSummary, Description = ApiDoc.ObterEnderecoPorCepNumeroDescription)]
        [SwaggerResponse(StatusCodes.Status200OK, "Endereço encontrado", typeof(EnderecoDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "CEP ou número não fornecidos")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Endereço não encontrado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> ObterEnderecoPorCepNumero([FromQuery] string cep, [FromQuery] string numero)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cep))
                {
                    return BadRequest("CEP é obrigatório");
                }

                if (string.IsNullOrWhiteSpace(numero))
                {
                    return BadRequest("Número é obrigatório");
                }

                var endereco = await _service.ObterEnderecoPorCepNumeroAsync(cep, numero);
                if (endereco == null)
                {
                    return NotFound();
                }
                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao buscar o endereço");
            }
        }

        [HttpGet]
        [SwaggerOperation(Summary = ApiDoc.ListarTodosEnderecosSummary, Description = ApiDoc.ListarTodosEnderecosDescription)]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de endereços retornada", typeof(IEnumerable<EnderecoDto>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> ListarTodosEnderecos()
        {
            try
            {
                var enderecos = await _service.ListarTodosEnderecosAsync();
                return Ok(enderecos ?? new List<EnderecoDto>());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao listar os endereços");
            }
        }
    }
}
