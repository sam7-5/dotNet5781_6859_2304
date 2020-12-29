using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public static class Enums
    {
        public enum Area
        {
            Center,
            Galil,
            Golan,
            South,
            Eilat
        }

        public enum BusStatus
        {
            InTrip, // = unAvailable            
            Available,
            UnAvailable // maintain, refuel, to old ...
        }
    }
}
