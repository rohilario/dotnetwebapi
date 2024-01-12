using Microsoft.AspNetCore.Mvc;
using dotnetwebapi.Models;
using dotnetwebapi.Services;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public IEnumerable<UserPermission> GetUserList()
        {
            var userPermissionList = userPermissionService.GetUserPermissionList();
            return userPermissionList;
        }

        [HttpPost("addpermission")]
        [Authorize]
        public UserPermission AddUser(UserPermission userPermission)
        {
            return userPermissionService.AddUserPermission(userPermission);
        }


    }
}