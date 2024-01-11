using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Posts.Challenge.Domain.Exceptions;
using Posts.Challenge.Domain.Interfaces.Services.Post;
using Posts.Challenge.Domain.Requests.Post;
using Posts.Challenge.WebApi.Filters;
using Posts.Challenge.WebApi.Hubs;

namespace Posts.Challenge.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IHubContext<PostsHub, IPostHubProvider> _postHub;

        public PostsController(
            IPostService postService,
            IHubContext<PostsHub, IPostHubProvider> postsHub)
        {
            _postService = postService;
            _postHub = postsHub;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var posts = _postService.GetAll();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(503, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var post = _postService.GetById(id);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(503, ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [TypeFilter(typeof(UserAuthenticationAttribute))]
        public async Task<IActionResult> Create([FromBody] PostRequest request)
        {
            try
            {
                var user = HttpContext.Items["userEmail"] as string;
                await _postService.Create(request, user);
                await _postHub.Clients.All.ReceiveMessage(user, request.Title, request.Content);
                return Ok("Novo post criado com sucesso!");
            }
            catch(NewPostValidatationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(503, ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        [TypeFilter(typeof(UserAuthenticationAttribute))]
        public IActionResult Update([FromBody] UpdatePostRequest request)
        {
            try
            {
                var user = HttpContext.Items["userEmail"] as string;
                var updated = _postService.UpdateByUser(request, user);

                if(updated)
                    return Ok("Post atualizado com sucesso!");

                return BadRequest("Não foi possível atualizar o post.");

            }
            catch(EntityNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UserNotAllowedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(503, ex.Message);
            }
        }

        [HttpDelete]
        [Authorize]
        [TypeFilter(typeof(UserAuthenticationAttribute))]
        public IActionResult Delete([FromQuery] long id)
        {
            try
            {
                var user = HttpContext.Items["userEmail"] as string;
                _postService.DeleteByUser(id, user);
                return Ok("Post deletado com sucesso!");
            }
            catch (EntityNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UserNotAllowedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(503, ex.Message);
            }
        }

    }
}
