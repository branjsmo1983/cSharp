using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsetEmulator.Events
{
    public interface ICallStatusNotifier
    {
        void AddCallStatusChangedObserver(ICallStatusObserver observer);
        void RemoveCallStatusChangedObserver(ICallStatusObserver observer);
        void NotifyCallStatus();
    }
}
