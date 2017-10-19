using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.StatusWriters
{
    class ConsoleStatusWriter : IStatusWriter
    {
        public void DeviceStatusChanged(Device device)
        {
            Console.WriteLine($"{ device.Room } { device.DeviceType } is { device.Status }");
        }
    }
}
