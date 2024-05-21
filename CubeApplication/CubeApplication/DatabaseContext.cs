using CubeApplication.Model;
using Microsoft.EntityFrameworkCore;

namespace CubeApplication
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        
        public DbSet<Cube> Cube { get; set; }

    }
}
