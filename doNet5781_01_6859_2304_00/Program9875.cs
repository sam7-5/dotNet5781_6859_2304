using System;

namespace doNet5781_01_6859_2304_00
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
