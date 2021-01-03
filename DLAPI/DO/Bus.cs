using System;
using System.Collections.Generic;

namespace DO
{
    public class Bus
    {
        private List<BusOnTrip> busOnTrips;
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

        #region fields

        private double m_kilometrage;
        private double fuelRemain;
        private Enums.BusStatus status;
        #endregion

        #region properties
        public int License
        { get; set;
            /*
            get
            {
                string first, middle, last;

                first = m_license.Substring(0, 3);
                middle = m_license.Substring(3, 2);
                last = m_license.Substring(5, 3);
                return string.Format("{0}-{1}-{2}", first, middle, last);
            }

            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] < '0' || value[i] > '9')
                    {
                        throw new Exception("invalide license format !"); // to implemente a derived exeption class
                    }
                }
                m_license = value;
            }
            */
        }
        public DateTime FromDate { get; set; }
        public double Kilometrage { get => m_kilometrage; set { m_kilometrage = value; } }
        public double FuelRemain { get => fuelRemain; set { fuelRemain = value; } }
        public Enums.BusStatus Status { get => status; set { status = value; } }
        #endregion

        public override string ToString()
        {
            return String.Format("license: {0,-10}, km: {1}", License, Kilometrage);
        }
    }
}
