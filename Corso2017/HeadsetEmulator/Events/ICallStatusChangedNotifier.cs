using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadsetEmulator.Events
{
    interface ICallStatusChangedNotifier
    {
        List<ICallStatusObserver> 

        void AddCallStatus();
        void RemoveCallStatus();
        void NotifyCallStatus(); /// l'interfaccia di un publisher ha sempre un Add - Remove - Notify
    }
}
