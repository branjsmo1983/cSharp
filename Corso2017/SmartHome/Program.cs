using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    class Program
    {
        void NonStaticMethod()
        {

        }

        static void Main(string[] args)
        {
            //Device d = new Device("");

            Device salonLamp = new Lamp("Salon");
            
            //salon.Room = "Salon";
            //string status = salon.IsOn ? "on" : "off";

            WriteStatus(salonLamp);
            salonLamp.TurnOn();
            WriteStatus(salonLamp);

            //Lamp kitchenLamp = new Lamp("Kitchen");
            //WriteStatus(kitchenLamp);

            //Lamp kitchenBackup = kitchenLamp;
            ////kitchenLamp = salonLamp;
            //kitchenLamp.TurnOff();

            //WriteStatus(salonLamp);

            Device kitchenFan = new Fan("Kitchen");
            WriteStatus(kitchenFan);
            kitchenFan.TurnOn();
            WriteStatus(kitchenFan);

            Device ledBathroomLamp = new LedLamp("Bathroom");
            
            Lamp l = (Lamp)ledBathroomLamp;
            //invalid cast
            //Fan f = (Fan)ledBathroomLamp;
            
            WriteStatus(ledBathroomLamp);
            ledBathroomLamp.TurnOn();
            WriteStatus(ledBathroomLamp);

            Device halogenBathroomLamp = new HalogenLamp("Bathroom");
            WriteStatus(halogenBathroomLamp);
            halogenBathroomLamp.TurnOn();
            WriteStatus(halogenBathroomLamp);

            Console.ReadLine();
        }

        private static void WriteStatus(Device device)
        {
            //string deviceType = string.Empty;
            //if (device is Lamp)
            //{
            //    deviceType = "lamp";
            //}
            //else if (device is Fan)
            //{
            //    deviceType = "fan";
            //}
            string deviceType = device.DeviceType;

            Console.WriteLine($"{ device.Room } { deviceType } is { device.Status }, consumption: { device.CalculateConsumption() }");
            Console.WriteLine(device.GetDescription());
            //if (device is Lamp)
            //{
            //    Lamp currentLamp = (Lamp)device;
            //    Console.WriteLine($"Current lamp intensity: { currentLamp.Intensity }");
            //}
            //else if (device is Fan)
            //{
            //    Fan currentFan = (Fan)device;
            //    Console.WriteLine($"Current fan speed: { currentFan.Speed }");
            //}
        }

        //private static void WriteStatus(Lamp lamp)
        //{
        //    Console.WriteLine($"{ lamp.Room } lamp is { lamp.Status }");
        //}

        //private static void WriteStatus(Fan fan)
        //{
        //    Console.WriteLine($"{ fan.Room } fan is { fan.Status }");
        //}
    }
}
