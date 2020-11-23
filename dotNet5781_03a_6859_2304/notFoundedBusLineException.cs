using System;
using System.Runtime.Serialization;

namespace dotNet5781_02_6859_2304
{
    [Serializable]
    internal class notFoundedBusLineException : Exception
    {
        public notFoundedBusLineException()
        {
        }

        public notFoundedBusLineException(string message) : base(message)
        {
        }

        public notFoundedBusLineException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected notFoundedBusLineException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}