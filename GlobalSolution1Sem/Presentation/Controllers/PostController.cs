using GlobalSolution1Sem.Application.Dto;
using GlobalSolution1Sem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GlobalSolution1Sem.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo post")]
        [SwaggerResponse(StatusCodes.Status201Created, "Post criado com sucesso", typeof(PostDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dados inválidos")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> CriarPost([FromBody] PostDto post)
        {
            try
            {
                var postCriado = await _postService.CriarPostAsync(post);
                return Ok(postCriado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao criar o post");
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um post existente")]
        [SwaggerResponse(StatusCodes.Status200OK, "Post atualizado com sucesso", typeof(PostDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "IDs inconsistentes ou dados inválidos")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Post não encontrado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> AtualizarPost(int id, [FromBody] PostDto post)
        {
            try
            {
                if (id != post.Id)
                {
                    return BadRequest("ID do post não corresponde ao ID na URL");
                }

                var postAtualizado = await _postService.AtualizarPostAsync(id, post);
                return Ok(postAtualizado);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Post não encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar o post");
            }
        }


        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um post")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Post removido com sucesso")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Post não encontrado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> RemoverPost(int id)
        {
            try
            {
                var sucesso = await _postService.RemoverPostAsync(id);
                if (!sucesso)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao remover o post");
            }
        }

        [HttpGet("por-usuario/{usuarioId}")]
        [SwaggerOperation(Summary = "Lista posts por ID de usuário")]
        [SwaggerResponse(StatusCodes.Status200OK, "Posts encontrados", typeof(IEnumerable<PostDto>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> BuscarPorUsuarioId(int usuarioId)
        {
            try
            {
                var posts = await _postService.BuscarPorUsuarioIdAsync(usuarioId);
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao buscar os posts");
            }
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os posts")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de posts retornada", typeof(IEnumerable<PostDto>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> ListarTodosPosts()
        {
            try
            {
                var posts = await _postService.ListarTodosPostsAsync();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao listar os posts");
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um post por ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Post encontrado", typeof(PostDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Post não encontrado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var post = await _postService.BuscarPorIdAsync(id);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao buscar o post");
            }
        }
    }
}
