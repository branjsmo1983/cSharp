using Emulator.HeadSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator.Cameras
{
    internal class FiveMegaPixelsCamera : ICamera
    {
        private bool _activated;
        private bool IsActive => throw new System.NotImplementedException();

        public ActionResult Activate()   //attiva la fotocamera da 5 mpixel
        {
            
            _activated = true;   // ovviamente mette la variabile da false a true.
            //ActionResult result = new ActionResult(true, "Attivazione Ok");
            //return result;    equivale a dire
            return new ActionResult(true, "Activation Ok");

        }

        public ActionResult Deactivate()   //attiva la fotocamera da 5 mpixel
        {

            _activated = false;   // ovviamente mette la variabile da false a true.
            //ActionResult result = new ActionResult(true, "Attivazione Ok");
            //return result;    equivale a dire
            return new ActionResult(true, "Deactivation Ok");

        }
        public Photo TakeSnap()
        {
            if (IsActive) return new Photo();
            else throw new InvalidOperationException("Activate Camera before Taking a Snap");
        }
    }
}
