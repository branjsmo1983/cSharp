using Microsoft.EntityFrameworkCore;
using WebMvcPrimoTentativo.Models;

namespace WebMvcPrimoTentativo.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base()
        { }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Teacher> Teachers { get; set; }
    }
}
