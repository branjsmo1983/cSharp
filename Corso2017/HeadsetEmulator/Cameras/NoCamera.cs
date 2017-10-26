using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsetEmulator.Cameras
{
    internal class NoCamera : ICamera
    {
        public bool IsActive => false;

        public ActionResult Activate()
        {
            return new ActionResult(false,"No Camera Available");
        }

        public ActionResult Deactivate()
        {
            return new ActionResult(false, "Impossible to Deactivate a NoCamera Device");
        }

        public Photo TakeSnap()
        {

            throw new InvalidOperationException("impossible to take photo, Camera not available");

        }
    }
}
