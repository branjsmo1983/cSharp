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
        private List<ICallStatusObserver> _observer;
        private readonly List<HeadSet> _headsets;
        private HeadSet _currentHeadSet;

        public Emulator()
        {
            _headsets = new List<HeadSet>
            {
                new Nokia3310(),
                new GalaxyS(),
                new Iphone6s()
            };

            _currentHeadSet = null;
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

            }
        }

        private bool IsModelSelected()
        {
            return _currentHeadSet != null;
        }

        public void AddCallStatusChangedObserver(ICallStatusObserver observer)
        {
            throw new NotImplementedException();
        }

        public void RemoveCallStatusChangedObserver(ICallStatusObserver observer)
        {
            throw new NotImplementedException();
        }

        public void NotifyCallStatus()
        {
            throw new NotImplementedException();
        }
    }
}
