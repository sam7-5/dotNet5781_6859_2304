using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_6859_2304
{
    class BusStationLigne : BusStation  //inheritance
    {
        public readonly int DistancePreviousStations; //in metres
        public int distance { get; }

        public readonly int TimePreviousStations; //in minutes
        public int time { get; }

        //ctors according to inheritance
        public BusStationLigne(string key,int Distance, int Time ) : base(key)
        {
            DistancePreviousStations = Distance;
            TimePreviousStations = Time;
        }
        public BusStationLigne(string key, string adresse1, int Distance, int Time) : base(key, adresse1)
        {
            DistancePreviousStations = Distance;
            TimePreviousStations = Time;
        }

        public BusStationLigne() : base()
        {
            // we assume no more than 3KM between stations and no more than 10 minutes
            DistancePreviousStations = r.Next(500,3000);
            TimePreviousStations = r.Next(1,10);
        }

    }
}
