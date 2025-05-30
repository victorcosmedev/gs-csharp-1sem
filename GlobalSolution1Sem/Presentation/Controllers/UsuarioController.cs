using GlobalSolution1Sem.Application.Dto;
using GlobalSolution1Sem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GlobalSolution1Sem.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo usuário")]
        [SwaggerResponse(StatusCodes.Status201Created, "Usuário cadastrado com sucesso", typeof(UsuarioDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dados inválidos fornecidos")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] UsuarioDto dto)
        {
            try
            {
                var usuarioCadastrado = await _usuarioService.CadastrarUsuarioAsync(dto);
                return Ok(usuarioCadastrado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao cadastrar o usuário");
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um usuário existente")]
        [SwaggerResponse(StatusCodes.Status200OK, "Usuário atualizado com sucesso", typeof(UsuarioDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dados inválidos fornecidos")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> AtualizarUsuario(int id, [FromBody] UsuarioDto dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return BadRequest("ID do usuário não corresponde ao ID na URL");
                }

                var usuarioAtualizado = await _usuarioService.AtualizarUsuarioAsync(id, dto);
                return Ok(usuarioAtualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao atualizar o usuário");
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um usuário")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Usuário removido com sucesso")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> RemoverUsuario(int id)
        {
            try
            {
                var sucesso = await _usuarioService.RemoverUsuarioAsync(id);
                if (!sucesso)
                {
                    return NotFound("Usuário não encontrado");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao remover o usuário");
            }
        }

        [HttpGet("/{cpf}")]
        [SwaggerOperation(Summary = "Obtém um usuário por CPF")]
        [SwaggerResponse(StatusCodes.Status200OK, "Usuário encontrado", typeof(UsuarioDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> ObterUsuarioPorCpf(string cpf)
        {
            try
            {
                var usuario = await _usuarioService.ObterUsuarioPorCpfAsync(cpf);
                if (usuario == null)
                {
                    return NotFound("Usuário não encontrado");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao buscar o usuário");
            }
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os usuários")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de usuários retornada com sucesso", typeof(IEnumerable<UsuarioDto>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> ListarTodosUsuarios()
        {
            try
            {
                var usuarios = await _usuarioService.ListarTodosUsuariosAsync();
                return Ok(usuarios ?? Enumerable.Empty<UsuarioDto>());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao listar os usuários");
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um usuário por ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Usuário encontrado", typeof(UsuarioDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var usuario = await _usuarioService.BuscarPorIdAsync(id);
                if (usuario == null)
                {
                    return NotFound("Usuário não encontrado");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao buscar o usuário");
            }
        }
    }
}
