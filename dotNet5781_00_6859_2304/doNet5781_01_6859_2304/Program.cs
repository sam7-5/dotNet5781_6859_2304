﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace doNet5781_01_6859_2304
{
    class Program
    {
	
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu){
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

            switch(Console.Read())
            {
                case "1":
                //add
                return true;

                case "2":
                //choose
                return true;
               
                case "3":
                //treatement
                return true;
                
                case "4":
                // print
                return true;

                case "5":
                return false;

                default:
                return true;
            }
    }
} 