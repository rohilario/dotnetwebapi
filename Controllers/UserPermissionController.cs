using Microsoft.AspNetCore.Mvc;
using dotnetwebapi.Models;
using dotnetwebapi.Services;

namespace dotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPermissionController : ControllerBase
    {
        private readonly IUserPermissionService userPermissionService;

        public UserPermissionController(IUserPermissionService _userPermissionService)
        {
            userPermissionService = _userPermissionService;

        }

        // GET: api/User
        [HttpGet("userpermissionlist")]
        public IEnumerable<UserPermission> GetUserList()
        {
            var userPermissionList = userPermissionService.GetUserPermissionList();
            return userPermissionList;
        }

        [HttpPost("addpermission")]
        public UserPermission AddUser(UserPermission userPermission)
        {
            return userPermissionService.AddUserPermission(userPermission);
        }


    }
}