using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvcSuperheroes.Models;

namespace WebMvcSuperheroes.DataAccess
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){

        }
        public AppDbContext() : base()
        {

        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
