using Microsoft.AspNetCore.Mvc;
using dotnetwebapi.Services;
using dotnetwebapi.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;


namespace dotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMongoCollection<Auth> _authCollection;


        public AuthController(IUserService _userService, IMongoDatabase database)
        {
            userService = _userService;
            _authCollection = database.GetCollection<Auth>("Auth");
        }

        [HttpPost]
        public IActionResult Auth(string username, string passwd)
        {
            var User = userService.GetUserByAuth(username, passwd);
            var resultUserService = JsonConvert.SerializeObject(User);
            User userObject = JsonConvert.DeserializeObject<User>(resultUserService);

            if (userObject.UserName == username && userObject.passwd == passwd)
            {

                var token = TokenService.GenerateToken(User);
                Auth tokenObj = JsonConvert.DeserializeObject<Auth>(token.ToJson());
                Console.WriteLine("jsonObject" + tokenObj.Token);
                _authCollection.InsertOne(tokenObj);
                return Ok(token);

            }

            return BadRequest("Usuario ou senhas invalidos!");
        }

    }
}
