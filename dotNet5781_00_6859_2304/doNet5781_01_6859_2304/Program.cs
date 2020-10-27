using System;
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

            switch (Console.ReadLine())
            {
                case "1":
                    Bus.addBus(busList);
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
    class Bus
    {
        private string busId;
        private DateTime dateInit;
        private int km;
        private int tank;

        public void SetBusId(string newId) { busId = newId; }
        public void SetDate(DateTime newDate) { dateInit = newDate; }
        public void SetKm(int newKm) { km = newKm; }
        public void SetTank(int newTank) { tank = newTank; }

        public string GetId() { return busId; }
        public DateTime GetDate() { return dateInit; }
        public int GetKm() { return km; }
        public int GetTank() { return tank; }

        public static void addBus(DateTime Date, string Id)
        {
            Bus bus = new Bus();
            bus.SetDate(Date);
            bus.SetBusId(Id);

        }
        public static Bus ChooseBus(string Id, LinkedList<Bus> busList)
        {
            //new Random(DateTime.Now.Millisecond)
            Bus gg = new Bus();
            gg = busList.First.Value;
            //while (gg.GetId != Id)
            //{
            //    str
            //}

            Console.WriteLine("ERROR id doesn't exist");
            return null;
        }
    }
} 