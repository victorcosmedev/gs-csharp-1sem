using GlobalSolution1Sem.Application.Dto;
using GlobalSolution1Sem.Application.Interfaces;
using GlobalSolution1Sem.Utils;
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
        [SwaggerOperation(Summary = ApiDoc.CadastrarUsuarioSummary, Description = ApiDoc.CadastrarUsuarioDescription)]
        [SwaggerResponse(StatusCodes.Status201Created, "Usuário cadastrado com sucesso", typeof(UsuarioDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dados inválidos")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] UsuarioDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var usuarioCadastrado = await _usuarioService.CadastrarUsuarioAsync(dto);
                return CreatedAtAction(nameof(BuscarPorId), new { id = usuarioCadastrado.Id }, usuarioCadastrado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = ApiDoc.AtualizarUsuarioSummary, Description = ApiDoc.AtualizarUsuarioDescription)]
        [SwaggerResponse(StatusCodes.Status200OK, "Usuário atualizado", typeof(UsuarioDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dados inválidos")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno")]
        public async Task<IActionResult> AtualizarUsuario(int id, [FromBody] UsuarioDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (id != dto.Id)
                {
                    return BadRequest("ID inconsistente");
                }

                var usuarioAtualizado = await _usuarioService.AtualizarUsuarioAsync(id, dto);
                return Ok(usuarioAtualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao atualizar usuário");
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = ApiDoc.RemoverUsuarioSummary, Description = ApiDoc.RemoverUsuarioDescription)]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Usuário removido")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno")]
        public async Task<IActionResult> RemoverUsuario(int id)
        {
            try
            {
                var sucesso = await _usuarioService.RemoverUsuarioAsync(id);
                return sucesso ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{cpf}")]
        [SwaggerOperation(Summary = ApiDoc.ObterUsuarioPorCpfSummary, Description = ApiDoc.ObterUsuarioPorCpfDescription)]
        [SwaggerResponse(StatusCodes.Status200OK, "Usuário encontrado", typeof(UsuarioDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno")]
        public async Task<IActionResult> ObterUsuarioPorCpf(string cpf)
        {
            try
            {
                var usuario = await _usuarioService.ObterUsuarioPorCpfAsync(cpf);
                return usuario != null ? Ok(usuario) : NotFound();
            }
            catch (Exception ex)
            {   
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [SwaggerOperation(Summary = ApiDoc.ListarTodosUsuariosSummary, Description = ApiDoc.ListarTodosUsuariosDescription)]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de usuários", typeof(IEnumerable<UsuarioDto>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno")]
        public async Task<IActionResult> ListarTodosUsuarios()
        {
            try
            {
                var usuarios = await _usuarioService.ListarTodosUsuariosAsync();
                return Ok(usuarios ?? new List<UsuarioDto>());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("por-id/{id}")]
        [SwaggerOperation(Summary = ApiDoc.BuscarUsuarioPorIdSummary, Description = ApiDoc.BuscarUsuarioPorIdDescription)]
        [SwaggerResponse(StatusCodes.Status200OK, "Usuário encontrado", typeof(UsuarioDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var usuario = await _usuarioService.BuscarPorIdAsync(id);
                return usuario != null ? Ok(usuario) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
