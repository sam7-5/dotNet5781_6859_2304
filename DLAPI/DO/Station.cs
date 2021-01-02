using System.Collections.Generic;

namespace DO
{
    /// <summary>
    /// base element for: Line, Line station, Trip ...
    /// </summary>
    public class Station
    {

        private List<BusOnTrip> OnTripBuses;
        private List<Line> lines;
        private List<LineStation> lineStations;
        private List<Trip> trips;
        private List<AdjacentStations> adjacentStations;

        public Station()
        {
            OnTripBuses = new List<BusOnTrip>();
            lines = new List<Line>();
            lineStations = new List<LineStation>();
            trips = new List<Trip>();
            adjacentStations = new List<AdjacentStations>();
        }

        public Station(int code, string name, double longitude, double lattitude, string address) : this()
        {
            Code = code;
            Name = name;
            Longitude = longitude;
            Lattitude = lattitude;
            Address = address;
        }

        internal IEnumerable<BusOnTrip> GetTrips()
        {
            return this.OnTripBuses;
        }
        internal IEnumerable<Line> GetLines()
        {
            return this.lines;
        }
        internal IEnumerable<LineStation> GetLineStation()
        {
            return this.lineStations;
        }
        internal IEnumerable<Trip> GetTrip()
        {
            return this.trips;
        }
        internal IEnumerable<AdjacentStations> GetAdjacentStations()
        {
            return this.adjacentStations;
        }

        #region properties
        public int Code { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; } // Nort South
        public double Lattitude { get; set; } // Est West
        public string Address { get; set; }
        #endregion

    }
}
