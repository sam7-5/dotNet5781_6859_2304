﻿using System;

namespace DO
{
    public class LineTrip
    {
        #region attributes
        private int id;
        private int lineId;
        private TimeSpan startAt;
        private TimeSpan frequency;
        private TimeSpan finishAt;

        public LineTrip(int id, int lineId, TimeSpan startAt, TimeSpan frequency, TimeSpan finishAt)
        {
            Id = id;
            LineId = lineId;
            StartAt = startAt;
            Frequency = frequency;
            FinishAt = finishAt;
        }
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