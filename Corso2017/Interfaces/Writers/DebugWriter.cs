using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Writers
{
    class DebugWriter : IWriter
    {
        public void Write(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
