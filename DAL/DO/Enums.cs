namespace DAL.DO
{
    public static class Enums
    {
        public enum Area
        {
            Center,
            Galil,
            Golan,
            South,
            Eilat
        }

        public enum BusStatus
        {
            InTrip, // = unAvailable            
            Available,
            UnAvailable // maintain, refuel, to old ...
        }
    }
}
