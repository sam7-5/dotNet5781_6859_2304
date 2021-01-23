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
        public LineStation(LineStation lineStation)
        {
            LineId = lineStation.LineId;
            Station = lineStation.Station;
            LineStationIndex = lineStation.LineStationIndex;
            PrevStation = lineStation.PrevStation;
            NextStation = lineStation.NextStation;
        }

        public int LineId { get; set; }
        public int Station { get; set; }
        public int LineStationIndex { get; set; }
        public int PrevStation { get; set; }
        public int NextStation { get; set; }
    }
}
