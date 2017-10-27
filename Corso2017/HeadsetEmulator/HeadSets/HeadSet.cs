using HeadsetEmulator.Cameras;
using System;

namespace HeadsetEmulator.HeadSets
{
    internal abstract class HeadSet
    {
        private const double MAX_CHAR_PER_SMS = 160;
        protected ICamera _frontCamera;
        protected ICamera _rearCamera;
        private DateTime _callTime = DateTime.MinValue;

        internal enum CameraPosition { Front, Rear }

        internal abstract string Model { get; }

        internal ActionResult Call(string phoneNumber)
        {
            ActionResult result;
            if (_callTime != DateTime.MinValue)
            {
                _callTime = DateTime.Now;
                result = new ActionResult(true, "Call start at time " + _callTime.ToString());
            }
            else
            {
                result = new ActionResult(false, "Call already exist");
            }

            return result;
        }

        internal ActionResult HangUp()
        {
            ActionResult result;
            DateTime endTime = DateTime.Now;
            if (_callTime != DateTime.MinValue)
            {
                TimeSpan callDuration = endTime - _callTime;
                result = new ActionResult(true,  $"Call ends with duration {callDuration.Hours} hours, {callDuration.Minutes} minutes and {callDuration.Seconds} seconds ");
                _callTime = DateTime.MinValue;
            }
            else
            {
                result = new ActionResult(false, "Call not exists");
            }
            
            return result;

        }

        internal ActionResult SendSMS(string phoneNumber, string textMessage)
        {
            double messageNumber=textMessage.Length / MAX_CHAR_PER_SMS;
            int roundedNumber = (int)Math.Ceiling(messageNumber);

            return new ActionResult(true, $"Sms Sent to number {phoneNumber} with {roundedNumber} messages");
        }

        internal ActionResult ActivateCamera(CameraPosition camPosition)
        {
            ICamera camera = GetCamera(camPosition);
            return camera.Activate();
        }

        internal ActionResult DeactivateCamera(CameraPosition camPosition)
        {
            ICamera camera = GetCamera(camPosition);
            return camera.Deactivate();
        }

        internal ActionResult TakePicture(CameraPosition camPosition)
        {
            ICamera camera = GetCamera(camPosition);

            ActionResult result = camera.Activate();
            if (result.Success)
            {
                Photo photo = camera.TakeSnap();
                return new ActionResult(true, "Photo successfully taken");
            }
            else
            {
                return new ActionResult(false, "No photo was taken. Camera is not active");
            }
        }

        private ICamera GetCamera(CameraPosition camPosition)
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

            return camera;
        }
    }
}
