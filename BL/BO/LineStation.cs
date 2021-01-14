namespace BO
{
    public class LineStation
    {
        /*
        public string name;
        public int station;
        public int LineStationIndex;
        public int distance;
        public  TimeSpan timeWithPrevious;
        latitude
        longitude
        */
        #region properties
        public int LineId { get; set; }
        public int Station { get; set; }
        public int LineStationIndex { get; set; }
        public int PrevStation { get; set; }
        public int NextStation { get; set; }
        #endregion
    }
}
