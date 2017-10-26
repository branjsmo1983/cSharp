

using System;

namespace HeadsetEmulator.Cameras
{
    internal class FiveMegapixelsCamera : ICamera
    {


        private bool _activated;
        public bool IsActive => _activated;

        /// <summary>
        /// 
        /// </summary>
        /// <returns>true if activated is ok</returns>
        public ActionResult Activate()
        {
            _activated = true;
            return new ActionResult(true, "activated is ok");
        }



        public ActionResult Deactivate()
        {
            _activated = false;
            return new ActionResult(true, "operation of deactivation is ok");
        }


        public Photo TakeSnap()
        {
            if (IsActive)
            {
                return new Photo();
            }
            else
            {
                throw new InvalidOperationException("Activate camera before take a photo");
            }
        }
    }
}