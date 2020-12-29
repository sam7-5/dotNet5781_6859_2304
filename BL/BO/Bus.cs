﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class Bus
    {
        #region fields
        private int licenseNum;
        private DateTime fromDate;
        private double totalTrip;
        private double fuelRemain;
        private Enums.BusStatus status;
        #endregion

        #region properties
        public int LicenseNum { get => licenseNum; set { licenseNum = value; } }
        public DateTime FromDate { get => fromDate; set { fromDate = value; } }
        public double TotalTrip { get => totalTrip; set { totalTrip = value; } }
        public double FuelRemain { get => fuelRemain; set { fuelRemain = value; } }
        public Enums.BusStatus Status { get => status; set { status = value; } }
        #endregion
    }
}
