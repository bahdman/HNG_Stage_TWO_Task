using Microsoft.AspNetCore.Mvc;
using src.ViewModels;

namespace src.Controllers{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase{

        [HttpPost("login")]
        public IActionResult Login(LoginViewModel viewModel){
            return Ok();
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterViewModel viewModel){
            return Ok();
        }
    }
}