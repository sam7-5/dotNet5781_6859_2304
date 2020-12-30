using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace dotNet5781_02_6859_2304
{
    class BusLineCollection : IEnumerable
    {
        static private List<BusLine> mylist;
        public BusLine this[int index]
        {
            get
            {
                try
                {
                    BusLine busLine = mylist.Find((x) => x.Id == index);
                    if (busLine == null)
                    {
                        throw new notFoundedBusLineException();
                    }
                    else
                        return busLine;


                }
                catch (notFoundedBusLineException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (ArgumentOutOfRangeException arg)
                {
                    Console.WriteLine(arg.Message);
                }
                return null;
            }
            set
            {
                mylist.Insert(index, value);
            }
        } //indexer
        // ctor to fill 10 bus with random values //
        static public Random r = new Random(DateTime.Now.Millisecond);
        public BusLineCollection()
        {
            mylist = new List<BusLine>();

            for (int i = 0; i < 10; i++)
            {
                mylist.Add(new BusLine());
            }
            for (int i = 0; i < 10; i++)
            {
                string temp = BusLine.existBus.ElementAt(40 - i);

                foreach (BusLine item in mylist)
                {
                    if (item.find(temp) != null)
                    {
                        BusStationLine result = item.find(temp);
                        mylist.ElementAt(i).addStationEnd(result);
                    }
                }

            }
        }
        public IEnumerator GetEnumerator()
        {
            return mylist.GetEnumerator();
        }

        public void AddLigne(BusLine ligne)
        {
            try
            {
                if (mylist.Contains(ligne))
                {
                    if (mylist.ElementAt(mylist.IndexOf(ligne)).First == ligne.Last)   //doute si ya besoin
                    {
                        mylist.Add(ligne);
                        //  throw new ArgumentOutOfRangeException("this ligne already exist");

                    }
                    else throw new ArgumentOutOfRangeException("this ligne already exist (and it is not the one in the opposite way)");
                }
                else
                    mylist.Add(ligne);
            }

            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void addStation(string lineId, string stationKey, int distance, int time, int choice)
        {
            try
            {
                BusLine result = mylist.Find(x => x.Id.ToString() == lineId);
                BusStationLine stationLigne = new BusStationLine(stationKey, distance, time);

                if (choice == 1)
                {
                    result.addStationBegin(stationLigne);
                }
                if (choice == 2)
                {
                    result.addStationMiddle(stationLigne);
                }
                if (choice == 3)
                {
                    result.addStationEnd(stationLigne);
                }
            }
            catch (ArgumentNullException arg)
            {
                Console.WriteLine(arg.Message);
            }

        }

        public void DeleteLigne(string line) //pas compris si ligne exist dans l'autre sens
        {
            try
            {
                BusLine result = mylist.Find(x => x.Id.ToString() == line);
                mylist.Remove(result);
            }

            catch (ArgumentNullException arg)
            {
                Console.WriteLine(arg.Message);
            }



        }
        public void DeleteStation(string lineId, string stationKey)
        {
            try
            {
                BusLine result = mylist.Find(x => x.Id.ToString() == lineId);
                result.deleteStation(stationKey);
            }
            catch (ArgumentNullException arg)
            {
                Console.WriteLine(arg.Message);
            }
        }

        public void PrintLines()      //all bus lines
        {
            foreach (BusLine item in mylist)
            {
                Console.WriteLine(item.ToString());
                item.ToStringBusStation();

                Console.WriteLine("\n");
            }
        }
        public void PrintStations()      //list of all bus stations with line numbers that passes it trough 
        {
            foreach (BusLine bus in mylist)
            {
                bus.printStations();
                Console.WriteLine();
            }
        }

        static public void searchLines(string busStationid)//all lines id that passes by this stations
        {
            foreach (BusLine item in mylist)
            {
                bool found = item.Search(busStationid);
                if (found)
                {
                    Console.WriteLine(item.Id.ToString(), "  ");

                }

            }
        }
        public void searchDirectLine(string departId, string arivalId)
        {
            foreach (BusLine line in mylist)
            {
                if (line.Exist(departId) && line.Exist(arivalId))
                {
                    Console.WriteLine("you can take line: {0} it will take : {1} minutes", line.Id, line.DistanceBetweenStations(departId, arivalId));
                }

            }
        }

    }
}



