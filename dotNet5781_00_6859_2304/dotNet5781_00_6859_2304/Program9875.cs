using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_00_6859_2304
{

    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome6859();
            Welcome2304();

            Console.ReadKey();
        }
        static partial void Welcome2304();
        private static void Welcome6859()
        {
            Console.WriteLine("Enter your name: ");
            String str = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", str);
        }
    }

}
