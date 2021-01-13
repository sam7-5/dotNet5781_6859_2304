using System;

namespace BO
{
    public class Bus
    {
     

        #region properties
        public int LicenseNum { get; set; } 
        public DateTime FromDate { get; set; }
        public double TotalTrip { get; set; }
        public double FuelRemain { get; set; }
        public Enums.BusStatus Status { get; set; }
        #endregion
    }
}
