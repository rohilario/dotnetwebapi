using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Models
{
    public class UserServiceContext : DbContext
    {
        public UserServiceContext (DbContextOptions<UserServiceContext> options)
            : base(options)
        {
        }

        public DbSet<UserService.Models.User> User { get; set; } = default!;

        public DbSet<UserService.Models.UserPermission> UserPermission { get; set; } = default!;
        
    }
}
