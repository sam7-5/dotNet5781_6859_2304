using System;
using System.Collections.Generic;
using System.Linq;

namespace DO
{
    public class Line
    {
        public Line() {}
        public int ID { get; set; } // like bus 6 
        public int Code { get; set; } // a unique number
        public Enums.Area Area { get; set; }
        public int FirstStation { get; set; }
        public int LastStation { get; set; }

        public Line(int iD, int code, Enums.Area area, int firstStation, int lastStation)
        {
            ID = iD;
            Code = code;
            Area = area;
            FirstStation = firstStation;
            LastStation = lastStation;
        }
        public Line(Line line)
        {
            ID = line.ID;
            Code = line.Code;
            Area = line.Area;
            FirstStation = line.FirstStation;
            LastStation = line.LastStation;
        }
    }
}

