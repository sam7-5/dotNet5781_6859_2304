using System;

namespace DO
{
    public class LineTrip
    {
        #region
        private int id;
        private int lineId;
        private TimeSpan startAt;
        private TimeSpan frequency;
        private TimeSpan finishAt;
        #endregion
        #region properties
        private int Id { get => id; set { id = value; } }
        private int LineId { get => lineId; set { lineId = value; } }
        private TimeSpan StartAt { get => startAt; set { startAt = value; } }
        private TimeSpan Frequency { get => frequency; set { frequency = value; } }
        private TimeSpan FinishAt { get => finishAt; set { finishAt = value; } }
        #endregion

    }
}
