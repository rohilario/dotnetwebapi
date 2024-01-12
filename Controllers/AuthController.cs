using Microsoft.AspNetCore.Mvc;
using dotnetwebapi.Services;
using dotnetwebapi.Models;

namespace dotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost]
        public IActionResult Auth(string username, string passwd)
        {
            if (username == "Hilario" && passwd == "123")
            {
                var token = TokenService.GenerateToken(new User(User.Name, cpf));
                return Ok(token);
            }

            return BadRequest("Usuario ou senhas invalidos!");
        }

    }
}
