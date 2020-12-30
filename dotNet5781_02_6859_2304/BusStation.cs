using System;

namespace dotNet5781_02_6859_2304
{
    class BusStation
    {
        static public Random r = new Random(DateTime.Now.Millisecond);
        private string BusStationKey;

        public string Key        //snippet prop
        {
            get { return BusStationKey; }

            set
            {
                if (value.Length <= 6 && value.Length > 0)
                    BusStationKey = value;
                else
                    Console.WriteLine("ERROR bus station key format invalid "); //peut etre mettre dans main  pour redemander valeur
            }
        }

        protected double Latitude;
        public double Lat            //snippet propfull
        {
            get { return Latitude; }

            set => Latitude = (r.NextDouble() * (33.3 - 31.0)) + 31.0;
        }

        protected double Longitude;
        public double Longi
        {
            get { return Longitude; }
            set => Longitude = (r.NextDouble() * (35.5 - 34.3)) + 34.3;
        }

        protected readonly string adresse;

        public string adress
        {
            get { return adresse; }
        }

        //----------- ctor ------------//
        public BusStation(string key)
        {
            Key = key;
            Lat = (r.NextDouble() * (33.3 - 31.0)) + 31.0;
            Longi = (r.NextDouble() * (35.5 - 34.3)) + 34.3;
        }

        // ctor overloading
        public BusStation(string key, string adresse1)
        {
            Key = key;
            Lat = (r.NextDouble() * (33.3 - 31.0)) + 31.0;
            Longi = (r.NextDouble() * (35.5 - 34.3)) + 34.3;
            adresse = adresse1;
        }

        public override string ToString()
        {
            return "Bus Station Code: " + BusStationKey + ",  " +
            Latitude + "°N  " + Longitude + "°E     ";
        }

        public BusStation()
        {
            // random fields to implemente
            BusStationKey = r.Next(100000, 999999).ToString();
            Latitude = (r.NextDouble() * (33.3 - 31.0)) + 31.0;
            Longitude = (r.NextDouble() * (35.5 - 34.3)) + 34.3;
        }
    }
}