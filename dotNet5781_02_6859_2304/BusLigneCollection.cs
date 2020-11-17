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
        private List<BusLigne> mylist;

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

            catch (Exception ex)   //no exception!
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
            foreach (BusLigne bus  in mylist)
            {
                bus.printStations();
            }
        }

        public void searchLines(string busStationid)
        {
            foreach (BusLigne item in mylist)
            {
               bool found= item.Search(busStationid);
                if(found)
                {
                    Console.WriteLine(item.Id,"  ");
                  
                }
                
            }
        }
        

        public void searchDirectLine(string departId,string arivalId)
        {

        }
       
    }
}

//index

