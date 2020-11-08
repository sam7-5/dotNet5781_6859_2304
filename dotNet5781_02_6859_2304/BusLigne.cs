using assignement1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_6859_2304
{
    class BusLigne
    {
        static public Random r = new Random(DateTime.Now.Millisecond);

        List<BusStationLigne> busStationLignes = new List<BusStationLigne>();
        int ligneId;
        BusStationLigne FirstStation;
        BusStationLigne LastStation;
        Area place;

        BusLigne(BusStationLigne First, BusStationLigne Last, Area wplace)
        {

            ligneId = r.Next(100000, 999999);
            FirstStation = First; LastStation = Last; place = wplace;
        }
        BusLigne(int Id, BusStationLigne First, BusStationLigne Last, Area wplace) { ligneId = Id; FirstStation = First; LastStation = Last; place = wplace; }
        public override string ToString()
        {
            return "Ligne number:  " + ligneId + "first station:  "
                + FirstStation + "Last station:  " + LastStation + "Area:  " + place + busStationLignes.ToString();
        }

        void addStationBegin(BusStationLigne bus)
        {
            busStationLignes.Insert(0, bus);
        }
        void addStationEnd(BusStationLigne bus)
        {
            busStationLignes.Add(bus);              //default insert at the end

        }
        void addStationMiddle(BusStationLigne bus)
        {
            int size = busStationLignes.Count();
            busStationLignes.Insert(size / 2, bus);
        }

        void deleteStationBegin(BusStationLigne bus)
        {
            busStationLignes.RemoveAt(0);
        }
        void deleteStationmiddle(BusStationLigne bus)
        {
            int size = busStationLignes.Count();
            busStationLignes.RemoveAt(size / 2);
        }
        void deleteStationEnd(BusStationLigne bus)
        {
            int size = busStationLignes.Count();
            busStationLignes.RemoveAt(size);
        }

        bool Exist(BusStationLigne bus)
        {
            bool check = busStationLignes.Contains(bus);

            if (check)
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

        BusLigne subLigne(BusStationLigne bus1, BusStationLigne bus2)
        {
            BusLigne Sublist = new BusLigne(bus1, bus2, this.place);

            Sublist.busStationLignes = 
                busStationLignes.GetRange(busStationLignes.IndexOf(bus1), busStationLignes.IndexOf(bus2));

            return Sublist;
        }

    }


}
