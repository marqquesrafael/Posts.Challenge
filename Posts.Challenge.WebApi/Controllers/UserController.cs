using Posts.Challenge.Domain.Exceptions;
using Posts.Challenge.Domain.Interfaces.Services.User;
using Posts.Challenge.Domain.Requests;
using Posts.Challenge.Domain.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Posts.Challenge.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            try
            {
                await _userService.Register(request);
                return Ok("Usuário registrado com sucesso!");
            }
            catch (UserRegisterValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(503, ex.Message);
            }
        }

        [HttpGet("/user"), Authorize]
        public IActionResult GetUser([FromQuery] long id)
        {
            var user = _userService.GetById<UserResponse>(id);

            return Ok(user);
        }
    }
}
