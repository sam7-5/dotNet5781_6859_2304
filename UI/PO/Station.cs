using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.PO
{
    /// <summary>
    /// base element for: Line, Line station, Trip ...
    /// </summary>
    public class Station
    {
        #region properties
        public int Code { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; } // Nort South
        public double Lattitude { get; set; } // Est West
        #endregion
    }
}
