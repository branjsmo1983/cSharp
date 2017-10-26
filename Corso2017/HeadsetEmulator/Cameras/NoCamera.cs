using System;

namespace HeadsetEmulator.Cameras
{
    internal class NoCamera : ICamera
    {
        public bool IsActive => false;

        public ActionResult Activate()
        {
            return new ActionResult(false, "No camera available");
        }

        public ActionResult Deactivate()
        {
            return new ActionResult(false, "No camera available");
        }

        public Photo TakeSnap()
        {
            throw new InvalidOperationException("Impossible to take photo, there is no camera available");
        }
    }
}
