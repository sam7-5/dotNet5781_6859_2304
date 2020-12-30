using System;

namespace DAL.DO
{
    public class BusOnTrip
    {
        #region fields
        private int id;
        private int licenseNum;
        private int lineId;
        private TimeSpan plannedTakeOff;
        private TimeSpan actualTakeOff;
        private int prevStation;
        private TimeSpan prevStationAT;
        private TimeSpan nextStationAt;
        #endregion

        #region properties
        public int Id { get => id; set { id = value; } }
        public int LicenseNum { get => licenseNum; set { licenseNum = value; } }
        public int LineId { get => lineId; set { lineId = value; } }
        public TimeSpan PlannedTakeOff { get => plannedTakeOff; set { plannedTakeOff = value; } }
        public TimeSpan ActualTakeOff { get => actualTakeOff; set { actualTakeOff = value; } }
        public int PrevStation { get => prevStation; set { prevStation = value; } }
        public TimeSpan PrevStationAT { get => prevStationAT; set { prevStationAT = value; } }
        public TimeSpan NextStationAt { get => nextStationAt; set { nextStationAt = value; } }
        #endregion
    }
}
