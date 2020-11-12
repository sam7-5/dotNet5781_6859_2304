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
                    case Actions.ADD:
                        break;

                    case Actions.DELETE:
                        break;

                    case Actions.SEARCH:
                        break;

                    default:
                        break;
                }

            } while (action != Actions.EXIT);

        }
    }
}