using Emulator.Cameras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator.HeadSets
{
    public abstract class HeadSet
    {
        internal enum CameraPosition { Front, Rear }

        ICamera _frontCamera;
        ICamera _rearCamera;

        internal ActionResult Call(string numberPhone)
        {
            return null;
        }

        internal ActionResult SendSMS(string numberPhone)
        {
            return null;
        }

        internal ActionResult ActivateCamera()
        {
            return null;

        }

        internal ActionResult DeactivateCamera()
        {
            return null;
        }

        internal ActionResult TakePicture(CameraPosition camPosition)
        {
            ICamera camera;
            if (camPosition == CameraPosition.Front)
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
}
