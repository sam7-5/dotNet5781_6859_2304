namespace DO
{
    public class LineStation
    {
        public LineStation(int lineId, int station, int lineStationIndex, int prevStation, int nextStation)
        {
            LineId = lineId;
            Station = station;
            LineStationIndex = lineStationIndex;
            PrevStation = prevStation;
            NextStation = nextStation;
        }
        public LineStation() { }

        public int LineId { get; set; }
        public int Station { get; set; }
        public int LineStationIndex { get; set; }
        public int PrevStation { get; set; }
        public int NextStation { get; set; }
    }
}
