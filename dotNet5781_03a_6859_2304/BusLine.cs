using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_6859_2304
{
    class BusLine : IComparable
    {
        static public Random r = new Random(DateTime.Now.Millisecond);
        static public List<string> existBus = new List<string>();
        List<BusStationLine> busStationLignes = new List<BusStationLine>();
        int ligneId;

        public int Id
        {
            get { return ligneId; }
            set { ligneId = value; }
        }


        BusStationLine FirstStation;
        public BusStationLine First
        {
            get { return FirstStation; }
            set { FirstStation = value; }
        }

        public BusStationLine LastStation;

        public BusStationLine Last
        {
            get { return LastStation; }
            set { LastStation = value; }
        }
        Area place;

        // make 40 station of bus
        public BusLine()
        {
            string temp;
            for (int i = 0; i < 40; i++)
            {
                ligneId = r.Next(10, 999);
                temp = Convert.ToString(ligneId);
                existBus.Add(temp);

                FirstStation = new BusStationLine(r.Next(100000, 999999).ToString(), r.Next(), r.Next());
                LastStation = new BusStationLine(r.Next(100000, 999999).ToString(), r.Next(), r.Next());
                busStationLignes.Add(FirstStation);
                busStationLignes.Add(LastStation);
            }

        }

        public BusLine(string busid)
        {

            busStationLignes.Add(new BusStationLine(busid));
        }

        BusLine(BusStationLine First, BusStationLine Last, Area wplace)
        {
            ligneId = r.Next(100000, 999999);
            FirstStation = First; LastStation = Last; place = wplace;
        }
        public BusLine(int Id, BusStationLine First, BusStationLine Last)
        {
            ligneId = Id; FirstStation = First; LastStation = Last;
            busStationLignes.Add(FirstStation);
            busStationLignes.Add(LastStation);
        }
        BusLine(int Id, BusStationLine First, BusStationLine Last, Area wplace)
        {
            ligneId = Id; FirstStation = First; LastStation = Last; place = wplace;
        }
        public void ToStringBusStation()
        {
            foreach (BusStationLine item in busStationLignes)
            {
                Console.WriteLine(item.ToString());

            }

        }
        public override string ToString()
        {
            return "Ligne number:  " + Id + "\nfirst station:  "
                + First + "\nLast station:  " + Last + "\nArea:  " + place + "\n";
        }
        public void addStationNew(BusStationLine bus)
        {
            busStationLignes.Add(bus);
        }
        public void addStationBegin(BusStationLine bus)
        {
            busStationLignes.Insert(0, bus);
        }
        public void addStationEnd(BusStationLine bus)
        {
            busStationLignes.Add(bus);              //default insert at the end
        }
        public void addStationMiddle(BusStationLine bus)
        {
            int size = busStationLignes.Count();
            busStationLignes.Insert(size / 2, bus);
        }


        public void deleteStation(string stationKey)
        {
            try
            {
                BusStationLine result = busStationLignes.Find(x => x.Key == stationKey);

                int index = busStationLignes.IndexOf(result);
                BusStationLine update = busStationLignes.ElementAt(index + 1);
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
            try
            {
                BusStationLine result = busStationLignes.Find(x => x.Key == bus);
                return true;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;

        }

        public int DistanceBetweenStations(string bus1, string bus2)
        {
            BusStationLine result1 = busStationLignes.Find(x => x.Key == bus1);
            int count1 = 0;
            foreach (BusStationLine item in busStationLignes.Take(busStationLignes.IndexOf(result1)))
            {
                count1 += item.DistancePreviousStations;
            }

            BusStationLine result2 = busStationLignes.Find(x => x.Key == bus2);

            int count2 = 0;
            foreach (BusStationLine item in busStationLignes.Take(busStationLignes.IndexOf(result2)))
            {
                count2 += item.DistancePreviousStations;
            }

            return Math.Abs(count2 - count1);
        }
        public int TimeBetweenStations(BusStationLine bus1, BusStationLine bus2)
        {
            int count1 = 0;
            foreach (BusStationLine item in busStationLignes.Take(busStationLignes.IndexOf(bus1)))
            {
                count1 += item.TimePreviousStations;
            }

            int count2 = 0;
            foreach (BusStationLine item in busStationLignes.Take(busStationLignes.IndexOf(bus2)))
            {
                count2 += item.TimePreviousStations;
            }

            return Math.Abs(count2 - count1);
        }

        BusLine subLigne(BusStationLine bus1, BusStationLine bus2)
        {
            BusLine Sublist = new BusLine(bus1, bus2, this.place);

            Sublist.busStationLignes =
                busStationLignes.GetRange(busStationLignes.IndexOf(bus1), busStationLignes.IndexOf(bus2));

            return Sublist;
        }

        public int CompareTo(object obj)  //compare total time between 2 lignes
        {
            BusLine bus = (BusLine)obj;
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


            foreach (BusStationLine item in busStationLignes)
            {
                if (item.Key == busStationId)
                {
                    return true;
                }
            }
         
            return false;
        }
        public BusStationLine find(string busStationId)
        {

            try
            {
                BusStationLine result = busStationLignes.Find(x => x.Key == busStationId);

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

            foreach (BusStationLine station in busStationLignes)
            {
                Console.WriteLine("\r\n" + station.ToString());

                string stationKey = station.Key;
                BusLineCollection.searchLines(stationKey);
            }
        }
    }
}
