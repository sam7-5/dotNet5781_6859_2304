using System;

namespace DO
{
    public class AdjacentStations
    {
        public AdjacentStations(int station1, int station2, double distance, TimeSpan time)
        {
            Station1 = station1;
            Station2 = station2;
            Distance = distance;
            Time = time;
        }
        
        #region
        private int station1;
        private int station2;
        private double distance;
        private TimeSpan time;
        #endregion

        #region properties 
        public int Station1 { get => station1; set { station1 = value; } }
        public int Station2 { get => station2; set { station2 = value; } }
        public double Distance { get => distance; set { distance = value; } }
        public TimeSpan Time { get => time; set { time = value; } }
        #endregion
    }
}
