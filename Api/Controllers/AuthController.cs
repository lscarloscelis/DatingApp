using Api.DTOs.Auth;
using Api.Repos.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo authRepo;
        public AuthController(IAuthRepo authRepo)
        {
            this.authRepo = authRepo;
        }

        [HttpPost("register")]
        public IActionResult Register(Register register)
        {
            if(authRepo.registerUser(register)){
                return Ok();
            }
            return BadRequest("Ya Existe Usuario");
        }

        [HttpPost("login")]
        public IActionResult Login(Login login)
        {
            var token = authRepo.loginUser(login);
            if(token == null){
                return BadRequest("Revise Credenciales");
            }
            return Ok(token);
        }
    }
}