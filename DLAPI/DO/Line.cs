using System;
using System.Collections.Generic;
using System.Linq;

namespace DO
{
    public class Line
    {
        #region attributes
      
        private List<LineTrip> linesOnTrip;
        private List<BusOnTrip> buses;
            
        private  int lineID;
        private int code;
        private Enums.Area area;
        private int firstStation;
        private int lastStation;
        #endregion

        #region properties
        public int ID{ get => lineID; set { lineID = value; } }
        public int Code { get => code; set { code = value; } }
        public Enums.Area Area { get => area; set { area = value; } }
        public int FirstStation { get => firstStation; set { firstStation = value; } }
        public int LastStation { get => lastStation; set { lastStation = value; } }
        #endregion

        Line() 
        {
            linesOnTrip = new List<LineTrip>();
            buses = new List<BusOnTrip>();
        }

        public Line(int iD, int code, Enums.Area area, int firstStation, int lastStation):this()
        {
            ID = iD;
            Code = code;
            Area = area;
            FirstStation = firstStation;
            LastStation = lastStation;
        }

        internal IEnumerable<LineTrip> GetTrips()
        {
            return this.linesOnTrip;
        }

        internal IEnumerable<BusOnTrip> GetBusOnTrip()
        {
            return this.buses;
        }
   
        //internal static Line GetLine(int lineID)
        //{
        //    return lines.Find((line) => line.ID == lineID);
        //}

        //internal static void AddLine(int lineID)
        //{
        //    lines.Add(new Line(lineID));
        //}

        //internal static Line ChooseRandom()
        //{
        //    return lines.ElementAt(rnd.Next(0, lines.Count));
        //}
    }
}

