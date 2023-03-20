using Microsoft.EntityFrameworkCore;
using RazorTestTask.Model;

namespace RazorTestTask
{
    public class ApplicationDateBase : DbContext
    {

        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Product> Products => Set<Product>();

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; initial catalog = TestTask; trusted_connection = true");
        }

    }
}
