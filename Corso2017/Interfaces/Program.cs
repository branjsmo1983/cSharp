using Interfaces.Writers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IAnnouncer> announcers = new List<IAnnouncer>
            {
                new Book(),
                new Table()
            };

            //IWriter writer = new ConsoleWriter();
            //IAnnouncer book = announcers[0];
            IWriter consoleWriter = new ConsoleWriter();
            IWriter debugWriter = new DebugWriter();

            announcers[0].AddWriter(consoleWriter);
            announcers[0].AddWriter(debugWriter);

            announcers[1].AddWriter(consoleWriter);
            announcers[1].AddWriter(debugWriter);

            //book.Write();

            foreach (IAnnouncer announcer in announcers)
            {
                //announcer.Write(Console.Out);

                //announcer.Write(writer);

                announcer.Write();
            }

            Console.ReadKey(true);
        }
    }
}
