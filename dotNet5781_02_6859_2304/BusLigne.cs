﻿using System;
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
        static public List<string> existBus = new List<string>();
        List<BusStationLigne> busStationLignes = new List<BusStationLigne>();
        int ligneId;

        public int Id
        {
            get { return ligneId; }
            set { ligneId = value; }
        }

       // public int Id { get; set; }
        BusStationLigne FirstStation;
        public BusStationLigne First
        {
            get { return FirstStation; }
            set { FirstStation = value; }
        }
        //public int First { get; set; }
        public BusStationLigne LastStation;
       // public int Last { get; set; }
        public BusStationLigne Last
        {
            get { return LastStation; }
            set { LastStation = value; }
        }
        Area place;

        // ctor without args
        // make 40 station of bus
        public BusLigne()
        {
            string temp;
            for (int i = 0; i < 40; i++)
            {
                temp = Convert.ToString(r.Next(100000, 999999));
                existBus.Add(temp);
                busStationLignes.Add(new BusStationLigne(temp));
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
        public BusLigne(int Id, BusStationLigne First, BusStationLigne Last)
        {
            ligneId = Id; FirstStation = First; LastStation = Last;
            busStationLignes.Add(FirstStation);
            busStationLignes.Add(LastStation);
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
        public void addStationNew(BusStationLigne bus)
        {
            busStationLignes.Add(bus);
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
        public bool Exist(string bus)
        {
            BusStationLigne result = busStationLignes.Find(x => x.Key == bus);
            if (busStationLignes.Contains(result))
                return true;
            return false;
        }

        public int DistanceBetweenStations(string bus1, string bus2)
        {
            BusStationLigne result1 = busStationLignes.Find(x => x.Key == bus1);
            int count1 = 0;
            foreach (BusStationLigne item in busStationLignes.Take(busStationLignes.IndexOf(result1)))
            {
                count1 += item.DistancePreviousStations;
            }

            BusStationLigne result2 = busStationLignes.Find(x => x.Key == bus2);

            int count2 = 0;
            foreach (BusStationLigne item in busStationLignes.Take(busStationLignes.IndexOf(result2)))
            {
                count2 += item.DistancePreviousStations;
            }

            return Math.Abs(count2 - count1);
        }
        public int TimeBetweenStations(BusStationLigne bus1, BusStationLigne bus2)
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
        public BusStationLigne find(string busStationId)
        {

            try
            {
                BusStationLigne result = busStationLignes.Find(x => x.Key == busStationId);

                return result;
            }

            catch (ArgumentNullException arg)
            {
                Console.WriteLine(arg.Message);
            }
            return null;
        }
        public void printStations()
        {

            foreach (BusStationLigne station in busStationLignes)
            {
                station.ToString();
                Console.WriteLine();
                string stationKey = station.Key;
                BusLigneCollection.searchLines(stationKey);
            }
        }
    }
}
