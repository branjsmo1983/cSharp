using HeadsetEmulator.Cameras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsetEmulator.HeadSets
{
    class Iphone6s : HeadSet
    {
        internal override string Model => "Iphone6s";
        public Iphone6s()
        {
            _frontCamera = new FiveMegapixelsCamera();
            _rearCamera = new EightMegapixelCamera();
        }
    }
}
