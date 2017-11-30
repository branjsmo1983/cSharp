using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvcPrimoTentativo.Models;

namespace WebMvcPrimoTentativo.DataAccess
{
    public class EfRepository : IRepository<Teacher>
    {


        public void DeleteFromDatabase(int id)
        {
            throw new NotImplementedException();
        }

        public List<Teacher> GetListFromDatabase()
        {
            var dbctx = new AppDbContext();

            var list = dbctx.Teachers
                .Where(t => t.Rating > 3)
                .ToList();

            return list;
        }

        public Teacher GetSingleFromDatabase(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateInDatabase(Teacher model)
        {
            throw new NotImplementedException();
        }
    }
}
