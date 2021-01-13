using System;

namespace DO
{
    public class Trip
    {
        public Trip(int id, string userName, int lineId, int idStation, TimeSpan inAt, int outStation, TimeSpan outAt)
        {
            Id = id;
            UserName = userName;
            LineId = lineId;
            IdStation = idStation;
            InAt = inAt;
            OutStation = outStation;
            OutAt = outAt;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public int LineId { get; set; }
        public int IdStation { get; set; } 
        public TimeSpan InAt { get; set; } 
        public int OutStation { get; set; } 
        public TimeSpan OutAt { get; set; } 

    }
}
