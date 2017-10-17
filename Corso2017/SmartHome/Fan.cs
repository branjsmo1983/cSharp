using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    class Fan : Device
    {
        public enum SpeedStep { Low, Normal, High }

        //private bool _isOn;

        public Fan(string room) : base(room)
        {
            //string baseRoom = base.Room;
            //string thisRoom = this.Room;

            this.DeviceType = "fan";
            this.Speed = SpeedStep.Low;
        }

        public SpeedStep Speed { get; internal set; }

        public override int CalculateConsumption()
        {
            if (_isOn)
            {
                switch (Speed)
                {
                    case SpeedStep.Low:
                        return 15;
                    case SpeedStep.Normal:
                        return 30;
                    case SpeedStep.High:
                        return 50;
                    default:
                        return 0;// base.CalculateConsumption();
                }
            }
            else
            {
                return 0; // base.CalculateConsumption();
            }
        }

        public override string GetDescription()
        {
            return $"Current fan speed: { this.Speed }";
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
