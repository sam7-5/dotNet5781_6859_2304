using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_6859_2304
{
    class BusLigne : IComparable
    {
        static public Random r = new Random(DateTime.Now.Millisecond);

        List<BusStationLigne> busStationLignes = new List<BusStationLigne>();
        int ligneId;
        public string Id { get; }
        BusStationLigne FirstStation;
        public int First { get; }
        BusStationLigne LastStation;
        public int Last { get; }
        Area place;

        // ctor without args
        // make 40 station of bus
        public BusLigne()
        {
            for (int i = 0; i < 40; i++)
            {
                busStationLignes.Add(new BusStationLigne());
            }
        }

        public BusLigne(string busid)
        {
            busStationLignes.Add(new BusStationLigne(busid));
        }

        BusLigne(BusStationLigne First, BusStationLigne Last, Area wplace)
        {
            ligneId = r.Next(100000, 999999);
            FirstStation = First; LastStation = Last; place = wplace;
        }

        BusLigne(int Id, BusStationLigne First, BusStationLigne Last, Area wplace)
        {
            ligneId = Id; FirstStation = First; LastStation = Last; place = wplace;
        }
        public override string ToString()
        {
            return "Ligne number:  " + ligneId + "first station:  "
                + FirstStation + "Last station:  " + LastStation + "Area:  " + place + busStationLignes.ToString();
        }

        public void addStationBegin(BusStationLigne bus)
        {
            busStationLignes.Insert(0, bus);
        }
        public void addStationEnd(BusStationLigne bus)
        {
            busStationLignes.Add(bus);              //default insert at the end
        }
        public void addStationMiddle(BusStationLigne bus)
        {
            int size = busStationLignes.Count();
            busStationLignes.Insert(size / 2, bus);
        }

        //public void deleteStationBegin(BusStationLigne bus)
        //{
        //    busStationLignes.RemoveAt(0);
        //}
        //public void deleteStationmiddle(BusStationLigne bus)
        //{
        //    int size = busStationLignes.Count();
        //    busStationLignes.RemoveAt(size / 2);
        //}
        //public void deleteStationEnd(BusStationLigne bus)
        //{
        //    int size = busStationLignes.Count();
        //    busStationLignes.RemoveAt(size);
        // }

        public void deleteStation(string stationKey)
        {
            try
            {
                BusStationLigne result = busStationLignes.Find(x => x.Key == stationKey);

                int index = busStationLignes.IndexOf(result);
                BusStationLigne update = busStationLignes.ElementAt(index + 1);
                update.distance = result.DistancePreviousStations + update.DistancePreviousStations;
                update.time = result.TimePreviousStations + update.TimePreviousStations;

                busStationLignes.Remove(result);
            }
            catch (ArgumentNullException arg)
            {
                Console.WriteLine(arg.Message);
            }
        }
        public bool Exist(BusStationLigne bus)
        {
            if (busStationLignes.Contains(bus))
                return true;
            return false;
        }

        int DistanceBetweenStations(BusStationLigne bus1, BusStationLigne bus2)
        {
            int count1 = 0;
            foreach (BusStationLigne item in busStationLignes.Take(busStationLignes.IndexOf(bus1)))
            {
                count1 += item.DistancePreviousStations;
            }

            int count2 = 0;
            foreach (BusStationLigne item in busStationLignes.Take(busStationLignes.IndexOf(bus2)))
            {
                count2 += item.DistancePreviousStations;
            }

            return Math.Abs(count2 - count1);
        }
        int TimeBetweenStations(BusStationLigne bus1, BusStationLigne bus2)
        {
            int count1 = 0;
            foreach (BusStationLigne item in busStationLignes.Take(busStationLignes.IndexOf(bus1)))
            {
                count1 += item.TimePreviousStations;
            }

            int count2 = 0;
            foreach (BusStationLigne item in busStationLignes.Take(busStationLignes.IndexOf(bus2)))
            {
                count2 += item.TimePreviousStations;
            }

            return Math.Abs(count2 - count1);
        }

        BusLigne subLigne(BusStationLigne bus1, BusStationLigne bus2)
        {
            BusLigne Sublist = new BusLigne(bus1, bus2, this.place);

            Sublist.busStationLignes =
                busStationLignes.GetRange(busStationLignes.IndexOf(bus1), busStationLignes.IndexOf(bus2));

            return Sublist;
        }

        public int CompareTo(object obj)  //compare total time between 2 lignes
        {
            BusLigne bus = (BusLigne)obj;
            int time1 = bus.TimeBetweenStations(bus.FirstStation, bus.LastStation);
            int time2 = this.TimeBetweenStations(this.FirstStation, this.LastStation);

            if (time1 > time2)
                return 1;

            else if (time1 == time2)
                return 0;

            else if (time1 < time2)
                return -1;

            return 9999;
        }
        public bool Search(string busStationId)
        {

            try
            {
                BusStationLigne result = busStationLignes.Find(x => x.Key == busStationId);

                return true;
            }

            catch (ArgumentNullException arg)
            {
                Console.WriteLine(arg.Message);
            }
            return false;
        }
        public void printStations()
        {
            foreach (BusStationLigne station in busStationLignes)
            {
                station.ToString();
                Console.WriteLine();
                string stationKey = station.Key;

            }
        }
    }
}
