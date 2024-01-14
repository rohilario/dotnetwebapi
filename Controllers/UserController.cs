using Microsoft.AspNetCore.Mvc;
using dotnetwebapi.Models;
using dotnetwebapi.Services;
using Microsoft.AspNetCore.Authorization;

namespace dotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;

        }

        // GET: api/User
        [HttpGet ("userlist")]
        [Authorize]
        public IEnumerable<User> GetUserList()
        {
            var userList = userService.GetUserList;
            var teste = (IEnumerable<User>)userList();
            return teste;
        }

        [HttpPost("adduser")]
        public User AddUser(User user)
        {
            return userService.AddUser(user);
        }

        [HttpGet("getuserbyid")]
        [Authorize]
        public User GetUserById(int Id)
        {
            return userService.GetUserById(Id);
        }

    }
}