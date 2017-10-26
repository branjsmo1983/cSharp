using HeadsetEmulator.Cameras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsetEmulator.HeadSets
{
    class GalaxyS : HeadSet
    {
        internal override string Model => "GalaxyS";
        public GalaxyS()
        {
            _frontCamera = new NoCamera();
            _rearCamera = new FiveMegapixelsCamera();
        }
    }
}
