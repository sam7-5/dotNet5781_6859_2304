using System;

namespace BO
{
    public class BusOnTrip
    {
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
