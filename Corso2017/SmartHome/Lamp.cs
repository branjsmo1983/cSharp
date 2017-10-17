using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    public class Lamp : Device
    {
        //private bool _isOn;

        public Lamp(string room /*= "N/A"*/)  : base(room)
        {
            //if (string.IsNullOrEmpty(room))
            //    room = "N/A";
            
            //Room = room;
            this.DeviceType = "lamp";

            Intensity = 0;
        }

        public int Intensity { get; set; }

        public override int CalculateConsumption()
        {
            if (_isOn)
                return 50;
            else
                return 0;
        }

        public override string GetDescription()
        {
            return $"Current lamp intensity: { this.Intensity }";
        }

        //public string DeviceType { get; private set; }

        //public string Room { get; private set; }

        //public string GetStatus()
        //{
        //    return IsOn ? "on" : "off";
        //}

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

        //public bool TurnOn(int intensity)
        //{
        //    _isOn = true;
        //    //set intensity

        //    return _isOn;
        //}
    }
}
