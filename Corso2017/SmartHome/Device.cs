using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    public abstract class Device
    {
        protected bool _isOn;

        public Device(string room)
        {
            Room = room;
        }

        public string DeviceType { get; protected set; }

        public string Room { get; private set; }

        //public string GetStatus()
        //{
        //    return IsOn ? "on" : "off";
        //}

        public string Status
        {
            get
            {
                return _isOn ? "on" : "off";
            }
        }

        public bool TurnOn()
        {
            _isOn = true;

            return _isOn;
        }

        public bool TurnOff()
        {
            _isOn = false;

            return _isOn;
        }

        public abstract int CalculateConsumption();

        public abstract string GetDescription();

        //public virtual int CalculateConsumption()
        //{
        //    return 0;
        //}
    }
}
