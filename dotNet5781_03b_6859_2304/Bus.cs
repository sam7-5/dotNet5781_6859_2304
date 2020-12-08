using System;
using System.Collections.Generic;
using System.Text;

namespace dotNet5781_03b_6859_2304
{
    // TO DO LIST:
    //  1. ctor of Bus( string id , int km) self puts date and set fuel to max capacity
    //  2. method that return make a list of 10 bus, CHECK the exercise !
    //  3. boolean method : does the bus can travel ?
    //  4. refuel and maintain method
    class Bus
    {
        // since the company begin to use the bus, not the constructon of the bus !
        
        public DateTime StartDate { get; set; }

        public int TotalKilometrage
        {
            get
            {
                return TotalKilometrage;
            }
            set
            {
                if (value > 0)
                {
                    TotalKilometrage = value;
                }
            }
        }

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
                TotalKilometrage += value;
                Kilometrage = value;
            }
        }

        public override string ToString()
        {
            return String.Format("license: {0,-10}, starting date: {1}, km: {2}", License, StartDate.Date, TotalKilometrage);
        }

    }

    /*
    class Test
    {
        static void Main()
        {
            Bus myBus = new Bus();
            myBus.FuelTank = 100;
        }
    }
    */
}
