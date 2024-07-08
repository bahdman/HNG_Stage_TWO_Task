using Microsoft.AspNetCore.Mvc;

namespace src.Controllers{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase{
        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            return Ok();
        }
    }
}