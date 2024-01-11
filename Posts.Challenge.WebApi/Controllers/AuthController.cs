using Posts.Challenge.Domain.Exceptions;
using Posts.Challenge.Domain.Interfaces.Services.Login;
using Posts.Challenge.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Posts.Challenge.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = _loginService.Authenticate(request.Email, request.Password);
                return Ok(token);
            }
            catch (InvalidCredentialsException ex)
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
