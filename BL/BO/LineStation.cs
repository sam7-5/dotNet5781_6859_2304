namespace BO
{
    public class LineStation
    {
        /*
        public string name; -> station
        latitude -> station
        longitude -> station
        public int station; -> list of int's
        public int LineStationIndex; -> this
        public int distance; -> adjacent station
        public  TimeSpan timeWithPrevious; -> adjacent station
        */

        public int LineId { get; set; }
        public int Station { get; set; }
        public int LineStationIndex { get; set; }
        public int PrevStation { get; set; }
        public int NextStation { get; set; }
    }
}
