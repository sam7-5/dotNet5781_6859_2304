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
                        // input bus line
                        // busCollec.AddLigne();
                        break;

                    case Actions.ADD_STATION:
                        break;

                    case Actions.DELETE_LINE:
                        Console.WriteLine("enter the number of the bus line to delete: ");
                        // bus line input
                        //busCollec.DeleteLigne();
                        break;

                    case Actions.DELETE_STATION:
                        break;

                    case Actions.SEARCH_DIRECT_LINE:
                        Console.WriteLine("enter the number of the bus line to search: ");
                        break;

                    case Actions.PRINT_ALL_LINES:
                        break;

                    case Actions.PRINT_STATIONS:
                        break;

                    default:
                        break;
                }

            } while (action != Actions.EXIT);
        }
    }
}