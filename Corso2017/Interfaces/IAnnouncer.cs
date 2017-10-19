using Interfaces.Writers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    interface IAnnouncer
    {
        void AddWriter(IWriter writer);

        void Write();

        //void Write(IWriter writer);

        void Write(TextWriter writer);
    }
}
