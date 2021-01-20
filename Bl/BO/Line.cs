using System.Collections.Generic;

namespace BO
{
    public class Line
    {
        public int Id { get; set; } // number of line like bus 6 to JCT, Line.Id = 6
        public int Code { get; set; }
        public Enums.Area Area { get; set; }
        public int FirstStation { get; set; }
        public int LastStation { get; set; }

        public override string ToString() { return $"{Id}"; }

        public List<int> stationOfThisLine = null;
    }
}
