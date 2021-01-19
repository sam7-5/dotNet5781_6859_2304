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

        // DONE ! --> to test
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
            throw new NotImplementedException();
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
        private IEnumerable<StationCustom> GetAllCustomStations()
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

            return customStationList;
        }

        public IEnumerable<StationCustom> GetAllPrevCusStations(Station station)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StationCustom> GetAllNextCusStations(Station station)
        {
            throw new NotImplementedException();
        }

        public void AddStation(StationCustom station)
        {
            throw new NotImplementedException();
        }

        public void UpdateStation(StationCustom station)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StationCustom> GetAllCusStationOfLine(Line line)
        {
            var customStationList = GetAllCustomStations();
            var cusStatToRet = new List<StationCustom>();

            for (int i = line.FirstStation; i < line.LastStation; i++)
            {
                cusStatToRet.Add(customStationList.ElementAt(i));
            }
            return cusStatToRet;
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
            BO.AdjacentStations adjStationBO = new AdjacentStations();
            DO.AdjacentStations stationToTest;
            int stationCode1 = adjStationDO.Station1, stationCode2 = adjStationDO.Station2;

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
                    prevLinesStation.Add(allLinesStations.ElementAt(i-1));
                }
            }

            return prevLinesStation;
        }

        #endregion
    }
}
