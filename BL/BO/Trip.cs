using System;

namespace BO
{
    public class Trip
    { 
        #region properties
        public int Id { get; set; }
        public string UserName { get; set; }
        public int LineId { get; set; }
        public int IdStation { get; set; }
        public TimeSpan InAt { get; set; }
        public int OutStation { get; set; }
        public TimeSpan OutAt { get; set; }
        #endregion
    }
}
