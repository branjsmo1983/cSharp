using HeadsetEmulator.Cameras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsetEmulator.HeadSets
{
    internal abstract class HeadSet
    {
        protected ICamera _frontCamera;
        protected ICamera _rearCamera;

        internal enum CameraPosition { Front, Rear }

        internal abstract string Model { get; }

        internal ActionResult Call(string phoneNumber)
        {
            return null;
        }

        internal ActionResult HangUp()
        {
            return null;
        }

        internal ActionResult SendSMS(string phoneNumber, string textMessage)
        {
            return null;
        }

        internal ActionResult ActivateCamera(CameraPosition camPosition)
        {
            return null;
        }

        internal ActionResult DeactivateCamera(CameraPosition camPosition)
        {
            return null;
        }

        internal ActionResult TakePicture(CameraPosition camPosition)
        {
            ICamera camera;
            if (CameraPosition.Front == camPosition)
            {
                camera = _frontCamera;
            }
            else
            {
                camera = _rearCamera;
            }

            ActionResult result = camera.Activate();
            if (result.Success)
            {
                Photo photo = camera.TakeSnap();
                return new ActionResult(true, "Photo Taked");
            }
            else
            {
                return new ActionResult(false, "No Photo Taked");
            }
        }
           
    }
}
