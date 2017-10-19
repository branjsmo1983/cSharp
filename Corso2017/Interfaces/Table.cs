using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Writers;

namespace Interfaces
{
    class Table : IAnnouncer
    {
        List<IWriter> _writers = new List<IWriter>();

        public void AddWriter(IWriter writer)
        {
            _writers.Add(writer);
        }

        public void Write()
        {
            foreach (IWriter writer in _writers)
            {
                writer.Write("Sono un tavolo");
            }
        }

        public void Write(TextWriter writer)
        {
            writer.WriteLine("Sono un tavolo");
        }

        //public void Write(IWriter writer)
        //{
        //    writer.Write("Sono un tavolo");
        //}
    }
}
