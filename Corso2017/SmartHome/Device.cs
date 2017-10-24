using SmartHome.StatusWriters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    public abstract class Device : IObservableDevice
    {
        public delegate void DeviceStatusChangedEventHandler(Device device);
        public event DeviceStatusChangedEventHandler StatusChanged;

        protected bool _isOn;

        private List<IStatusWriter> _subscribers = new List<IStatusWriter>();

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

        public void AddSubscriber(IStatusWriter writer)
        { 
            if (!_subscribers.Contains(writer))
                _subscribers.Add(writer);
        }

        public void RemoveSubscriber(IStatusWriter writer)
        {
            if (_subscribers.Contains(writer))
                _subscribers.Remove(writer);
        }

        public void NotifyStatusChanged()
        {
            if (StatusChanged != null)
                StatusChanged(this);

            foreach (IStatusWriter subscriber in _subscribers)
            {
                subscriber.DeviceStatusChanged(this);
            }
        }

        public bool TurnOn()
        {
            bool oldStatus = _isOn;
            _isOn = true;

            if (oldStatus != _isOn)
                NotifyStatusChanged();

            return _isOn;
        }

        public bool TurnOff()
        {
            bool oldStatus = _isOn;
            _isOn = false;

            if (oldStatus != _isOn)
                NotifyStatusChanged();

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
