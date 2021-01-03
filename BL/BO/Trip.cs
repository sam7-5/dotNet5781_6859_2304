using System;

namespace BO
{
    public class Trip
    {
        #region
        private int id;
        private string userName;
        private int lineId;
        private int idStation;
        private TimeSpan inAt;
        private int outStation;
        private TimeSpan outAt;
        #endregion

        #region properties
        public int Id { get => id; set { id = value; } }
        public string UserName { get => userName; set { userName = value; } }
        public int LineId { get => lineId; set { lineId = value; } }
        public int IdStation { get => idStation; set { idStation = value; } }
        public TimeSpan InAt { get => inAt; set { inAt = value; } }
        public int OutStation { get => outStation; set { outStation = value; } }
        public TimeSpan OutAt { get => outAt; set { outAt = value; } }
        #endregion
    }
}
