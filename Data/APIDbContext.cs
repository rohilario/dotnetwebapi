using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnetwebapi.Models;

namespace dotnetwebapi.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; } = default!;

        public DbSet<UserPermission> UserPermission { get; set; } = default!;

        public DbSet<Permission> Permission { get; set; } = default!;
        
    }
}
