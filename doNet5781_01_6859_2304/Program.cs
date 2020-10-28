using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doNet5781_01_6859_2304
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }

        }

        public static LinkedList<Bus> busList = new LinkedList<Bus>();

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) add a bus to the bus list");
            Console.WriteLine("2) choose a bus to travel");
            Console.WriteLine("3) treatement of a bus");
            Console.WriteLine("4) print all the buses");
            Console.WriteLine("5) exit");

            String BusId;

            switch (Console.ReadLine())
            {
                case "1":
                    Bus.addBus(busList);
                    return true;

                case "2":
                    BusId = Console.ReadLine();
                    Bus.ChooseBus(BusId, busList);
                    return true;

                case "3":
                    BusId = Console.ReadLine();
                    Console.WriteLine("1) Refuel");
                    Console.WriteLine("2) Revision");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Bus.treatmentRefuel(BusId);
                            break;
                        case "2":
                            Bus.treatmentRevision(BusId);
                            break;
                    }
                    return true;

                case "4":
                    Bus.PrintAll();
                    return true;

                case "5":
                    return false;

                default:
                    return true;
            }
        }
    }
}
