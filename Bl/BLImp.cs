using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DLAPI;
using System.Collections.Generic;
using BO;

namespace BL
{
    internal class BLImp : IBL
    {
        IDL dl = DLFactory.GetDL();

        #region station

        // tool for adapting DO.Station to BO.Station
        private BO.Station stationDoBoAdapter(DO.Station stationDO)
        {
            BO.Station stationBO = new BO.Station();
            DO.Station stationToTest;

            if (stationDO == null)
                return stationBO;

            int stationCode = stationDO.Code;
            try
            {
                stationToTest = dl.GetStation(stationCode);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("station code is illegal", ex);
            }

            stationDO.CopyPropertiesTo(stationBO);

            return stationBO;
        }

        // Add a station to DataSource through DAL layer
        public void AddStation(BO.Station station)
        {
            DO.Station stationDO = new DO.Station();

            stationDO.Code = station.Code;
            stationDO.Address = station.Address;
            stationDO.Lattitude = station.Lattitude;
            stationDO.Longitude = station.Longitude;
            stationDO.Name = station.Name;

            try
            {
                dl.AddStation(stationDO);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("problem with adding this station", ex);
            }
        }

        public IEnumerable<BO.Station> GetAllStations()
        {
            return from stationDO in dl.GetAllStations()
                   orderby stationDO.Code
                   select stationDoBoAdapter(stationDO);
        }

        // try to get a station form DataSource by his code through DAL layer
        public Station GetStation(int stationCode)
        {
            DO.Station stationDO;
            try
            {
                stationDO = dl.GetStation(stationCode);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Station code does not exist", ex);
            }
            return stationDoBoAdapter(stationDO);
        }

        public void UpdateStation(BO.Station stationBO)
        {
            DO.Station stationDO = new DO.Station();
            stationBO.CopyPropertiesTo(stationDO);

            try
            {
                dl.UpdateStation(stationDO);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("station code is illegal", ex);
            }
        }

        public IEnumerable<BO.Station> GetAllStationsOfArea(Enums.Area area)
        {
            foreach (var LineDO in dl.GetAllLines())
            {
                // if it's the same area so get all the station from the are
                if (LineDO.Area.CompareTo((DO.Enums.Area)area) == 0)
                {
                    int from, to = 0;
                    from = LineDO.FirstStation;
                    to = LineDO.LastStation;

                    for (int i = from; i < to; i++)
                    {
                        yield return GetStation(i);
                    }
                }
            }
        }

        public IEnumerable<BO.Station> GetStationsOfLine(BO.Line line)
        {
            for (int i = line.FirstStation; i < line.LastStation; i++)
            {
                yield return GetStation(i);
            }
        }

        public void UpdateStation(int stationCode, Action<Station> update)
        {
            throw new NotImplementedException();
        }

        public void DeleteStation(int stationCode)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Line

        // tool for adapting DO.Line to BO.Line
        private BO.Line lineDoBoAdapter(DO.Line lineDO)
        {
            if (lineDO == null)
                return new BO.Line();

            // we can add more func. by getting the lineDO.Id
            BO.Line lineBO = new BO.Line();
            lineBO.Area = (Enums.Area)lineDO.Area;
            lineBO.Code = lineDO.Code;
            lineBO.FirstStation = lineDO.FirstStation;
            lineBO.LastStation = lineDO.LastStation;
            lineBO.Id = lineDO.ID;

            return lineBO;
        }
        public IEnumerable<Line> GetAllLines()
        {
            var listBO = new List<BO.Line>();

            // from list of DO.Line objects to BO.Line
            foreach (var item in dl.GetAllLines())
            {
                listBO.Add(lineDoBoAdapter(item));
            }

            // each line object has a list of station code index
            foreach (var item in listBO)
            {
                item.stationOfThisLine = new List<int>();

                for (int i = item.FirstStation; i < item.LastStation; i++)
                {
                    item.stationOfThisLine.Add(i);
                }
            }

            return listBO.OrderBy(x => x.Id);
        }
        public IEnumerable<BO.Line> GetAllLinesPassThrough(BO.Station station)
        {
            if (station == null)
                yield break;
            
            int stationCode = station.Code;
            int numberOfLines = GetAllLines().Count();
            var allLines = GetAllLines();
            int from = 0, to = 0;

            //checking all station of all line if the station code match
            for (int i = 0; i < numberOfLines; i++)
            {
                from = allLines.ElementAt(i).FirstStation;
                to = allLines.ElementAt(i).LastStation;

                for (int j = from; j < to; j++)
                {
                    if (j == stationCode)
                        yield return allLines.ElementAt(i);
                }
            }
        }
        public IEnumerable<int> GetAllLinesIdPassThrough(Station station)
        {
            int stationCode = station.Code;
            List<Line> allLines = (List<Line>)GetAllLines();
            int from = 0, to = 0;

            for (int i = 1; i <= 10; i++)
            {
                from = allLines.ElementAt(i).FirstStation;
                to = allLines.ElementAt(i).LastStation;

                for (int j = from; j < to; j++)
                {
                    if (j == stationCode)
                    {
                        yield return i;
                    }
                }
            }
        }

        public BO.Line GetLine(int lineId)
        {
            DO.Line lineDO;
            try // if lineId exist in our ds
            {
                lineDO = dl.GetLine(lineId);
            }
            catch (DO.BadLineIDException ex)
            {
                throw new BO.BadLineIDException("line id is not exist", ex);
            }
            return lineDoBoAdapter(lineDO);
        }
        public void AddLine(Line lineBO)
        {
            DO.Line lineDO = new DO.Line();

            lineDO.Area = (DO.Enums.Area)lineBO.Area;
            lineDO.Code = lineBO.Code;
            lineDO.FirstStation = lineBO.FirstStation;
            lineDO.LastStation = lineBO.LastStation;
            lineDO.ID = lineBO.Id;
            try
            {
                dl.AddLine(lineDO);
            }
            catch (DO.BadLineIDException ex)
            {
                throw new BO.BadLineIDException("fail to add the new line", ex);
            }
        }
        public void UpdateLine(Line lineBO)
        {
            DO.Line lineDO = new DO.Line();
            lineBO.CopyPropertiesTo(lineDO);

            try
            {
                dl.UpdateLine(lineDO);
            }
            catch (DO.BadLineIDException ex)
            {
                throw new BO.BadLineIDException("fail to update the new line", ex);
            }
        }
        public void UpdateLine(Line line, Action<Line> update)
        {
            throw new NotImplementedException();
        }
        public void DeleteLine(int lineId)
        {
            Line lineToDelete = GetLine(lineId);

            // each line has a list<int> of code station
            if (lineToDelete != null)
            {
                lineToDelete.stationOfThisLine.Clear();
            }

            // deleteing all linestation of the selected line
            var allLineStations = (List<LineStation>)GetAllLineStations();

            if (allLineStations != null)
            {
                for (int i = 0; i < allLineStations.Count(); i++)
                {
                    if (allLineStations.ElementAt(i).LineId == lineId)
                    {
                        allLineStations.RemoveAt(i);
                    }
                }
            }

            // deleting from the Data source static file
            try
            {
                dl.DeleteLine(lineId);
            }
            catch (DO.BadLineIDException ex)
            {
                throw new BO.BadLineIDException("fail to delete line", ex);
            }
        }

        public void DeleteStationOfLine(Line lineBO, StationCustom stationBO)
        {
            int from = lineBO.FirstStation;
            int to = lineBO.LastStation;

            // if we have only one station in our Line to delete
            if (lineBO.stationOfThisLine.Count() == 1)
            {
                DeleteLine(lineBO.Code);
            }

            // deleting every station associed to our Line to delete
            for (int i = from; i < to; i++)
            {
                if (i == stationBO.Code)
                {
                    dl.DeleteLineStation(i);
                    lineBO.stationOfThisLine.Remove(i);
                }
            }
        }
        public void DeleteLine(Line line)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region StationCustom

        /// <summary>
        /// creating a list of CustomStation wich contain all the informations we could need
        /// </summary>
        /// <returns>a list of StationCustom</returns>
        public IEnumerable<StationCustom> GetAllCustomStations()
        {
            var stationList = GetAllStations();
            var lineStationList = GetAllLineStations();
            var adjStationList = GetAllAdjStations();
            var customStationList = new List<BO.StationCustom>();
            int numberOfElement = stationList.Count();

            // getting all the informations relevant for our StationCustom...
            for (int i = 0; i < numberOfElement; i++)
            {
                var adj = adjStationList.FirstOrDefault(x => x.Station2 == stationList.ElementAt(i).Code);
                if (adj == null)
                {
                    adj = new AdjacentStations();
                    adj.Time = new TimeSpan();
                    adj.Distance = 0;
                }
                var statLine = lineStationList.FirstOrDefault(x => x.Station == stationList.ElementAt(i).Code);
                if (statLine == null)
                {
                    statLine = new LineStation();
                    statLine.LineStationIndex = 0;
                }
                // ... and putting them into a List
                customStationList.Add(new StationCustom
                {
                    Code = stationList.ElementAt(i).Code,
                    Name = stationList.ElementAt(i).Name,
                    Distance = adj.Distance,
                    Time = adj.Time,
                    Lattitude = stationList.ElementAt(i).Lattitude,
                    Longitude = stationList.ElementAt(i).Longitude,
                    LineStationIndex = statLine.LineStationIndex,
                    Adress = stationList.ElementAt(i).Address
                });
            }
            return customStationList;
        }

        /// <summary>
        /// convert a simple BO.Station into StationCustom
        /// </summary>
        /// <param name="stationSimple"></param>
        /// <returns>StationCustom</returns>
        private BO.StationCustom stationToCustom(BO.Station stationSimple)
        {
            BO.StationCustom stationCustom = new StationCustom();

            stationCustom.Code = stationSimple.Code;
            stationCustom.Lattitude = stationSimple.Lattitude;
            stationCustom.Longitude = stationSimple.Longitude;
            stationCustom.Name = stationSimple.Name;

            stationCustom.Time = GetAdjacent(stationSimple).Time;
            stationCustom.LineStationIndex = GetLineStation(stationSimple).LineStationIndex;
            stationCustom.Distance = GetAdjacent(stationSimple).Distance;

            return stationCustom;
        }

        // return all station that are located before the input station in this line
        public IEnumerable<StationCustom> GetAllPrevCusStations(Station stationBO)
        {
            var allStations = GetAllStations();
            var prevCustomStation = new List<BO.StationCustom>();

            if (stationBO == null)
                return new List<StationCustom>();
            
            for (int i = 0; i < allStations.Count(); i++)
            {
                if (allStations.ElementAt(i).Code == stationBO.Code)
                {
                    if (i > 0)
                        prevCustomStation.Add(stationToCustom(allStations.ElementAt(i - 1)));
                }
            }
            return prevCustomStation;
        }

        // return all station that are located after the input station in this line
        public IEnumerable<StationCustom> GetAllNextCusStations(Station stationBO)
        {
            var allStations = GetAllStations();
            var nextCustomStation = new List<BO.StationCustom>();

            if (stationBO == null)
                return new List<StationCustom>();

            for (int i = 0; i < allStations.Count(); i++)
            {
                if (allStations.ElementAt(i).Code == stationBO.Code)
                {
                    if (i < allStations.Count() - 1)
                        nextCustomStation.Add(stationToCustom(allStations.ElementAt(i + 1)));
                }
            }
            return nextCustomStation;
        }

        // add a station to a Line
        public void AddStationToLine(StationCustom station, Line line, int code)
        {
            var stationToAdd = new Station();
            var lineStationToAdd = new LineStation();
            var adjStationToAdd1 = new AdjacentStations();
            var adjStationToAdd2 = new AdjacentStations();
            var lineStationList = GetAllLineStations();

            station.Code = line.LastStation + 5000;

            foreach (int itemCode in line.stationOfThisLine)
            {
                var toUpdate = lineStationList.FirstOrDefault(x => x.Station == itemCode);

                if (itemCode == code + 1)
                {
                    toUpdate.PrevStation = station.Code;
                    toUpdate.LineStationIndex++;
                    if (itemCode == line.LastStation - 1)

                        toUpdate.NextStation = 0;
                    else
                        toUpdate.NextStation++;
                }
                else if (itemCode == code)
                {
                    toUpdate.NextStation = station.Code;
                }
                else if (itemCode == line.LastStation)
                {
                    toUpdate.LineStationIndex++;
                    toUpdate.PrevStation++;
                    toUpdate.NextStation = 0;
                }
                else if (itemCode > code)
                {
                    toUpdate.LineStationIndex++;
                    toUpdate.NextStation++;
                    toUpdate.PrevStation++;
                }
                UpdateLineStation(toUpdate);

            }

            line.LastStation++;
            line.stationOfThisLine.Add(station.Code);

            stationToAdd.Address = station.Adress;
            stationToAdd.Code = station.Code;
            stationToAdd.Lattitude = station.Lattitude;
            stationToAdd.Longitude = station.Longitude;
            stationToAdd.Name = station.Name;
            AddStation(stationToAdd);

            lineStationToAdd.Station = station.Code;
            lineStationToAdd.LineStationIndex = station.LineStationIndex;
            lineStationToAdd.NextStation = GetStation(code + 1).Code;
            lineStationToAdd.PrevStation = GetStation(code).Code;
            lineStationToAdd.LineId = line.Id;
            AddLineStation(lineStationToAdd);

            adjStationToAdd1.Time = station.Time;
            adjStationToAdd1.Distance = station.Distance;
            adjStationToAdd1.Station1 = GetStation(code).Code;
            adjStationToAdd1.Station2 = GetStation(station.Code).Code;
            AddAdjStation(adjStationToAdd1);

            adjStationToAdd2.Station1 = GetStation(station.Code).Code;
            adjStationToAdd2.Station2 = GetStation(code + 1).Code;
            adjStationToAdd2.Time = new TimeSpan(00, 12, 34);
            adjStationToAdd2.Distance = station.Distance * 0.95 + 1;
            AddAdjStation(adjStationToAdd2);
        }

        public void UpdateStation(StationCustom stationCustom)
        {
            DO.AdjacentStations adjStationToUpdate = new DO.AdjacentStations();
            adjStationToUpdate = dl.GetAdjtStation(stationCustom.Code, stationCustom.Code);
            adjStationToUpdate.Time = stationCustom.Time;
            adjStationToUpdate.Distance = stationCustom.Distance;

            dl.UpdateAdjStation(adjStationToUpdate);
        }

        public void UpdateLineStation(BO.LineStation station)
        {
            DO.LineStation lineStationToUpdate = new DO.LineStation();
            lineStationToUpdate.LineStationIndex = station.LineStationIndex;
            lineStationToUpdate.NextStation = station.NextStation;
            lineStationToUpdate.PrevStation = station.PrevStation;
            lineStationToUpdate.Station = station.Station;
            lineStationToUpdate.LineId = station.LineId;
            dl.UpdateLineStation(lineStationToUpdate);
        }

        // return all CustomStation of a Line
        public IEnumerable<StationCustom> GetAllCusStationOfLine(Line line)
        {
            var customStationList = new List<StationCustom>();
            customStationList = (List<StationCustom>)GetAllCustomStations();
            var cusStatToRet = new List<StationCustom>();
            var cusStatToRet1 = new List<StationCustom>();
            var temp = new List<StationCustom>();

            if (line == null)
                return new List<StationCustom>();

            // if the two stations selected are not from the same Line
            if (Math.Abs(line.FirstStation - line.LastStation) >= 32)
            {
                // search for the customStation code thad fit to line code
                var toAdd1 = customStationList.Find(x => x.Code == line.FirstStation);
                var toAdd2 = customStationList.Find(x => x.Code == line.LastStation);
                cusStatToRet.Add(toAdd1);
                cusStatToRet.Add(toAdd2);

                return cusStatToRet;
            }

            int i = 0;
            Random r = new Random(DateTime.Now.Millisecond); // to get a better simulation

            foreach (var stationCode in line.stationOfThisLine)
            {
                var toAdd = customStationList.Find(x => x.Code == stationCode);
                if (i == 0)
                {
                    toAdd.Time = new TimeSpan(0, 0, 0);
                    toAdd.Distance = 0;
                }
                else if (toAdd.Distance == 0 || toAdd.Time == new TimeSpan(0, 0, 0))
                {
                    toAdd.Time = (new TimeSpan(0, r.Next(3, 10), r.Next(0, 50)));
                    toAdd.Distance = r.Next(3, 10);
                }
                cusStatToRet.Add(toAdd);
                i++;
            }
            cusStatToRet1 = cusStatToRet.OrderBy(station => station.LineStationIndex).ToList();

            i = 0;
            foreach (var item in cusStatToRet1)
            {
                item.LineStationIndex = i;
                i++;
            }

            return cusStatToRet1;
        }

        #endregion

        #region adjacentStation

        // tool for adapting DO.AdjacentStations to BO.AdjacentStations
        private BO.AdjacentStations adjStationDoBoAdapter(DO.AdjacentStations adjStationDO)
        {
            if (adjStationDO == null)
            {
                //throw new Exception("probleme with stationDO");
                return new BO.AdjacentStations();
            }

            BO.AdjacentStations adjStationBO = new AdjacentStations();
            DO.AdjacentStations stationToTest;

            int stationCode1 = adjStationDO.Station1;
            int stationCode2 = adjStationDO.Station2;

            try
            {
                stationToTest = dl.GetAdjtStation(stationCode1, stationCode2);
            }
            catch (Exception/*DO.BadAdjStationException*/)
            {
                throw;
            }

            adjStationDO.CopyPropertiesTo(adjStationBO);

            return adjStationBO;
        }

        private BO.AdjacentStations GetAdjacent(BO.Station stationBO)
        {
            DO.AdjacentStations adjacentStationsDO = new DO.AdjacentStations();

            // adjacent station1 code is station2 minus one
            int code1 = stationBO.Code - 1, code2 = stationBO.Code;

            adjacentStationsDO = dl.GetAdjtStation(code1, code2);

            return adjStationDoBoAdapter(adjacentStationsDO);
        }

        private BO.AdjacentStations GetAdjacent(int stationCode)
        {
            DO.AdjacentStations adjacentStationsDO = new DO.AdjacentStations();

            int code1 = stationCode - 1, code2 = stationCode;

            try
            {
                adjacentStationsDO = dl.GetAdjtStation(code1, code2);
            }
            catch (DO.BadAdjStationCodeException ex)
            {
                throw new BO.BadAdjStationCodeException("problem with this adjacent station", ex);
            }

            return adjStationDoBoAdapter(adjacentStationsDO);
        }

        // return all adjacentStation of a donned station
        public IEnumerable<BO.AdjacentStations> GetAllAdjStations(BO.Station stationBO)
        {

            return from adjStation in dl.GetAllAdjStation()
                   where adjStation.Station2 == stationBO.Code
                   select adjStationDoBoAdapter(adjStation);
        }

        public IEnumerable<AdjacentStations> GetAllAdjStations()
        {
            return from adjStation in dl.GetAllAdjStation()
                   select adjStationDoBoAdapter(adjStation);
        }

        public void AddAdjStation(BO.AdjacentStations adjacentStations)
        {
            DO.AdjacentStations adjToAdd = new DO.AdjacentStations();
            adjToAdd.Distance = adjacentStations.Distance;
            adjToAdd.Time = adjacentStations.Time;
            adjToAdd.Station1 = adjacentStations.Station1;
            adjToAdd.Station2 = adjacentStations.Station2;

            try { dl.AddAdjacentStation(adjToAdd); }
            catch (DO.BadAdjStationCodeException ex) { throw new BO.BadAdjStationCodeException("problem with adding this adj. station", ex); }
        }
        #endregion

        #region LineStation

        // tool for adapting DO.LineStation to BO.LineStation
        private BO.LineStation lineStationBoDoAdapter(DO.LineStation lineStationDO)
        {
            if (lineStationDO == null)
                return new BO.LineStation();

            BO.LineStation lineStationBO = new LineStation();
            DO.LineStation lineStationTest;
            int stationCode = lineStationDO.Station;

            try
            {
                lineStationTest = dl.GetLineStation(stationCode);
            }
            catch (DO.BadStationCodeException ex) // not found !
            {
                throw new BO.BadStationCodeException("station not found", ex);
            }
            lineStationDO.CopyPropertiesTo(lineStationBO);

            return lineStationBO;
        }

        private BO.LineStation GetLineStation(BO.Station stationBO)
        {
            DO.LineStation lineStationDO;
            lineStationDO = dl.GetLineStation(stationBO.Code);

            if (stationBO == null)
                return new LineStation();
            
            //try
            //{
            //    lineStationDO = dl.GetLineStation(stationBO.Code);
            //}
            //catch (DO.BadStationCodeException ex) // if not found
            //{
            //    throw new BO.BadStationCodeException("station code does not exist", ex);
            //}

            return lineStationBoDoAdapter(lineStationDO);
        }

        public IEnumerable<BO.LineStation> GetAllLineStations()
        {
            return (from lStationDO in dl.GetAllLineStation()
                    orderby lStationDO.LineId
                    select lineStationBoDoAdapter(lStationDO)).ToList();
        }

        // return all LineStation 
        public IEnumerable<BO.LineStation> GetAllPrevLineStations(Station stationBO)
        {
            int stationCode = stationBO.Code;
            var allLinesStations = GetAllLineStations();
            var prevLinesStation = new List<BO.LineStation>();

            int numOfLines = allLinesStations.Count();

            for (int i = 0; i < numOfLines; i++)
            {
                if (allLinesStations.ElementAt(i).Station == stationCode)
                {
                    prevLinesStation.Add(allLinesStations.ElementAt(0));
                    if (i > 0)
                        prevLinesStation.Add(allLinesStations.ElementAt(i - 1));
                }
            }

            return prevLinesStation;
        }

        public void AddLineStation(BO.LineStation lineStation)
        {
            var lineStToAdd = new DO.LineStation();

            lineStToAdd.LineId = lineStation.LineId;
            lineStToAdd.LineStationIndex = lineStation.LineStationIndex;
            lineStToAdd.NextStation = lineStation.NextStation;
            lineStToAdd.PrevStation = lineStation.PrevStation;
            lineStToAdd.Station = lineStation.Station;

            try { dl.AddLineStation(lineStToAdd); }
            catch (DO.BadStationCodeException ex) { throw new BO.BadStationCodeException("problem with adding this station", ex); }
        }

        #endregion
    }
}