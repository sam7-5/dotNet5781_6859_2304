using System;

namespace BO
{
    public class BadStationCodeException : Exception
    {
        public int StationCode;

        public BadStationCodeException(string message, Exception innerException) : base(message, innerException)
            => StationCode = ((DO.BadStationCodeException)innerException).StationCode;

        public override string ToString() => base.ToString() + $", bad station code {StationCode}";
    }

    public class BadLineIDException : Exception
    {
        public int lineID;

        public BadLineIDException(string message, Exception innerException) : base(message, innerException)
            => lineID = ((DO.BadLineIDException)innerException).ID;

        public override string ToString() => base.ToString() + $", bad line ID: {lineID}";
    }

    public class BadAdjStationCodeException : Exception
    {
        public int StationCode1, StationCode2;

        public BadAdjStationCodeException(string message, Exception innerException) :
            base(message, innerException)
        {
            StationCode1 = ((DO.BadAdjStationCodeException)innerException).StationCode1;
            StationCode2 = ((DO.BadAdjStationCodeException)innerException).StationCode2;
        }
    }

    public class BadStationCustomException : Exception
    {

    }

}
