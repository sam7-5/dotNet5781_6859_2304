using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotNet5781_02_6859_2304
{
    class BusLigneCollection : IEnumerable
    {
        static private List<BusLigne> mylist;
        public BusLigne this[int index]
        {
            get
            {
                try
                {
                    BusLigne pp = mylist.ElementAt(index);
                    return pp;


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
        } //index
        // ctor to fill 10 bus with random values //
        static public Random r = new Random(DateTime.Now.Millisecond);
        public BusLigneCollection()
        {
            mylist = new List<BusLigne>();

            for (int i = 0; i < 10; i++)
            {
                mylist.Add(new BusLigne());
            }
        }
        public IEnumerator GetEnumerator()
        {
            return mylist.GetEnumerator();
        }

        public void AddLigne(BusLigne ligne)
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
                BusLigne result = mylist.Find(x => x.Id == lineId);
                BusStationLigne stationLigne = new BusStationLigne(stationKey, distance, time);
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
                BusLigne result = mylist.Find(x => x.Id == line);
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
                BusLigne result = mylist.Find(x => x.Id == lineId);
                result.deleteStation(stationKey);
            }
            catch (ArgumentNullException arg)
            {
                Console.WriteLine(arg.Message);
            }
        }

        public void PrintLines()      //all bus lines
        {
            foreach (BusLigne item in mylist)
            {
                item.ToString();
                Console.WriteLine("\n");
            }
        }
        public void PrintStations()      //list of all bus station with line numbers that passes it trough 
        {
            foreach (BusLigne bus in mylist)
            {
                bus.printStations();

            }
        }

        static public void searchLines(string busStationid)//all lines id that passes by this stations
        {
            foreach (BusLigne item in mylist)
            {
                bool found = item.Search(busStationid);
                if (found)
                {
                    Console.WriteLine(item.Id, "  ");

                }

            }
        }
        public void searchDirectLine(string departId, string arivalId)
        {
            foreach (BusLigne line in mylist)
            {
                if (line.Exist(departId) && line.Exist(arivalId))
                {
                    Console.WriteLine("you can take line: {0} it will take : {1} minutes",line.Id, line.DistanceBetweenStations(departId, arivalId));
                }

            }
        }

    }
}



