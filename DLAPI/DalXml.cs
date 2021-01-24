using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DLAPI;
using DO;

namespace DLAPI
{
    sealed class DalXml //:idl
    {
        #region singelton
        static readonly DalXml instance = new DalXml();
        static DalXml() { }// static ctor to ensure instance init is done just before first usage
        DalXml() { } // default => private
        public static DalXml Instance { get => instance; }// The public Instance property to use
        #endregion

        #region DS XML Files

        string stations = @"StopsXml.xml"; //XElement
        string lines = @"linesXml.xml"; //XMLSerializer
        string adjacentStations = @"AdjacentStationsXml.xml"; //XMLSerializer
        string lineStations = @"LineStationssXml.xml"; //XMLSerializer
        string lineTrip = @"LineTripXml.xml";//XMLSerializer
        #endregion

        #region DS XML Files

        string stationsPath = @"Stations.xml"; //XElement
        string linesPath = @"lines.xml"; //XMLSerializer
        string adjacentStationsPath = @"AdjacentStations.xml"; //XMLSerializer
        string lineStationsPath = @"LineStations.xml"; //XMLSerializer
        string lineTripPath = @"LineTripXml.xml";//XMLSerializer


        #endregion

        #region Station 
        //still  error throw and hebrew problem
        public IEnumerable<DO.Station> GetAllStations()
        {
            XElement stationRootElem = XmlTools.LoadListFromXMLElement(stationsPath);
            return (from p in stationRootElem.Elements()
                    select new Station()
                    {
                        Code = Int32.Parse(p.Element("Code").Value),
                        Name = p.Element("Name").Value,
                        Longitude = double.Parse(p.Element("Longitude").Value, System.Globalization.CultureInfo.InvariantCulture),
                        Lattitude = double.Parse(p.Element("Lattitude").Value, System.Globalization.CultureInfo.InvariantCulture),
                        Address = p.Element("Address").Value,
                    }
                   );
        }
        public DO.Station GetStation(int stationCode)
        {
            XElement stationRootElem = XmlTools.LoadListFromXMLElement(stationsPath);

            Station p = (from per in stationRootElem.Elements()
                         where int.Parse(per.Element("Code").Value) == stationCode
                         select new Station()
                         {
                             Code = Int32.Parse(per.Element("Code").Value),
                             Name = per.Element("Name").Value,
                             Longitude = double.Parse(per.Element("Longitude").Value, System.Globalization.CultureInfo.InvariantCulture),
                             Lattitude = double.Parse(per.Element("Lattitude").Value, System.Globalization.CultureInfo.InvariantCulture),
                             Address = per.Element("Address").Value,
                         }
                        ).FirstOrDefault();

            // if (p == null)
            //     throw new DO.BadStationCodeException(stationCode, $"bad station code: {stationCode}");

            return p;

        }
        public void AddStation(DO.Station station)
        {
            XElement stationRootElem = XmlTools.LoadListFromXMLElement(stationsPath);

            XElement per1 = (from p in stationRootElem.Elements()
                             where int.Parse(p.Element("Code").Value) == station.Code
                             select p).FirstOrDefault();

            //if (per1 != null)
            //   throw new DO.BadstationCodeException(station.Code, "Duplicate station code");

            XElement stationElem = new XElement("Station",
                                   new XElement("Code", station.Code),
                                   new XElement("Name", station.Name),
                                   new XElement("Longitude", station.Longitude),
                                   new XElement("Lattitude", station.Lattitude),
                                   new XElement("Address", station.Address));


            stationRootElem.Add(stationElem);

            XmlTools.SaveListToXMLElement(stationRootElem, stationsPath);
        }
        public void UpdateStation(DO.Station station)
        {
            XElement personsRootElem = XmlTools.LoadListFromXMLElement(stationsPath);

            XElement per = (from p in personsRootElem.Elements()
                            where int.Parse(p.Element("Code").Value) == station.Code
                            select p).FirstOrDefault();

            if (per != null)
            {
                per.Element("Code").Value = station.Code.ToString();
                per.Element("Name").Value = station.Name;
                per.Element("Longitude").Value = station.Longitude.ToString();
                per.Element("Lattitude").Value = station.Lattitude.ToString();
                per.Element("Address").Value = station.Address;


                XmlTools.SaveListToXMLElement(personsRootElem, stationsPath);
            }
            // else
            //    throw new DO.BadstationCodeException(station.Code, $"bad station code: {station.Code}");
        }
        public void UpdateStation(int stationCode, Action<DO.Station> update) { }
        public void DeleteStation(int stationCode)
        {
            XElement personsRootElem = XmlTools.LoadListFromXMLElement(stationsPath);

            XElement per = (from p in personsRootElem.Elements()
                            where int.Parse(p.Element("Code").Value) == stationCode
                            select p).FirstOrDefault();

            if (per != null)
            {
                per.Remove();
                XmlTools.SaveListToXMLElement(personsRootElem, stationsPath);
            }
            // else
            //    throw new DO.BadstationCodeException(stationCode, $"bad station code: {stationCode}");
        }
        #endregion

        #region Line
        public IEnumerable<DO.Line> GetAllLines()
        {

            XElement lineRootElem = XmlTools.LoadListFromXMLElement(linesPath);
            return (from p in lineRootElem.Elements()
                    select new Line()
                    {
                        ID = Int32.Parse(p.Element("ID").Value),
                        Code = Int32.Parse(p.Element("Code").Value),
                        Area = (Enums.Area)Enum.Parse(typeof(Enums.Area), (p.Element("Area").Value)),
                        FirstStation = Int32.Parse(p.Element("FirstStation").Value),
                        LastStation = Int32.Parse(p.Element("LastStation").Value)
                    }
                   );
        }
        public DO.Line GetLine(int lineId)
        {
            XElement lineRootElem = XmlTools.LoadListFromXMLElement(linesPath);

            Line sta = (from p in lineRootElem.Elements()
                        where int.Parse(p.Element("Code").Value) == lineId
                        select new Line()
                        {
                            ID = Int32.Parse(p.Element("ID").Value),
                            Code = Int32.Parse(p.Element("Code").Value),
                            Area = (Enums.Area)Enum.Parse(typeof(Enums.Area), (p.Element("Area").Value)),
                            FirstStation = Int32.Parse(p.Element("FirstStation").Value),
                            LastStation = Int32.Parse(p.Element("LastStation").Value)
                        }
                        ).FirstOrDefault();

            // if (p == null)
            //     throw new DO.BadStationCodeException(stationCode, $"bad station code: {stationCode}");

            return sta;
        }
        public void AddLine(DO.Line line)
        {

            XElement lineRootElem = XmlTools.LoadListFromXMLElement(linesPath);

            XElement per1 = (from p in lineRootElem.Elements()
                             where int.Parse(p.Element("Code").Value) == line.Code
                             select p).FirstOrDefault();

            //if (per1 != null)
            //   throw new DO.BadstationCodeException(station.Code, "Duplicate station code");

            XElement lineElem = new XElement("Station",
                                   new XElement("ID", line.ID),
                                   new XElement("Code", line.Code),
                                   new XElement("Area", line.Area),
                                   new XElement("FirstStation", line.FirstStation),
                                   new XElement("LastStation", line.LastStation));


            lineRootElem.Add(lineElem);

            XmlTools.SaveListToXMLElement(lineRootElem, linesPath);
        }
        public void UpdateLine(DO.Line line)
        {
            XElement lineRootElem = XmlTools.LoadListFromXMLElement(linesPath);

            XElement per = (from p in lineRootElem.Elements()
                            where int.Parse(p.Element("Code").Value) == line.Code
                            select p).FirstOrDefault();

            if (per != null)
            {
                per.Element("ID").Value = line.ID.ToString();
                per.Element("Code").Value = line.Code.ToString();
                per.Element("Area").Value = line.Area.ToString();
                per.Element("FirstStation").Value = line.FirstStation.ToString();
                per.Element("LastStation").Value = line.LastStation.ToString();


                XmlTools.SaveListToXMLElement(lineRootElem, linesPath);
            }
            // else
            //    throw new DO.BadstationCodeException(station.Code, $"bad station code: {station.Code}");

        }
        public void UpdateLine(DO.Line line, Action<DO.Line> update) { }
        public void DeleteLine(int lineId) //id ou code?
        {
            XElement lineRootElem = XmlTools.LoadListFromXMLElement(linesPath);

            XElement per = (from p in lineRootElem.Elements()
                            where int.Parse(p.Element("ID").Value) == lineId
                            select p).FirstOrDefault();

            if (per != null)
            {
                per.Remove();
                XmlTools.SaveListToXMLElement(lineRootElem, stationsPath);
            }
            // else
            //    throw new DO.BadstationCodeException(stationCode, $"bad station code: {stationCode}");
        }
        #endregion


        #region LineStation 
        public IEnumerable<DO.LineStation> GetAllLineStation()
        {

            XElement lineStationRootElem = XmlTools.LoadListFromXMLElement(lineStationsPath);
            return (from p in lineStationRootElem.Elements()
                    select new LineStation()
                    {
                        LineId = Int32.Parse(p.Element("LineId").Value),
                        Station = Int32.Parse(p.Element("Station").Value),
                        LineStationIndex = Int32.Parse(p.Element("LineStationIndex").Value),
                        PrevStation = Int32.Parse(p.Element("PrevStation").Value),
                        NextStation = Int32.Parse(p.Element("NextStation").Value)
                    }
                   );
        }
        public DO.LineStation GetLineStation(int lineId)
        {
            XElement lineStationRootElem = XmlTools.LoadListFromXMLElement(lineStationsPath);

            LineStation per = (from p in lineStationRootElem.Elements()
                               where int.Parse(p.Element("LineId").Value) == lineId
                               select new LineStation()
                               {
                                   LineId = Int32.Parse(p.Element("LineId").Value),
                                   Station = Int32.Parse(p.Element("Station").Value),
                                   LineStationIndex = Int32.Parse(p.Element("LineStationIndex").Value),
                                   PrevStation = Int32.Parse(p.Element("PrevStation").Value),
                                   NextStation = Int32.Parse(p.Element("NextStation").Value)
                               }
                        ).FirstOrDefault();

            // if (p == null)
            //     throw new DO.BadStationCodeException(stationCode, $"bad station code: {stationCode}");

            return per;
        }
        public void AddLineStation(DO.LineStation lineStation)
        {
            XElement lineStationRootElem = XmlTools.LoadListFromXMLElement(lineStationsPath);

            XElement per1 = (from p in lineStationRootElem.Elements()
                             where int.Parse(p.Element("LineId").Value) == lineStation.LineId
                             select p).FirstOrDefault();


            XElement lineStationElem = new XElement("LineStation",
                                   new XElement("LineId", lineStation.LineId),
                                   new XElement("Station", lineStation.Station),
                                   new XElement("LineStationIndex", lineStation.LineStationIndex),
                                   new XElement("PrevStation", lineStation.PrevStation),
                                   new XElement("NextStation", lineStation.NextStation));


            lineStationRootElem.Add(lineStationElem);

            XmlTools.SaveListToXMLElement(lineStationRootElem, lineStationsPath);
        }
        public void UpdateLineStation(DO.LineStation lineStation)
        {
            XElement lineStationRootElem = XmlTools.LoadListFromXMLElement(lineStationsPath);

            XElement per = (from p in lineStationRootElem.Elements()
                            where int.Parse(p.Element("LineId").Value) == lineStation.LineId
                            select p).FirstOrDefault();

            if (per != null)
            {
                per.Element("LineId").Value = lineStation.LineId.ToString();
                per.Element("Station").Value = lineStation.Station.ToString();
                per.Element("LineStationIndex").Value = lineStation.LineStationIndex.ToString();
                per.Element("PrevStation").Value = lineStation.PrevStation.ToString();
                per.Element("NextStation").Value = lineStation.NextStation.ToString();


                XmlTools.SaveListToXMLElement(lineStationRootElem, lineStationsPath);
            }
            // else
            //    throw new DO.BadstationCodeException(station.Code, $"bad station code: {station.Code}");

        }
        public void UpdateLineStation(DO.LineStation line, Action<DO.LineStation> update) { }
        public void DeleteLineStation(int lineId)
        {
            XElement lineStationRootElem = XmlTools.LoadListFromXMLElement(lineStationsPath);

            XElement per = (from p in lineStationRootElem.Elements()
                            where int.Parse(p.Element("LineId").Value) == lineId
                            select p).FirstOrDefault();

            if (per != null)
            {
                per.Remove();
                XmlTools.SaveListToXMLElement(lineStationRootElem, lineStationsPath);
            }
            // else
            //    throw new DO.BadstationCodeException(stationCode, $"bad station code: {stationCode}");
        }
        #endregion


        #region AdjacentStations
        public IEnumerable<DO.AdjacentStations> GetAllAdjStation()
        {

            XElement adjacentStationsRootElem = XmlTools.LoadListFromXMLElement(adjacentStationsPath);
            return (from p in adjacentStationsRootElem.Elements()
                    select new AdjacentStations()
                    {
                        Station1 = Int32.Parse(p.Element("Station1").Value),
                        Station2 = Int32.Parse(p.Element("Station2").Value),
                        Distance = double.Parse(p.Element("Distance").Value, System.Globalization.CultureInfo.InvariantCulture),
                        Time = TimeSpan.Parse(p.Element("Time").Value),
                    }
                   );
        }
        public DO.AdjacentStations GetAdjtStation(int station1, int station2)
        {
            XElement adjacentStationsRootElem = XmlTools.LoadListFromXMLElement(adjacentStationsPath);

            AdjacentStations p = (from per in adjacentStationsRootElem.Elements()
                                  where (int.Parse(per.Element("Station1").Value) == station1 && int.Parse(per.Element("Station2").Value) == station2)
                                  select new AdjacentStations()
                                  {
                                      Station1 = Int32.Parse(per.Element("Station1").Value),
                                      Station2 = Int32.Parse(per.Element("Station2").Value),
                                      Distance = double.Parse(per.Element("Distance").Value, System.Globalization.CultureInfo.InvariantCulture),
                                      Time = TimeSpan.Parse(per.Element("Time").Value),
                                  }
                        ).FirstOrDefault();

            // if (p == null)
            //     throw new DO.BadStationCodeException(stationCode, $"bad station code: {stationCode}");

            return p;
        }
        public void AddAdjacentStation(DO.AdjacentStations AdjStation)
        {
            XElement adjacentStationsRootElem = XmlTools.LoadListFromXMLElement(adjacentStationsPath);

            XElement per1 = (from p in adjacentStationsRootElem.Elements()
                             where (int.Parse(p.Element("Station1").Value) == AdjStation.Station1 && int.Parse(p.Element("Station").Value) == AdjStation.Station2)
                             select p).FirstOrDefault();

            //if (per1 != null)
            //   throw new DO.BadstationCodeException(station.Code, "Duplicate station code");

            XElement adjStationElem = new XElement("AdjacentStations",
                                   new XElement("Station1", AdjStation.Station1),
                                   new XElement("Station2", AdjStation.Station2),
                                   new XElement("Distance", AdjStation.Distance),
                                   new XElement("Time", AdjStation.Time));



            adjacentStationsRootElem.Add(adjStationElem);

            XmlTools.SaveListToXMLElement(adjacentStationsRootElem, adjacentStationsPath);
        }
        public void UpdateAdjStation(DO.AdjacentStations AdjStation)
        {
            /* Station1 
            Station2 
            Distance
            Time */
            XElement adjacentStationsRootElem = XmlTools.LoadListFromXMLElement(adjacentStationsPath);


            XElement per = (from p in adjacentStationsRootElem.Elements()
                            where (int.Parse(p.Element("Station1").Value) == AdjStation.Station1 && int.Parse(p.Element("Station").Value) == AdjStation.Station2)
                            select p).FirstOrDefault();

            if (per != null)
            {
                per.Element("Station1").Value = AdjStation.Station1.ToString();
                per.Element("Station2").Value = AdjStation.Station2.ToString();
                per.Element("Distance").Value = AdjStation.Distance.ToString();
                per.Element("Time").Value = AdjStation.Distance.ToString();


                XmlTools.SaveListToXMLElement(adjacentStationsRootElem, adjacentStationsPath);
            }
            // else
            //    throw new DO.BadstationCodeException(station.Code, $"bad station code: {station.Code}");

        }
        public void UpdateAdjStation(DO.AdjacentStations AdjStation, Action<DO.LineStation> update) { }
        public void DeleteAdjStation(int station1, int station2)
        {
            XElement adjacentStationsRootElem = XmlTools.LoadListFromXMLElement(adjacentStationsPath);

        }
        #endregion

        //#region LineTrip
        //public IEnumerable<DO.LineTrip> GetAllLineTrip()
        //{
        //    XElement stationRootElem = XmlTools.LoadListFromXMLElement(stationsPath);
        //    return (from p in stationRootElem.Elements()
        //            select new Station()
        //            {
        //                Code = Int32.Parse(p.Element("Code").Value),
        //                Name = p.Element("Name").Value,
        //                Longitude = Int32.Parse(p.Element("Longitude").Value),
        //                Lattitude = Int32.Parse(p.Element("Lattitude").Value),
        //                Address = p.Element("Address").Value,
        //            }
        //           );
        //}
        //public DO.LineTrip GetLineTrip(int lineId)
        //{
        //    XElement stationRootElem = XmlTools.LoadListFromXMLElement(stationsPath);

        //    Station p = (from per in stationRootElem.Elements()
        //                 where int.Parse(per.Element("Code").Value) == stationCode
        //                 select new Station()
        //                 {
        //                     Code = Int32.Parse(per.Element("Code").Value),
        //                     Name = per.Element("Name").Value,
        //                     Longitude = Int32.Parse(per.Element("Longitude").Value),
        //                     Lattitude = Int32.Parse(per.Element("Lattitude").Value),
        //                     Address = per.Element("Address").Value,
        //                 }
        //                ).FirstOrDefault();

        //    // if (p == null)
        //    //     throw new DO.BadStationCodeException(stationCode, $"bad station code: {stationCode}");

        //    return p;
        //}
        //public void AddLineTrip(DO.LineTrip line)
        //{
        //    XElement stationRootElem = XmlTools.LoadListFromXMLElement(stationsPath);

        //    XElement per1 = (from p in stationRootElem.Elements()
        //                     where int.Parse(p.Element("Code").Value) == station.Code
        //                     select p).FirstOrDefault();

        //    //if (per1 != null)
        //    //   throw new DO.BadstationCodeException(station.Code, "Duplicate station code");

        //    XElement stationElem = new XElement("Station",
        //                           new XElement("Code", station.Code),
        //                           new XElement("Name", station.Name),
        //                           new XElement("Longitude", station.Longitude),
        //                           new XElement("Lattitude", station.Lattitude),
        //                           new XElement("Address", station.Address));


        //    stationRootElem.Add(stationElem);

        //    XmlTools.SaveListToXMLElement(stationRootElem, stationsPath);
        //}
        //public void UpdateLineTrip(DO.LineTrip line)
        //{
        //    XElement personsRootElem = XmlTools.LoadListFromXMLElement(stationsPath);

        //    XElement per = (from p in personsRootElem.Elements()
        //                    where int.Parse(p.Element("Code").Value) == station.Code
        //                    select p).FirstOrDefault();

        //    if (per != null)
        //    {
        //        per.Element("Code").Value = station.Code.ToString();
        //        per.Element("Name").Value = station.Name;
        //        per.Element("Longitude").Value = station.Longitude.ToString();
        //        per.Element("Lattitude").Value = station.Lattitude.ToString();
        //        per.Element("Address").Value = station.Address;


        //        XmlTools.SaveListToXMLElement(personsRootElem, stationsPath);
        //    }
        //    // else
        //    //    throw new DO.BadstationCodeException(station.Code, $"bad station code: {station.Code}");
        //}
        //public void UpdateLineTrip(DO.LineTrip line, Action<DO.LineTrip> update) { }
        //public void DeleteLineTrip(int lineId)
        //{
        //    XElement personsRootElem = XmlTools.LoadListFromXMLElement(stationsPath);

        //    XElement per = (from p in personsRootElem.Elements()
        //                    where int.Parse(p.Element("Code").Value) == stationCode
        //                    select p).FirstOrDefault();

        //    if (per != null)
        //    {
        //        per.Remove();
        //        XmlTools.SaveListToXMLElement(personsRootElem, stationsPath);
        //    }
        //    // else
        //    //    throw new DO.BadstationCodeException(stationCode, $"bad station code: {stationCode}");
        //}
        //#endregion
    }
}
