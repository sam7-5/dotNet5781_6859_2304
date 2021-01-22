using System.Collections.Generic;

namespace BO
{
    public class Line
    {
        /// <summary>
        /// number of line like bus 6 to JCT, Line.Id = 6
        /// </summary>
        public int Id { get; set; }
        public int Code { get; set; }
        public Enums.Area Area { get; set; }
        public int FirstStation { get; set; }
        public int LastStation { get; set; }

        public override string ToString() { return $"{Id}"; }

        public List<int> stationOfThisLine = new List<int>();
    }
}
