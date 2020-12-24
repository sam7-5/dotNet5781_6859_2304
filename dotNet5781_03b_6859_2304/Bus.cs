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

        //public Bus(string license, int km, DateTime startDate, int fuel)
        //{
        //    License = license;
        //    Kilometrage = km;
        //    StartDate = startDate;
        //    FuelTank = fuel;
        //}

        // return a list of ten buses with 3 aith problem
        static public List<Bus> CreateListOfBuses()
        {
            var buses = new List<Bus>();

            buses.Add(new Bus() { m_license = random.Next(1000000, 99999999).ToString(),
                m_kilometrage = random.Next(0, MAX_KM), DateLastCheck = new DateTime(2017, 1, 1), m_fuelTank = FULL_TANK });

            buses.Add(new Bus() { m_license = random.Next(1000000, 99999999).ToString(), 
                m_kilometrage = MAX_KM - 1000, DateLastCheck = DateTime.Now, m_fuelTank = FULL_TANK });

            buses.Add(new Bus() { m_license = random.Next(1000000, 99999999).ToString(),
                m_kilometrage = random.Next(0, MAX_KM), DateLastCheck = DateTime.Now, m_fuelTank = 400 });


            for (int i = 0; i < 7; i++)
            {
                buses.Add(item: new Bus() { m_license = random.Next(1000000, 99999999).ToString(),
                    m_kilometrage = random.Next(0, MAX_KM), StartDate = DateTime.Now, m_fuelTank = FULL_TANK });
            }
            return buses;
        }

        // the date the bus is in the bus company
        private DateTime m_startDate;
        public DateTime StartDate
        {
            get
            {
                return m_startDate; 

            }

            set { m_startDate = value; }
        }



       

        



        // how much fuel we have in the tank: travel capacity
        private int m_fuelTank;

        public int FuelTank
        {
            get
            {
                return m_fuelTank;
            }
            set
            {
                if (value > 0)
                {
                    m_fuelTank = value;
                }
            }
        }
        private string m_license;
        public string License
        {
            get
            {
                string first, middle, last;
                // xx-xxx-xx
                if (m_license.Length == 7)
                {
                    first = m_license.Substring(0, 2);
                    middle = m_license.Substring(2, 3);
                    last = m_license.Substring(5, 2);
                    return string.Format("{0}-{1}-{2}", first, last, middle);
                }
                // xxx-xx-xxx
                else
                {
                    first = m_license.Substring(0, 3);
                    middle = m_license.Substring(3, 2);
                    last = m_license.Substring(5, 3);
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
                    m_license = value;
                }
            }
        }

        public DateTime DateLastCheck 
        { get; set; }

        // Kilometrage since last check up
        private int m_kilometrage;
        public int Kilometrage
        {
            get
            {
                return m_kilometrage;
            }
            set
            {
                m_kilometrage += value;
            }
        }

        public override string ToString()
        {
            return String.Format("license: {0,-10}, km: {1}", m_license, m_kilometrage);
        }

        // does the bus need checkup ?
        private bool CanTravel()
        {
            if (m_kilometrage >= MAX_KM || m_fuelTank <= 0)
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
            if (this.CanTravel() && (kmToTravel <= m_fuelTank))
            {
                return true;
            }
            return false;
        }

        // ctors
        
        //public Bus(string license, int km = 0)
        //{
        //    License = license;
        //    Kilometrage = km;
        //    StartDate = DateTime.Now;
        //    FuelTank = FULL_TANK;
        //}

        
       

        public void Refuel()
        {
            m_fuelTank = FULL_TANK;
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
