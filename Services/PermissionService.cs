using dotnetwebapi.Data;
using dotnetwebapi.Models;

/*
   Servico voltado para Cadastro de Permissao
*/

namespace dotnetwebapi.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly APIDbContext _dbContext;
        public PermissionService(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Permission> GetPermissionList()
        {
            return _dbContext.Permission.ToList();
        }
        public Permission GetPermissionById(int id)
        {
            return _dbContext.Permission.Where(x => x.PermissionId == id).FirstOrDefault();
        }
        public Permission AddPermission(Permission Permission)
        {
            var result = _dbContext.Permission.Add(Permission);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public Permission UpdatePermission(Permission Permission)
        {
            var result = _dbContext.Permission.Update(Permission);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeletePermission(int Id)
        {
            var filteredData = _dbContext.Permission.Where(x => x.PermissionId == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}