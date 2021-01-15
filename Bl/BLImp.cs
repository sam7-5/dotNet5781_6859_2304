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

        public void DeleteStation(int stationCode)
        {
            throw new NotImplementedException();
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
            try
            {
                dl.UpdateStation(stationDO);
            }
            catch (Exception)
            {

                throw; // fail to update the new station
            }
        }

        public void UpdateStation(int stationCode, Action<Station> update)
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
            lineDO.CopyPropertiesTo(lineBO);

            return lineBO;
        }

        // DONE
        public IEnumerable<Line> GetAllLines()
        {
            return from lDo in dl.GetAllLines()
                   orderby lDo.Code
                   select lineDoBoAdapter(lDo);
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

        public void AddLine(Line line)
        {
            throw new NotImplementedException();
        }

        public void UpdateLine(Line line)
        {
            throw new NotImplementedException();
        }

        public void UpdateLine(Line line, Action<Line> update)
        {
            throw new NotImplementedException();
        }

        public void DeleteLine(int lineId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Station> GetAllLinesPassThrough(Station staion)
        {
            throw new NotImplementedException();
        }

        #endregion


        public IEnumerable<StationCustom> GetAllPrevCusStations(Station station)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StationCustom> GetAllNextCusStations(Station station)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Station> GetAllStationsOfArea(Enums.Area area)
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
            throw new NotImplementedException();
        }

        public IEnumerable<StationCustom> GetAllCusStationOfLine(int line)
        {
            throw new NotImplementedException();
        }

        public void DeleteLine(Line line)
        {
            throw new NotImplementedException();
        }

        public void DeleteStationOfLine(Line line, Station station)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetAllLinesIdPassThrough(Station station)
        {
            throw new NotImplementedException();
        }
    }
}
