using SmartHome.StatusWriters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    interface IObservableDevice
    {
        void AddSubscriber(IStatusWriter writer);
        void RemoveSubscriber(IStatusWriter writer);

        void NotifyStatusChanged();
    }
}
