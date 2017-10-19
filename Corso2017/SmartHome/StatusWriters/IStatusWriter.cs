using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.StatusWriters
{
    public interface IStatusWriter
    {
        void DeviceStatusChanged(Device device);
    }
}
