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
        List<BusStationLigne> busStationLignes = new List<BusStationLigne>();
        string ligneId;
        BusStationLigne FirstStation;
        BusStationLigne LastStation;
        Area place;

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
            busStationLignes.RemoveAt(size/2);              
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

            int index1 = busStationLignes.IndexOf(bus1);
            int count1 = 0;
            foreach (BusStationLigne item in busStationLignes.Take(index1))
            {
                count1 += item.DistancePreviousStations;
            }

            int index2 = busStationLignes.IndexOf(bus1);
            int count2 = 0;
            foreach (BusStationLigne item in busStationLignes.Take(index2))
            {
                count2 += item.DistancePreviousStations;
            }


            return Math.Abs(count2 - count1);
        }
    }
}
