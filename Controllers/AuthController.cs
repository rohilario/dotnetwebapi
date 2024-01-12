using Microsoft.AspNetCore.Mvc;
using dotnetwebapi.Services;
using dotnetwebapi.Models;
using System.Diagnostics;
using Newtonsoft.Json;

namespace dotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;

        public AuthController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpPost]
        public IActionResult Auth(string username, string passwd)
        {
            var User = userService.GetUserByAuth(username, passwd);
            var resultUserService = JsonConvert.SerializeObject(User);
            User userObject = JsonConvert.DeserializeObject<User>(resultUserService);

            Console.WriteLine("resultUserService" + resultUserService);
            Console.WriteLine("userObject" + userObject.UserCpf);

            if (userObject.UserName == "Hilario" && userObject.passwd == "123")
            {
                var token = TokenService.GenerateToken(User);
                return Ok(token);
            }

            return BadRequest("Usuario ou senhas invalidos!");
        }

    }
}
