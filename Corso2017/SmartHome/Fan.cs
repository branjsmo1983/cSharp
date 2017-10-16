using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    class Fan : Device
    {
        //private bool _isOn;

        public Fan(string room) : base(room)
        {
            //string baseRoom = base.Room;
            //string thisRoom = this.Room;

            this.DeviceType = "fan";
        }

        //public string DeviceType { get; private set; }

        //public string Room { get; private set; }

        //public string Status
        //{
        //    get
        //    {
        //        return _isOn ? "on" : "off";
        //    }
        //}

        //public bool TurnOn()
        //{
        //    _isOn = true;

        //    return _isOn;
        //}

        //public bool TurnOff()
        //{
        //    _isOn = false;

        //    return _isOn;
        //}
    }
}
