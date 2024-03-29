﻿using System.Collections.Generic;

namespace DO
{
    /// <summary>
    /// base element for: Line, Line station, Trip ...
    /// </summary>
    public class Station
    {
        public Station() {}
        public Station(int code, string name, double longitude, double lattitude, string address) 
        {
            Code = code;
            Name = name;
            Longitude = longitude;
            Lattitude = lattitude;
            Address = address;
        }
        public Station(Station station)
        {
            Code = station.Code;
            Name = station.Name;
            Longitude = station.Longitude;
            Lattitude = station.Lattitude;
            Address = station.Address;
        }

        public int Code { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; } // Nort South
        public double Lattitude { get; set; } // Est West
        public string Address { get; set; }

    }
}
