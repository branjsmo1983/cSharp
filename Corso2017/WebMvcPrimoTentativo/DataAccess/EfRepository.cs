using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebMvcPrimoTentativo.Models;

namespace WebMvcPrimoTentativo.DataAccess
{
    public class EfRepository : IRepository<Teacher>
    {
        private AppDbContext _context;

        public EfRepository(AppDbContext context)
        {
            _context = context;
        }

        public void DeleteFromDatabase(int id)
        {
            var teacher = GetSingleFromDatabase(id);

            _context.Teachers.Remove(teacher);

            _context.SaveChanges();
        }

        public List<Teacher> GetListFromDatabase()
        {
            //facendo così carico prima tutti le righe dal database.
            //Sbagliato perché:
            // 1) più traffico di rete, perché carico tutto dal database
            // 2) più occupazione di RAM (devo creare un'istanza del model per ogni riga
            // 3) più occupazione di CPU perché i filtri sono fatti su l'intera collezione

            //var teachers = _context.Teachers.ToList();

            //var list = teachers
            //    .Where(t => t.Rating > 3)
            //    .ToList();

            //return list;

            //Expression<Func<Teacher, bool>> expr = x => x.Rating > 2;
            //Func<Teacher, bool> func = x => x.Rating > 2;

            ////questo non compila perché C# non converte
            ////qualsiasi metodo/delegate in Expression, ma solo le lambda
            //Expression<Func<Teacher, bool>> exprm = M;
            //Func<Teacher, bool> funcm = M;

            var list = _context.Teachers
                .Where(x => x.Rating > 2)
                //.Where(M) //avrebbe caricato tutti i Teacher dal database!
                .ToList();

            return list;
        }

        private bool M(Teacher t)
        {
            return t.Rating > 2;
        }

        public Teacher GetSingleFromDatabase(int id)
        {
            // meno bene: così cerco su tutta la lista,
            // invece di fermarmi alla prima occorrenza
            //var teacher = _context.Teachers
            //    .Where(x => x.Id == id)
            //    .First();

            // mi fermo alla prima occorrenza e la restituisco
            // senza andare avanti inutilmente nella lista
            //var teacher = _context.Teachers
            //   .First(x => x.Id == id);

            // cerco su tutta la lista
            // lancio errore se non trovo corrispondenze o ne trovo più di una
            var teacher = _context.Teachers
                .Single(x => x.Id == id);

            return teacher;
        }

        public void UpdateInDatabase(Teacher model)
        {
            if (model.Id == 0)
            {
                _context.Teachers.Add(model);
            }
            else
            {
                _context.Teachers.Update(model);
            }

            _context.SaveChanges();
        }
    }
}
