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

        public int Id { get; set; }
        public int LineId { get; set; }
        public TimeSpan StartAt { get; set; }
        public TimeSpan Frequency { get; set; }
        public TimeSpan FinishAt { get; set; }
    }
}
