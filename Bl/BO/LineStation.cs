﻿namespace BO
{
    public class LineStation
    {
        public int LineId { get; set; }  
        public int Station { get; set; }
        public int LineStationIndex { get; set; }
        public int PrevStation { get; set; }
        public int NextStation { get; set; }
    }
}