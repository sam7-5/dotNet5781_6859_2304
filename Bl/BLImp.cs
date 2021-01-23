﻿using System;
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

        // ---
        private BO.Station stationDoBoAdapter(DO.Station stationDO)
        {
            BO.Station stationBO = new BO.Station();
            DO.Station stationToTest;

            if (stationDO == null)
            {
                return stationBO;
            }

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

        // ---
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

        // DONE
        public IEnumerable<BO.Station> GetAllStations()
        {
            return from stationDO in dl.GetAllStations()
                   orderby stationDO.Code
                   select stationDoBoAdapter(stationDO);
        }

        // ---
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

        // ---
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

        // DONE
        public IEnumerable<BO.Station> GetAllStationsOfArea(Enums.Area area)
        {
            //List<BO.Station> listBO = new List<Station>();
            foreach (var LineDO in dl.GetAllLines())
            {

                if (LineDO.Area.CompareTo((DO.Enums.Area)area) == 0)
                {
                    int from, to = 0;
                    from = LineDO.FirstStation;
                    to = LineDO.LastStation;

                    for (int i = from; i < to; i++)
                    {
                        yield return GetStation(i);
                        //listBO.Add(GetStation(i));
                    }
                }
            }
            //return listBO;
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
            /*
            return from lDo in dl.GetAllLines()
                   orderby lDo.Code
                   select lineDoBoAdapter(lDo);
            */

            var listBO = new List<BO.Line>();

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
            {
                yield break;
            }

            int stationCode = station.Code;
            var allLines = GetAllLines();
            int from = 0, to = 0;

            for (int i = 0; i < 10; i++)
            {
                from = allLines.ElementAt(i).FirstStation;
                to = allLines.ElementAt(i).LastStation;

                for (int j = from; j < to; j++)
                {
                    if (j == stationCode)
                    {
                        yield return allLines.ElementAt(i);
                    }
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
            catch(DO.BadLineIDException ex)
            {
                throw new BO.BadLineIDException("fail to add the new line", ex);
            }
        }
        public void UpdateLine(Line lineBO)
        {
            DO.Line lineDO = new DO.Line();
            lineBO.CopyPropertiesTo(lineDO);
            //dl.AddLine(lineDO);
            try
            {
                dl.UpdateLine(lineDO);
            }
            catch (DO.BadLineIDException ex)
            {
                throw new BO.BadLineIDException("fail to update the new line", ex); // fail to update the new line
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
            catch(DO.BadLineIDException ex)
            {
                throw new BO.BadLineIDException("fail to delete line", ex);
            }
        }
        public void DeleteStationOfLine(Line lineBO, StationCustom stationBO)
        {
            int from = lineBO.FirstStation;
            int to = lineBO.LastStation;

            if (lineBO.stationOfThisLine.Count() == 1)
            {
                DeleteLine(lineBO.Code);
            }

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
        /// create a list of CustomStation wich contain all the informations we could need
        /// </summary>
        /// <returns>a list of StationCustom</returns>
        public IEnumerable<StationCustom> GetAllCustomStations()
        {
            var stationList = GetAllStations();
            var lineStationList = GetAllLineStations();
            var adjStationList = GetAllAdjStations();
            var customStationList = new List<BO.StationCustom>();
            int numberOfElement = stationList.Count();

            for (int i = 0; i < numberOfElement; i++)
            {
                //TimeSpan time = adjStationList.Find(x => x.Station1 == stationList.ElementAt(i).Code).Time;
                var adj = adjStationList.FirstOrDefault(x => x.Station1 == stationList.ElementAt(i).Code);
                if (adj == null)
                {
                    adj = new AdjacentStations();
                    adj.Time = new TimeSpan();
                    adj.Distance = 0;
                }

                customStationList.Add(new StationCustom
                {
                    Code = stationList.ElementAt(i).Code,
                    Name = stationList.ElementAt(i).Name,
                    Distance = adj.Distance,
                    Time = adj.Time/*adjStationList.ElementAt(i/2).Time*/,
                    Lattitude = stationList.ElementAt(i).Lattitude,
                    Longitude = stationList.ElementAt(i).Longitude,
                    LineStationIndex = lineStationList.ElementAt(i).LineStationIndex,
                    Adress = stationList.ElementAt(i).Address // essai
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

        public IEnumerable<StationCustom> GetAllPrevCusStations(Station stationBO)
        {
            var allStations = GetAllStations();
            var prevCustomStation = new List<BO.StationCustom>();
            if (stationBO == null)
            {
                return new List<StationCustom>();
            }
            for (int i = 0; i < allStations.Count(); i++)
            {
                if (allStations.ElementAt(i).Code == stationBO.Code)
                {
                    //prevCustomStation.Add(stationToCustom(allStations.ElementAt(0)));

                    if (i > 0)
                        prevCustomStation.Add(stationToCustom(allStations.ElementAt(i - 1)));
                }
            }

            return prevCustomStation;
        }

        public IEnumerable<StationCustom> GetAllNextCusStations(Station stationBO)
        {
            var allStations = GetAllStations();
            var nextCustomStation = new List<BO.StationCustom>();
            if (stationBO == null)
            {
                return new List<StationCustom>();
            }
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

        // ********************** to test ! ****************************//
        public void AddStationToLine(StationCustom station, Line line)
        {
            var stationToAdd = new Station();
            var lineStationToAdd = new LineStation();
            var adjStationToAdd1 = new AdjacentStations();
            var adjStationToAdd2 = new AdjacentStations();

            stationToAdd.Address = station.Adress;
            stationToAdd.Code = station.Code;
            stationToAdd.Lattitude = station.Lattitude;
            stationToAdd.Longitude = station.Longitude;
            AddStation(stationToAdd);

            lineStationToAdd.Station = station.Code;
            lineStationToAdd.LineStationIndex = station.LineStationIndex;
            lineStationToAdd.NextStation = GetStation(station.LineStationIndex + 1).Code; // tres foireux: le plus un fait flipper
            lineStationToAdd.PrevStation = GetStation(station.LineStationIndex - 1).Code;
            lineStationToAdd.LineId = line.Id;
            AddLineStation(lineStationToAdd);

            adjStationToAdd1.Time = station.Time;
            adjStationToAdd1.Distance = station.Distance;
            adjStationToAdd1.Station1 = GetStation(station.LineStationIndex - 1).Code;
            adjStationToAdd1.Station2 = GetStation(station.LineStationIndex).Code;
            AddAdjStation(adjStationToAdd1);

            adjStationToAdd2.Station1 = GetStation(station.LineStationIndex).Code;
            adjStationToAdd2.Station2 = GetStation(station.LineStationIndex + 1).Code;
            adjStationToAdd2.Time = new TimeSpan(00, 12, 34);             // random values
            adjStationToAdd2.Distance = station.Distance * 0.95 + 1;      // random values
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
        public IEnumerable<StationCustom> GetAllCusStationOfLine(Line line)
        {
            var customStationList = new List<StationCustom>();
            customStationList = (List<StationCustom>)GetAllCustomStations();
            var cusStatToRet = new List<StationCustom>();
            if (line == null)
            {
                return new List<StationCustom>();
            }

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

            // else does the first station is located before last station selected
            if (line.FirstStation <= line.LastStation)
            {
                for (int i = line.FirstStation, j = 0; i < line.LastStation && j < line.stationOfThisLine.Count(); i++)
                {
                    if (line.stationOfThisLine.ElementAt(j) == i)
                    {
                        var toAdd = customStationList.Find(y => y.Code == i);
                        cusStatToRet.Add(toAdd);
                        j++;
                    }
                }
                return cusStatToRet;
            }
            else
            {
                for (int i = line.LastStation, j = 0; i < line.FirstStation && j < line.stationOfThisLine.Count(); i++)
                {
                    if (line.stationOfThisLine.ElementAt(j) == i)
                    {
                        var toAdd = customStationList.Find(y => y.Code == i);
                        cusStatToRet.Add(toAdd);
                        j++;
                    }
                }
                return cusStatToRet;
            }
        }
        public IEnumerable<StationCustom> GetAllCusStationOfLine(int line)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region adjacentStation

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

            int code1 = stationBO.Code - 1, code2 = stationBO.Code;

            adjacentStationsDO = dl.GetAdjtStation(code1, code2);
            /*
            try
            {
                adjacentStationsDO = dl.GetAdjtStation(code1, code2);
            }
            catch (DO.BadAdjStationCodeException ex)
            {
                throw new BO.BadAdjStationCodeException("problem with this adjacent station", ex);
            }
            */
            
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

        public IEnumerable<BO.AdjacentStations> GetAllAdjStations(BO.Station stationBO)
        {

            return from adjStation in dl.GetAllAdjStation()
                   where adjStation.Station2 == stationBO.Code
                   select adjStationDoBoAdapter(adjStation);

            /*
            var listAdjDO = dl.GetAllAdjStation();
            var listToreturn = new List<AdjacentStations>();

            foreach (var item in listAdjDO)
            {
                if (item.Station2 == stationBO.Code)
                {
                    listToreturn.Add(item);
                }
            }
            */
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
            try
            {
                lineStationDO = dl.GetLineStation(stationBO.Code);
            }
            catch (DO.BadStationCodeException ex) // if not found
            {
                throw new BO.BadStationCodeException("station code does not exist", ex);
            }

            return lineStationBoDoAdapter(lineStationDO);
        }

        public IEnumerable<BO.LineStation> GetAllLineStations()
        {
            return (from lStationDO in dl.GetAllLineStation()
                    orderby lStationDO.LineId
                    select lineStationBoDoAdapter(lStationDO)).ToList();
        }

        public IEnumerable<BO.LineStation> GetAllPrevLineStations(Station stationBO)
        {

            int stationCode = stationBO.Code;
            //List<BO.LineStation> allLinesStations = (List<LineStation>)GetAllLineStations();
            var allLinesStations = GetAllLineStations();
            var prevLinesStation = new List<BO.LineStation>();

            //foreach (var lineBO in allLinesStations)
            //{
            //    if (lineBO.Station == stationCode)
            //    {
            //        prevLinesStation.Add(lineBO);
            //    }
            //}

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