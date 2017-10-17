using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    public class HalogenLamp : Lamp
    {
        public HalogenLamp(string room) : base(room)
        {
            base.DeviceType = "Halogen lamp";
        }

        public override int CalculateConsumption()
        {
            return base.CalculateConsumption() * 2;
        }
    }
}
