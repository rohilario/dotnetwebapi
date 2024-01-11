using dotnetwebapi.Data;
using dotnetwebapi.Models;

/*
   Servico voltado para Cadastro de usuários.
*/

namespace dotnetwebapi.Services
{
    public class Userervice : IUserService
    {
        private readonly APIDbContext _dbContext;
        public Userervice(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<User> GetUserList()
        {
            return _dbContext.User.ToList();
        }
        public User GetUserById(int id)
        {
            return _dbContext.User.Where(x => x.UserId == id).FirstOrDefault();
        }
        public User AddUser(User User)
        {
            var result = _dbContext.User.Add(User);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public User UpdateUser(User User)
        {
            var result = _dbContext.User.Update(User);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteUser(int Id)
        {
            var filteredData = _dbContext.User.Where(x => x.UserId == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}