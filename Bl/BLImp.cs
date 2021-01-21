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

        //DONE
        private BO.Station stationDoBoAdapter(DO.Station stationDO)
        {
            BO.Station stationBO = new BO.Station();
            DO.Station stationToTest;
            int stationCode = stationDO.Code;

            try
            {
                stationToTest = dl.GetStation(stationCode);
            }
            catch (Exception/*DO.BadStationException*/)
            {   
                throw;
            }

            stationDO.CopyPropertiesTo(stationBO);

            return stationBO;
        }

        // DONE
        public void AddStation(BO.Station station)
        {
            DO.Station stationDO = new DO.Station();

            stationDO.Code = station.Code;
            stationDO.Address = station.Address;
            stationDO.Lattitude = station.Lattitude;
            stationDO.Longitude = station.Longitude;
            stationDO.Name = station.Name;

            dl.AddStation(stationDO);
        }

        // DONE
        public IEnumerable<BO.Station> GetAllStations()
        {
            return from stationDO in dl.GetAllStations()
                   orderby stationDO.Code
                   select stationDoBoAdapter(stationDO);
        }

        // DONE
        public Station GetStation(int stationCode)
        {
            DO.Station stationDO;
            try
            {
                stationDO = dl.GetStation(stationCode);
            }
            // to implemente...
            catch (Exception)
            {
                throw;
            }
            return stationDoBoAdapter(stationDO);
        }

        // DONE
        public void UpdateStation(BO.Station stationBO)
        {
            DO.Station stationDO = new DO.Station();
            stationBO.CopyPropertiesTo(stationDO);
                dl.UpdateStation(stationDO);
            //try
            //{
            //}
            //catch (Exception)
            //{

            //    throw; // fail to update the new station
            //}
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

        // a tester !
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
        // DONE
        private BO.Line lineDoBoAdapter(DO.Line lineDO)
        {
            // we can add more func. by getting the lineDO.Id
            BO.Line lineBO = new BO.Line();
            lineBO.Area = (Enums.Area)lineDO.Area;
            lineBO.Code = lineDO.Code;
            lineBO.FirstStation=lineDO.FirstStation;
            lineBO.LastStation = lineDO.LastStation;
            lineBO.Id = lineDO.ID;
           // lineDO.CopyPropertiesTo(lineBO);

            return lineBO;
        }

        // DONE
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

        // DONE
        public BO.Line GetLine(int lineId)
        {
            DO.Line lineDO;
            try // if lineId exist in our ds
            {
                lineDO = dl.GetLine(lineId);
            }
            catch (Exception) // DO.exception to imp.
            {
                throw; // BO.exception
            }
            return lineDoBoAdapter(lineDO);
        }

        // DONE ! --> to test
        public void AddLine(Line lineBO)
        {
            DO.Line lineDO = new DO.Line();

            lineDO.Area = (DO.Enums.Area)lineBO.Area;
            lineDO.Code = lineBO.Code;
            lineDO.FirstStation = lineBO.FirstStation;
            lineDO.LastStation = lineBO.LastStation;
            lineDO.ID = lineBO.Id;

            dl.AddLine(lineDO);
        }

        // DONE ! --> to test
        public void UpdateLine(Line lineBO)
        {
            DO.Line lineDO = new DO.Line();
            lineBO.CopyPropertiesTo(lineDO);
            //dl.AddLine(lineDO);
            try
            {
                dl.UpdateLine(lineDO);
            }
            catch (Exception)
            {
                throw; // fail to update the new line
            }
        }

        // DONE ! --> to test
        public IEnumerable<BO.Line> GetAllLinesPassThrough(BO.Station station)
        {
            if (station == null)
                throw new Exception("probleme with station !");
            
            int stationCode = station.Code;
            var allLines = GetAllLines();
            int from = 0, to = 0;

            for (int i = 0; i < 10; i++)
            {
                from = allLines.ElementAt(i).FirstStation;
                to = allLines.ElementAt(i).LastStation;

                for (int j = from;  j < to; j++)
                {
                    if (j == stationCode)
                    {
                        yield return allLines.ElementAt(i);
                    }
                }
            }

        }

        // DONE ! --> to test
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

        public void UpdateLine(Line line, Action<Line> update)
        {
            throw new NotImplementedException();
        }

        public void DeleteLine(int lineId)
        {
            try
            {
                dl.DeleteLine(lineId);
            }
            catch (Exception/*DO.exception*/)
            {

                throw; // new BO.exception
            }
        }

        public void DeleteStationOfLine(Line lineBO, Station stationBO)
        {
            throw new NotImplementedException();
        }

        public void DeleteLine(Line line)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region StationCustom

        // TO TEST !
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
                customStationList.Add(new StationCustom
                { Code = stationList.ElementAt(i).Code,
                Name = stationList.ElementAt(i).Name, Distance = adjStationList.ElementAt(i/2).Distance,
                Time = adjStationList.ElementAt(i/2).Time, Lattitude = stationList.ElementAt(i).Lattitude,
                Longitude = stationList.ElementAt(i).Longitude, LineStationIndex = lineStationList.ElementAt(i).LineStationIndex,
                });
            }
            //customStationList.RemoveAt(customStationList.Count()-1);
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

        /*
        private BO.StationCustom lineStationToCustom(BO.LineStation lineStation)
        {
            BO.StationCustom stationCustom = new StationCustom();

            stationCustom.Code = lineStation.Station;
            stationCustom.Lattitude = GetStation(lineStation.Station).Lattitude;
            stationCustom.Longitude = GetStation(lineStation.Station).Longitude;
            stationCustom.Name = GetStation(lineStation.Station).Name;

            stationCustom.Time = GetAdjacent(lineStation.Station).Time;
            stationCustom.LineStationIndex = lineStation.LineStationIndex;
            stationCustom.Distance = GetAdjacent(lineStation.Station).Distance;

            return stationCustom;
        }
        */

        // TO TEST
        public IEnumerable<StationCustom> GetAllPrevCusStations(Station stationBO)
        {
            var allStations = GetAllStations();
            var prevCustomStation = new List<BO.StationCustom>();

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

        // TO TEST
        public IEnumerable<StationCustom> GetAllNextCusStations(Station stationBO)
        {
            var allStations = GetAllStations();
            var nextCustomStation = new List<BO.StationCustom>();

            for (int i = 0; i < allStations.Count(); i++)
            {
                if (allStations.ElementAt(i).Code == stationBO.Code)
                {
                    if (i  < allStations.Count()-1 ) 
                        nextCustomStation.Add(stationToCustom(allStations.ElementAt(i + 1)));
                }
            }

            return nextCustomStation;
        }

        public void AddStation(StationCustom station)
        {
            throw new NotImplementedException();
        }

        public void UpdateStation(StationCustom station)
        {
            throw new NotImplementedException();
        }

        // TO TEST
        public IEnumerable<StationCustom> GetAllCusStationOfLine(Line line)
        {
            var customStationList = new List<StationCustom>();
            customStationList = (List<StationCustom>)GetAllCustomStations();
            var cusStatToRet = new List<StationCustom>();

            if(Math.Abs(line.FirstStation - line.LastStation) >= 32)
            {
                var toAdd1 = customStationList.Find(x => x.Code == line.FirstStation);
                var toAdd2 = customStationList.Find(x => x.Code == line.LastStation);
                cusStatToRet.Add(toAdd1);
                cusStatToRet.Add(toAdd2);

                return cusStatToRet;
            }


            if (line.FirstStation <= line.LastStation)
            {
                for (int i = line.FirstStation; i < line.LastStation; i++)
                {
                    var toAdd = customStationList.Find(y => y.Code == i);
                    cusStatToRet.Add(toAdd);
                }
                return cusStatToRet;
            }
            else
            {
                for (int i = line.LastStation; i < line.FirstStation; i++)
                {
                    var toAdd = customStationList.Find(y => y.Code == i);
                    cusStatToRet.Add(toAdd);
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

        // DONE ! --> to test
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

            try
            {
                adjacentStationsDO = dl.GetAdjtStation(code1, code2);
            }
            // to implemente...
            catch (Exception)
            {
                throw;
            }
            return adjStationDoBoAdapter(adjacentStationsDO);
        }

        // DONE ! --> to test
        public IEnumerable<BO.AdjacentStations> GetAllAdjStations(BO.Station stationBO)
        {
            return from adjStation in dl.GetAllAdjStation()
                   where adjStation.Station2 == stationBO.Code
                   select adjStationDoBoAdapter(adjStation);
        }

        // DONE ! --> to test
        public IEnumerable<AdjacentStations> GetAllAdjStations()
        {
            return from adjStation in dl.GetAllAdjStation()
                   select adjStationDoBoAdapter(adjStation);
        }

        #endregion

        #region LineStation

        private BO.LineStation lineStationBoDoAdapter(DO.LineStation lineStationDO)
        {
            BO.LineStation lineStationBO = new LineStation();
            DO.LineStation lineStationTest;
            int stationCode = lineStationDO.Station;

            try
            {
               lineStationTest = dl.GetLineStation(stationCode);
            }
            catch (Exception) // not found !
            {
                throw;
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
            catch (Exception) // if not found
            {
                throw;
            }

            return lineStationBoDoAdapter(lineStationDO);            
        }

        public IEnumerable<BO.LineStation> GetAllLineStations()
        {
            return from lStationDO in dl.GetAllLineStation()
                   orderby lStationDO.LineId
                   select lineStationBoDoAdapter(lStationDO);
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
                        prevLinesStation.Add(allLinesStations.ElementAt(i-1));
                }
            }

            return prevLinesStation;
        }

        #endregion
    }
}