using HeadsetEmulator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey(true);
        }

        class EmulatorTester
        {
            readonly Emulator _emulator;




            internal void RunTests()
            {
                TestGetModels(); 
            }

            private void TestGetModels()  
            {
               
                var models = _emulator.GetModels();
                Debug.Assert(models.Count>3);
            }
        }
    }
}
