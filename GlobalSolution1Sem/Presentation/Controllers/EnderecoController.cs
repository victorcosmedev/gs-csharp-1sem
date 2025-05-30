using GlobalSolution1Sem.Application.Dto;
using GlobalSolution1Sem.Application.Interfaces;
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
        [SwaggerOperation(Summary = "Cadastra um novo endereço")]
        [SwaggerResponse(StatusCodes.Status201Created, "Endereço cadastrado com sucesso", typeof(EnderecoDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dados inválidos")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> CadastrarEndereco([FromBody] EnderecoDto endereco)
        {
            try
            {
                var enderecoCadastrado = await _service.CadastrarEnderecoAsync(endereco);
                return Ok(enderecoCadastrado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao cadastrar o endereço");
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um endereço existente")]
        [SwaggerResponse(StatusCodes.Status200OK, "Endereço atualizado com sucesso", typeof(EnderecoDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "IDs inconsistentes ou dados inválidos")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Endereço não encontrado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> AtualizarEndereco(int id, [FromBody] EnderecoDto endereco)
        {
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
        [SwaggerOperation(Summary = "Remove um endereço")]
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
        [SwaggerOperation(Summary = "Obtém um endereço por ID")]
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
        [SwaggerOperation(Summary = "Obtém um endereço por CEP e número")]
        [SwaggerResponse(StatusCodes.Status200OK, "Endereço encontrado", typeof(EnderecoDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "CEP ou número não fornecidos")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Endereço não encontrado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> ObterEnderecoPorCepNumero([FromQuery] string cep, [FromQuery] string numero)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cep) || string.IsNullOrWhiteSpace(numero))
                {
                    return BadRequest("CEP e número são obrigatórios");
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
        [SwaggerOperation(Summary = "Lista todos os endereços")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de endereços retornada", typeof(IEnumerable<EnderecoDto>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> ListarTodosEnderecos()
        {
            try
            {
                var enderecos = await _service.ListarTodosEnderecosAsync();
                return Ok(enderecos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao listar os endereços");
            }
        }
    }
}
