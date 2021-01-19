﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DO
{
    public class Line
    {      
        
        #region properties
        public int ID{ get; set; }
        public int Code { get; set; }
        public Enums.Area Area { get; set; }
        public int FirstStation { get; set; }
        public int LastStation { get; set; }
        #endregion
        /*
        public Line() 
        {
            linesOnTrip = new List<LineTrip>();
            buses = new List<BusOnTrip>();
        }
        */

        public Line(int iD, int code, Enums.Area area, int firstStation, int lastStation)
        {
            ID = iD;
            Code = code;
            Area = area;
            FirstStation = firstStation;
            LastStation = lastStation;
            
        }
        public Line() { }

       
   
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

