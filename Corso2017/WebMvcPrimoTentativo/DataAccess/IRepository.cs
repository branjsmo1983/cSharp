using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvcPrimoTentativo.DataAccess
{
    public interface IRepository<T>
    {
        List<T> GetListFromDatabase();
        T GetSingleFromDatabase(int id);
        void DeleteFromDatabase(int id);
        void UpdateInDatabase(T model);
    }
}
