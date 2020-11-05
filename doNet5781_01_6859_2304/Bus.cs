using System;

namespace Assignment1
{
    public class Bus
    {
        const int FULLTANK = 1200;
        public readonly DateTime StartDate;
        private string license;
        private int km; // km traveled
        private int fuel = FULLTANK; // fuel capacity
        private DateTime checkUp;

        public int Km { get => km; set => km = value; }
        public int Fuel { get => fuel; set => fuel = value; }
        public DateTime Checkup { get => checkUp; set => checkUp = value; }

        // ctor
        public Bus()
        {
            Console.Write("Starting date: ");
            bool result = DateTime.TryParse(Console.ReadLine(), out StartDate);
            if (result == false)
            {
                throw new Exception("invalid DateTime string format");
            }
            Console.Write("License number: ");
            License = Console.ReadLine();
        }

        public string License
        {
            get
            {
                string first, middle, last;
                if (license.Length == 7)
                {
                    // xx-xxx-xx
                    first = license.Substring(0, 2);
                    middle = license.Substring(2, 3);
                    last = license.Substring(5, 2);
                    return string.Format("{0}-{1}-{2}", first, middle, last);
                }
                else
                {
                    // xxx-xx-xxx
                    first = license.Substring(0, 3);
                    middle = license.Substring(3, 2);
                    last = license.Substring(5, 3);
                    return string.Format("{0}-{1}-{2}", first, middle, last);
                }
            }

            private set
            {
                if ((StartDate.Year < 2018 && value.Length == 7) || (StartDate.Year >= 2018 && value.Length == 8))
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (value[i] < '0' || value[i] > '9')
                            throw new Exception("license not valid");
                    }
                    license = value;
                }
                else
                {
                    throw new Exception("license not valid");
                }
            }
        }

        public int Refuel()
        {
            int fuelToAdd = FULLTANK - Fuel;

            if (fuelToAdd > 0)
            {
                Fuel = FULLTANK;
                return fuelToAdd;
            }
            return 0;
        }

        public void Maintain()
        {
            checkUp = DateTime.Now;
        }

        public override string ToString()
        {
            return String.Format("license: {0,-10}, starting date: {1}, km: {2}", License, StartDate.Date, Km);
        }

    }

}