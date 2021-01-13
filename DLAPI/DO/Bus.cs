using System;
using System.Collections.Generic;

namespace DO
{
    public class Bus
    {
        public List<BusOnTrip> busOnTrips;
        public Bus()
        {
            busOnTrips = new List<BusOnTrip>();
        }

        public Bus(int license, DateTime fromDate, double kilometrage, double fuelRemain, Enums.BusStatus status)
        {
            License = license;
            FromDate = fromDate;
            Kilometrage = kilometrage;
            FuelRemain = fuelRemain;
            Status = status;
        }

        #region properties
        public int License { get; set;}
        public DateTime FromDate { get; set; }
        public double Kilometrage { get; set; }
        public double FuelRemain { get; set; }
        public Enums.BusStatus Status { get ; set; }
        #endregion

        public override string ToString()
        {
            return String.Format("license: {0,-10}, km: {1}", License, Kilometrage);
        }
    }
}
