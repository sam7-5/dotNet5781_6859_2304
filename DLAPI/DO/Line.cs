namespace DO
{
    public class Line
    {
        #region
        private int id;
        private int code;
        private Enums.Area area;
        private int firstStation;
        private int lastStation;
        #endregion

        #region properties
        public int Id { get => id; set { id = value; } }
        public int Code { get => code; set { code = value; } }
        public Enums.Area Area { get => area; set { area = value; } }
        public int FirstStation { get => firstStation; set { firstStation = value; } }
        public int LastStation { get => lastStation; set { lastStation = value; } }
        #endregion
    }
}
