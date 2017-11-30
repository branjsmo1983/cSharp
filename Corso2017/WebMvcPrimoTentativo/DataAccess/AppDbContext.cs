using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvcPrimoTentativo.Models;

namespace WebMvcPrimoTentativo.DataAccess
{
    public class AppDbContext : DbContext

    {
        public AppDbContext():base()
        {

        }

       

        public DbSet<Teacher> Teachers { get; set; }
    }
}
