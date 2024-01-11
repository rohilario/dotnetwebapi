using dotnetwebapi.Data;
using dotnetwebapi.Models;

/*
   Servico voltado para Permissao de Usuários
*/

namespace dotnetwebapi.Services
{
    public class UserPermissionService : IUserPermissionService
    {
        private readonly APIDbContext _dbContext;
        public UserPermissionService(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<UserPermission> GetUserPermissionList()
        {
            return _dbContext.UserPermission.ToList();
        }
        public UserPermission GetUserPermissionById(int id)
        {
            return _dbContext.UserPermission.Where(x => x.UserPermissionId == id).FirstOrDefault();
        }
        public UserPermission AddUserPermission(UserPermission UserPermission)
        {
            var result = _dbContext.UserPermission.Add(UserPermission);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public UserPermission UpdateUserPermission(UserPermission UserPermission)
        {
            var result = _dbContext.UserPermission.Update(UserPermission);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteUserPermission(int Id)
        {
            var filteredData = _dbContext.UserPermission.Where(x => x.UserPermissionId == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}