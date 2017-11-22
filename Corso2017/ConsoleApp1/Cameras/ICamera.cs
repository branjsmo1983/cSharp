using Emulator.HeadSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator.Cameras
{
    internal interface ICamera
    {
        Photo TakeSnap();
       
         bool isActive { get; }
         ActionResult Activate();
            
       
            
    }
    
    
}
