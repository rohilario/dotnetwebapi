using dotnetwebapi.Models;

namespace dotnetwebapi.Services
{
    public interface IPermissionService
    {
        public IEnumerable<Permission> GetPermissionList();
        public Permission GetPermissionById(int id);
        public Permission AddPermission(Permission product);
        public Permission UpdatePermission(Permission product);
        public bool DeletePermission(int Id);
    }
}