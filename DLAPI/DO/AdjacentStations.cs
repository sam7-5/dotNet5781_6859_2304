using System;

namespace DO
{
    public class AdjacentStations
    {
        public AdjacentStations() { }
        public AdjacentStations(int station1, int station2, double distance,  TimeSpan time)
        {
            Station1 = station1;
            Station2 = station2;
            Distance = distance;
            Time = time;
        }
        public AdjacentStations(AdjacentStations adjacentStations)
        {
            Station1 = adjacentStations.Station1;
            Station2 = adjacentStations.Station2;
            Distance = adjacentStations.Distance;
            Time = adjacentStations.Time;
        }

        public int Station1 { get; set; }
        public int Station2 { get; set;}
        public double Distance { get; set;}
        public TimeSpan Time { get; set;} 
    }
}