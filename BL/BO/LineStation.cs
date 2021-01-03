namespace BO
{
    public class LineStation
    {
        #region fields
        private int lineId;
        private int station;
        private int lineStationIndex;
        private int prevStation;
        private int nextStation;
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
