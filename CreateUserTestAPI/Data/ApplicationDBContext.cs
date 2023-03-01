using CreateUserTestAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CreateUserTestAPI.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) 
            : base(options)
        {
        }
        // create a table called Users in the database
        public DbSet<User> Users { get; set; }
    }
}
