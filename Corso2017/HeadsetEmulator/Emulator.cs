using HeadsetEmulator.Events;
using HeadsetEmulator.HeadSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsetEmulator
{
    public class Emulator : ICallStatusNotifier
    {
        private List<ICallStatusObserver> _observers;
        private readonly List<HeadSet> _headsets;
        private HeadSet _currentHeadSet;

        public delegate void CameraActivationHandler(CameraActivationStatus status);
        public event CameraActivationHandler CameraActivation;

        public Emulator()
        {
            _headsets = new List<HeadSet>
            {
                new Nokia3310(),
                new GalaxyS(),
                new Iphone6s()
            };

            _currentHeadSet = null;
            _observers = new List<ICallStatusObserver>();
        }

        public List<string> GetModels()
        {
            List<string> result = new List<string>();
            foreach (HeadSet cell in _headsets)
            {
                result.Add(cell.Model);
            }
            return result;
        }

        public void SetCurrentHeadset(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException("The given model is null or empty", nameof(model));
            }
            HeadSet localHeadSet = null;
            foreach (HeadSet cell in _headsets)
            {
                if (model == cell.Model)
                {
                    localHeadSet = cell;
                    break;
                }
            }

            if (localHeadSet != null)
            {
                _currentHeadSet = localHeadSet;
            }
            else
            {
                throw new ArgumentException($"The given model [{model}] is invalid", nameof(model));
            }
        }

        public void Call(string number)
        {

            if (IsModelSelected())
            {
                ActionResult action = _currentHeadSet.Call(number);
                NotifyCallStatus(new CallStatus
                {
                    Status = action.Success,
                    PhoneNumber = number
                });
            }
        }

        private bool IsModelSelected()
        {
            return _currentHeadSet != null;
        }

        public void ActiveRearCamera()
        {
            if (IsModelSelected())
            {
                ActionResult result = _currentHeadSet.ActivateCamera(HeadSet.CameraPosition.Rear);
                OnCameraActivation(new CameraActivationStatus
                {
                    IsActive = result.Success,
                    CameraType = HeadSet.CameraPosition.Rear.ToString()
                });
            }
            else
            {
                throw new InvalidOperationException("No model selected");
            }
        }

        private void OnCameraActivation(CameraActivationStatus cameraActivationStatus)
        {
            if (CameraActivation != null)
            {
                CameraActivation(cameraActivationStatus);
            }
        }

        public void AddCallStatusChangedObserver(ICallStatusObserver observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }

        public void RemoveCallStatusChangedObserver(ICallStatusObserver observer)
        {
            if (_observers.Contains(observer))
                _observers.Remove(observer);
        }

        private void NotifyCallStatus(CallStatus status)
        {
            foreach (var observer in _observers)
            {
                observer.CallStatusChanged(status);
            }
        }
    }
}
