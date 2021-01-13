using System;

namespace BO
{
    public class LineTrip
    {
        
        #region properties
        private int Id { get; set; }
        private int LineId { get; set; }
        private TimeSpan StartAt { get; set; }
        private TimeSpan Frequency { get; set; }
        private TimeSpan FinishAt { get; set; }
        #endregion

    }
}
