using Microsoft.EntityFrameworkCore;
using WebMvcSuperheroes.Models;

namespace WebMvcSuperheroes.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base()
        { }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<Villain> Villains { get; set; }
    }
}
