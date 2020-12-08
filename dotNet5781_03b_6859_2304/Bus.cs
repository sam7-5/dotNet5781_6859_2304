using System;
using System.Collections.Generic;
using System.Text;

namespace dotNet5781_03b_6859_2304
{
    // TO DO LIST:
    //  1. ctor of Bus( string id , int km) self puts date and set fuel to max capacity => DONE !
    //  2. method that return make a list of 10 bus, CHECK the exercise ! => DONE !
    //  3. boolean method : does the bus can travel ? => DONE !
    //  4. refuel and maintain method => DONE !
    class Bus
    {
        static readonly int FULL_TANK = 1200;
        static readonly int MAX_KM = 20000;
        static private Random random = new Random(DateTime.Now.Millisecond);

        // return a list of ten buses with 3 aith problem
        static public List<Bus> CreateListOfBuses()
        {
            var buses = new List<Bus>();

            buses.Add(new Bus() { License = random.Next(1000000, 99999999).ToString(), Kilometrage = random.Next(0, MAX_KM), DateLastCheck = new DateTime(2017, 1, 1), FuelTank = FULL_TANK });
            buses.Add(new Bus() { License = random.Next(1000000, 99999999).ToString(), Kilometrage = MAX_KM - 1000, DateLastCheck = DateTime.Now, FuelTank = FULL_TANK });
            buses.Add(new Bus() { License = random.Next(1000000, 99999999).ToString(), Kilometrage = random.Next(0, MAX_KM), DateLastCheck = DateTime.Now, FuelTank = 400 });


            /*
            var b1 = new Bus(random.Next(1000000, 99999999).ToString(), random.Next(0, MAX_KM), new DateTime(2017, 1, 1), FULL_TANK);
            var b2 = new Bus(random.Next(1000000, 99999999).ToString(), MAX_KM - 1000, DateTime.Now, FULL_TANK);
            var b3 = new Bus(random.Next(1000000, 99999999).ToString(), random.Next(0, MAX_KM), DateTime.Now, 500);
            
            buses.Add(b1);
            buses.Add(b2);
            buses.Add(b3);

            */

            for (int i = 0; i < 7; i++)
            {
                //buses.Add(new Bus(random.Next(1000000, 99999999).ToString(), random.Next(0, MAX_KM), DateTime.Now, FULL_TANK));
                buses.Add(item: new Bus() { License = random.Next(1000000, 99999999).ToString(), Kilometrage = random.Next(0, MAX_KM), StartDate = DateTime.Now, FuelTank = FULL_TANK });

            }
            return buses;
        }

        // the date the bus is in the bus company
        public DateTime StartDate { get; set; }

        // how much fuel we have in the tank: travel capacity
        public int FuelTank
        {
            get
            {
                return FuelTank;
            }
            set
            {
                if (value > 0)
                {
                    FuelTank = value;
                }
            }
        }
        public string License
        {
            get
            {
                string first, middle, last;
                // xx-xxx-xx
                if (License.Length == 7)
                {
                    first = License.Substring(0, 2);
                    middle = License.Substring(2, 3);
                    last = License.Substring(5, 2);
                    return string.Format("{0}-{1}-{2}", first, last, middle);
                }
                // xxx-xx-xxx
                else
                {
                    first = License.Substring(0, 3);
                    middle = License.Substring(3, 2);
                    last = License.Substring(5, 3);
                    return string.Format("{0}-{1}-{2}", first, last, middle);
                }
            }

            set
            {
                if ((StartDate.Year < 2018 && value.Length == 7) || (StartDate.Year >= 2018 && value.Length == 8))
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (value[i] < '0' || value[i] > '9')
                        {
                            throw new Exception("invalide license format !"); // to implemente a derived exeption class
                        }
                    }
                    License = value;
                }
            }
        }
        public DateTime DateLastCheck { get; set; }

        // Kilometrage since last check up
        public int Kilometrage
        {
            get
            {
                return Kilometrage;
            }
            set
            {
                Kilometrage += value;
            }
        }

        public override string ToString()
        {
            return String.Format("license: {0,-10}, starting date: {1}, km: {2}", License, StartDate.Date, Kilometrage);
        }

        // does the bus need checkup ?
        private bool CanTravel()
        {
            if (Kilometrage >= MAX_KM || FuelTank <= 0)
            {
                return false;
            }
            if ((DateLastCheck.Year - StartDate.Year > 1) && (DateTime.Now.Year - DateLastCheck.Year > 1))
            {
                return false;
            }
            return true;
        }

        public bool CanTravel(int kmToTravel)
        {
            if (this.CanTravel() && (kmToTravel <= FuelTank))
            {
                return true;
            }
            return false;
        }

        // ctors
        /*
        public Bus(string license, int km = 0)
        {
            License = license;
            Kilometrage = km;
            StartDate = DateTime.Now;
            FuelTank = FULL_TANK;
        }

        public Bus(string license, int km, DateTime startDate, int fuel)
        {
            License = license;
            Kilometrage = km;
            StartDate = startDate;
            FuelTank = fuel;
        }
        */

        public void Refuel()
        {
            FuelTank = FULL_TANK;
        }
        public void Maintain()
        {
            DateLastCheck = DateTime.Now;
        }
    }

    
    //class Test
    //{
    //    static void Main()
    //    {
    //        var buses = Bus.CreateListOfBuses();

    //        foreach (var bus in buses)
    //        {
    //            Console.WriteLine(bus.ToString());
    //        }
    //    }
    //}
}
