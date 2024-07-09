using Microsoft.AspNetCore.Mvc;
using src.Interface;
using src.ViewModels;

namespace src.Controllers{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase{

        private readonly IAuth _service;

        public AuthController(IAuth service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginViewModel viewModel){
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel viewModel){
            return Ok(await _service.CreateUser(viewModel));
        }
    }
}