namespace DO
{
    public class LineStation
    {
        #region
        private int lineId;
        private int station;
        private int lineStationIndex;
        private int prevStation;
        private int nextStation;

        public LineStation(int lineId, int station, int lineStationIndex, int prevStation, int nextStation)
        {
            LineId = lineId;
            Station = station;
            LineStationIndex = lineStationIndex;
            PrevStation = prevStation;
            NextStation = nextStation;
        }
        #endregion

        #region properties
        public int LineId { get => lineId; set { lineId = value; } }
        public int Station { get => station; set { station = value; } }
        public int LineStationIndex { get => lineStationIndex; set { lineStationIndex = value; } }
        public int PrevStation { get => prevStation; set { prevStation = value; } }
        public int NextStation { get => nextStation; set { nextStation = value; } }
        #endregion
    }
}
