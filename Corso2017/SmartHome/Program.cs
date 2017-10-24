using SmartHome.StatusWriters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    class Program
    {
        static void Foo(Device device)
        {

        }

        static void Main(string[] args)
        {
            IStatusWriter consoleWriter = new ConsoleStatusWriter();

            Device salonLamp = new Lamp("Salon");
            salonLamp.StatusChanged += consoleWriter.DeviceStatusChanged;

            //salonLamp.AddSubscriber(consoleWriter);
            //salonLamp.AddSubscriber(new ConsoleStatusWriter());

            salonLamp.TurnOn();
            salonLamp.TurnOff();

            Device kitchenFan = new Fan("Kitchen");
            kitchenFan.AddSubscriber(consoleWriter);
            kitchenFan.TurnOn();

            salonLamp.TurnOff();

            Device ledBathroomLamp = new LedLamp("Bathroom");
            ledBathroomLamp.AddSubscriber(consoleWriter);
            ledBathroomLamp.TurnOn();

            Device halogenBathroomLamp = new HalogenLamp("Bathroom");
            halogenBathroomLamp.AddSubscriber(consoleWriter);
            halogenBathroomLamp.TurnOn();

            Console.ReadLine();
        }
    }
}
