using GlobalSolution1Sem.Application.Dto;
using GlobalSolution1Sem.Application.Interfaces;
using GlobalSolution1Sem.Utils;
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
        [SwaggerOperation(Summary = ApiDoc.CriarPostSummary, Description = ApiDoc.CriarPostDescription)]
        [SwaggerResponse(StatusCodes.Status201Created, "Post criado com sucesso", typeof(PostDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dados inválidos")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> CriarPost([FromBody] PostDto post)
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
                var postCriado = await _postService.CriarPostAsync(post);
                return CreatedAtAction(nameof(BuscarPorId), new { id = postCriado.Id }, postCriado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao criar o post");
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = ApiDoc.AtualizarPostSummary, Description = ApiDoc.AtualizarPostDescription)]
        [SwaggerResponse(StatusCodes.Status200OK, "Post atualizado com sucesso", typeof(PostDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "IDs inconsistentes ou dados inválidos")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Post não encontrado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> AtualizarPost(int id, [FromBody] PostDto post)
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
        [SwaggerOperation(Summary = ApiDoc.RemoverPostSummary, Description = ApiDoc.RemoverPostDescription)]
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
        [SwaggerOperation(Summary = ApiDoc.BuscarPorUsuarioIdSummary, Description = ApiDoc.BuscarPorUsuarioIdDescription)]
        [SwaggerResponse(StatusCodes.Status200OK, "Posts encontrados", typeof(IEnumerable<PostDto>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> BuscarPorUsuarioId(int usuarioId)
        {
            try
            {
                var posts = await _postService.BuscarPorUsuarioIdAsync(usuarioId);
                return Ok(posts ?? new List<PostDto>());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao buscar os posts");
            }
        }

        [HttpGet]
        [SwaggerOperation(Summary = ApiDoc.ListarTodosPostsSummary, Description = ApiDoc.ListarTodosPostsDescription)]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de posts retornada", typeof(IEnumerable<PostDto>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno no servidor")]
        public async Task<IActionResult> ListarTodosPosts()
        {
            try
            {
                var posts = await _postService.ListarTodosPostsAsync();
                return Ok(posts ?? new List<PostDto>());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao listar os posts");
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = ApiDoc.BuscarPorIdSummary, Description = ApiDoc.BuscarPorIdDescription)]
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
