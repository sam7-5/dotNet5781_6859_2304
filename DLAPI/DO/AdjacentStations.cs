using System;

namespace DO
{
    public class AdjacentStations
    {
        public AdjacentStations(int station1, int station2, double distance,  TimeSpan time)
        {
            Station1 = station1;
            Station2 = station2;
            Distance = distance;
            Time = time;
        }
         
        public int Station1 { get; set; }
        public int Station2 { get; set;}
        public double Distance { get; set;}
        public TimeSpan Time { get; set;} // distance from previous station
    }
}