using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class BadStationCodeException : Exception
    {
        public int StationCode;

        public BadStationCodeException(int code) : base() => StationCode = code;
        public BadStationCodeException(int code, string message) : base(message) => StationCode = code;
        public BadStationCodeException(int code, string message, Exception innerException) :
            base(message, innerException) => StationCode = code;

        public override string ToString() => base.ToString() + $", bad station code: {StationCode}";
    }

    public class BadLineIDException : Exception
    {
        public int ID;

        public BadLineIDException(int id) : base() => ID = id;
        public BadLineIDException(int id, string message) : base(message) => ID = id;
        public BadLineIDException(int id, string message, Exception innerException) : base(message, innerException) => ID = id;

        public override string ToString() => base.ToString() + $", bad line ID: {ID}";
    }

    public class BadAdjStationCodeException : Exception
    {
        public int StationCode1, StationCode2;

        public BadAdjStationCodeException(int code1, int code2) : base() { StationCode1 = code1; StationCode2 = code2; }

        public BadAdjStationCodeException(int code1, int code2, string message) : base(message) { StationCode1 = code1; StationCode2 = code2; }
        public BadAdjStationCodeException(int code1, int code2, string message, Exception innerException) :
            base(message, innerException)
        { StationCode1 = code1; StationCode2 = code2; }

        public override string ToString() => base.ToString() + $", bad stations codes: {StationCode1}, {StationCode2}";
    }

    public class XMLFileLoadCreateExceptions : Exception {}
}
