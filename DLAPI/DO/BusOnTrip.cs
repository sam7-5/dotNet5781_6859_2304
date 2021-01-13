using System;

namespace DO
{
    public class BusOnTrip
    {
        public BusOnTrip(int id, int licenseNum, int lineId, TimeSpan plannedTakeOff, TimeSpan actualTakeOff, int prevStation, TimeSpan prevStationAT, TimeSpan nextStationAt)
        {
            Id = id;
            LicenseNum = licenseNum;
            LineId = lineId;
            PlannedTakeOff = plannedTakeOff;
            ActualTakeOff = actualTakeOff;
            PrevStation = prevStation;
            PrevStationAT = prevStationAT;
            NextStationAt = nextStationAt;
        }

        #region properties
        public int Id { get; set; }
        public int LicenseNum { get; set; }
        public int LineId { get; set; }
        public TimeSpan PlannedTakeOff { get; set; }
        public TimeSpan ActualTakeOff { get; set; }
        public int PrevStation { get; set; }
        public TimeSpan PrevStationAT { get; set; }
        public TimeSpan NextStationAt { get; set; }
        #endregion
    }
}
