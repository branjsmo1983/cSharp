using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    public class LedLamp : Lamp
    {
        public LedLamp(string room) : base(room)
        {
            this.DeviceType = "LED lamp";
        }

        public override int CalculateConsumption()
        {
            return Convert.ToInt32(base.CalculateConsumption() * 0.5);
        }
    }
}
