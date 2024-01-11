using Microsoft.AspNetCore.Mvc;
using dotnetwebapi.Data;
using dotnetwebapi.Models;
using dotnetwebapi.Services;

namespace dotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {

        private readonly IPermissionService permissionService;

        public PermissionController(IPermissionService _permissionService)
        {
            permissionService = _permissionService;

        }

        // GET: api/User
        [HttpGet("permissionlist")]
        public IEnumerable<Permission> GetPermissionList()
        {
            var permissionList = permissionService.GetPermissionList();
            return permissionList;
        }

        [HttpPost("addpermission")]
        public Permission AddPermission(Permission permission)
        {
            return permissionService.AddPermission(permission);
        }

    }
}
