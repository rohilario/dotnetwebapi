using dotnetwebapi.Models;

namespace dotnetwebapi.Services
{
    public interface IUserPermissionService
    {
        public IEnumerable<UserPermission> GetUserPermissionList();
        public UserPermission GetUserPermissionById(int id);
        public UserPermission AddUserPermission(UserPermission product);
        public UserPermission UpdateUserPermission(UserPermission product);
        public bool DeleteUserPermission(int Id);
    }
}