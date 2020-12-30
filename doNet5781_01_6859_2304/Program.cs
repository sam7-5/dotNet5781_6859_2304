using System;
using System.Collections.Generic;

namespace Assignment1
{
    class Program
    {
        static Random r = new Random(DateTime.Now.Millisecond);
        static void Main(string[] args)
        {
            Actions action;
            List<Bus> buses = new List<Bus>();
            bool result;

            do
            {
                Console.WriteLine("Choose an action from:");
                foreach (Actions act in (Actions[])Enum.GetValues(typeof(Actions))) //in action?
                {
                    Console.WriteLine("\t" + act);
                }
                Console.Write("\nYour choice: ");
                result = Enum.TryParse(Console.ReadLine(), out action);
                if (!result)
                {
                    Console.WriteLine("no such option\n");
                    continue;
                }

                switch (action)
                {
                    case Actions.ADD:
                        try
                        {
                            buses.Add(new Bus());
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        foreach (Bus bus in buses)
                        {
                            Console.WriteLine(bus);
                        }

                        break;

                    case Actions.FIND:
                        try
                        {
                            FindBus(buses, Console.ReadLine());
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        foreach (Bus bus in buses)
                        {
                            Console.WriteLine(bus);
                        }

                        break;

                    case Actions.REFUEL:
                        try
                        {
                            RefuelBus(buses, Console.ReadLine());
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        foreach (Bus bus in buses)
                        {
                            Console.WriteLine(bus);
                        }

                        break;
                    case Actions.MAINTENANCE:


                        break;
                    default:
                        break;
                }

            } while (action != Actions.EXIT);
        }

        private static void RefuelBus(List<Bus> buses, string license)
        {
            Console.Write("\nEnter the bus license to refuel: ");

            if (!(buses.Exists(bus => (bus.License == license))))
            {
                throw new Exception("\nThe bus doesn't exist !");
            }

            Bus busToCheck = buses.Find(bus => (bus.License == license));

            busToCheck.Refuel();
        }

        private static void MaintenanceBus(List<Bus> buses, string license)
        {
            Console.Write("\nEnter the bus license to check up: ");

            if (!(buses.Exists(bus => (bus.License == license))))
            {
                throw new Exception("\nThe bus doesn't exist !");
            }

            Bus busToCheck = buses.Find(bus => (bus.License == license));


        }
        private static void FindBus(List<Bus> buses, string license)
        {
            Console.Write("\nEnter the bus license to search: ");

            if (!(buses.Exists(bus => (bus.License == license))))
            {
                throw new Exception("\nThe bus doesn't exist !");
            }

            Bus busToCheck = buses.Find(bus => (bus.License == license));
            int kmToTravel = r.Next(1, 200); // we suppose that a travel is no more than 200 km

            if (!(CanTravel(busToCheck, kmToTravel)))
            {
                throw new Exception("\nThe bus can not travel !\nYou must do a check up");
            }
            else // we can travel !
            {
                busToCheck.Km += kmToTravel;
                busToCheck.Fuel -= kmToTravel;
            }
        }

        // better placed in the Bus.cs File
        private static bool CanTravel(Bus bus, int kmToTravel)
        {
            var date = DateTime.Now.Year;

            if (date - bus.StartDate.Year >= 1 || bus.Km >= 20000 || bus.Fuel <= 0) // to much time on the road !
                return false;
            return true;
        }
    }
}
