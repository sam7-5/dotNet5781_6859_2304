using System;

namespace DO
{
    public class LineTrip
    {
        public LineTrip(int id, int lineId, TimeSpan startAt, TimeSpan frequency, TimeSpan finishAt)
        {
            Id = id;
            LineId = lineId;
            StartAt = startAt;
            Frequency = frequency;
            FinishAt = finishAt;
        }

        #region properties
        private int Id { get; set; }
        private int LineId { get; set; }
        private TimeSpan StartAt { get; set; }
        private TimeSpan Frequency { get; set; }
        private TimeSpan FinishAt { get; set; }
        #endregion

    }
}
