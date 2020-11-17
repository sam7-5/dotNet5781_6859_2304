using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_6859_2304
{
    class Program
    {
        static void Main(string[] args)
        {
            BusLigneCollection busCollec = new BusLigneCollection();
            Actions action;
            bool result;
            Console.WriteLine("Welcome to the Bus Station manager !" + "\n");
            do
            {
                Console.WriteLine("Choose an action from:");
                foreach (Actions act in (Actions[])Enum.GetValues(typeof(Actions)))
                {
                    Console.WriteLine("\t" + act);
                }
                Console.WriteLine("Your choice: ");
                result = Enum.TryParse(Console.ReadLine(), out action);

                if (!result)
                {
                    Console.WriteLine("No such option\n");
                    continue;
                }

                switch (action)
                {
                    case Actions.ADD_LINE:
                        Console.WriteLine("enter the bus number to add: ");
                        string BusId = Console.ReadLine();
                        busCollec.AddLigne(new BusLigne(BusId));
                        break;

                    case Actions.ADD_STATION:
                        Console.WriteLine("enter the bus line id: ");
                        string idlin = Console.ReadLine();

                        Console.WriteLine("enter the bus new station id: ");
                        string idstat = Console.ReadLine();

                        Console.WriteLine("enter distance from last station: ");
                        int dis = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("enter time from last station: ");
                        int tim = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter at begining (1) middle (2) or end (3)?: ");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        busCollec.addStation(idlin, idstat, dis, tim, choice);
                        break;

                    case Actions.DELETE_LINE:
                        Console.WriteLine("enter the number of the bus line to delete: ");
                        string id1 = Console.ReadLine();
                        busCollec.DeleteLigne(id1);
                        break;

                    case Actions.DELETE_STATION:
                        Console.WriteLine("enter the bus line id: ");
                        string idlin1 = Console.ReadLine();

                        Console.WriteLine("enter the bus station id to delete: ");
                        string idstat1 = Console.ReadLine();

                        busCollec.DeleteStation(idlin1, idstat1);
                        break;

                    case Actions.SEARCH_DIRECT_LINE:
                        Console.WriteLine("enter the number of the departure bus station : ");
                        string depart = Console.ReadLine();
                        Console.WriteLine("enter the number of the arrival bus station : ");
                        string arrival = Console.ReadLine();

                        busCollec.searchDirectLine(depart, arrival);
                        break;

                    case Actions.SEARCH_LINE_NUMBER:
                        Console.WriteLine("enter the number of the bus line to search: ");
                        string id = Console.ReadLine();
                        busCollec.searchLines(id);
                        break;

                    case Actions.PRINT_ALL_LINES:
                        busCollec.PrintLines();
                        break;
                    case Actions.PRINT_STATIONS:
                        busCollec.PrintStations();
                        break;

                    default:
                        break;
                }

            } while (action != Actions.EXIT);
        }
    }
}