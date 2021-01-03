using System;

namespace BO
{
    public class AdjacentStations
    {
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
