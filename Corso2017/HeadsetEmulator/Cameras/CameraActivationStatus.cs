using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsetEmulator.Cameras
{
    public class CameraActivationStatus
    {
        public bool Status { get; set; }
        public string Camera { get; set; }

        public CameraActivationStatus(bool status, string camera)
        {
            this.Status = status;
            this.Camera = camera;
        }
    }
}
