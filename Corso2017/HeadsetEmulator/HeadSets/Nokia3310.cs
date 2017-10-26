using HeadsetEmulator.Cameras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsetEmulator.HeadSets
{
    class Nokia3310 : HeadSet
    {
        internal override string Model => "Nokia 3310";
        public Nokia3310()
        {
            _frontCamera = new NoCamera();
            _rearCamera = new NoCamera();
        }
    }
}
