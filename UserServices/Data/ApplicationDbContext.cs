using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UserServices.Model;

namespace UserServices.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
