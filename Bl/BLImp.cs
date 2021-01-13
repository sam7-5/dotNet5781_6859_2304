using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DLAPI;
using BO;
//using DO;
using System.Collections.Generic;
using ClassLibrary1.DLAPI;

namespace BL
{
    class BLImp : IBL
    {
        IDL dl = DLFactory.GetDL();

        #region station

        //DONE
        BO.Station stationDoBoAdapter(DO.Station stationDO)
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
        public void AddStation(Station station)
        {
            DO.Station stationDO = new DO.Station();
            #region copying properties
            stationDO.Code = station.Code;
            stationDO.Address = station.Address;
            stationDO.Lattitude = station.Lattitude;
            stationDO.Longitude = station.Longitude;
            stationDO.Name = station.Name;
            #endregion
            dl.AddStation(stationDO);
        }

        // BONUS
        public void DeleteStation(int stationCode)
        {
            throw new NotImplementedException();
        }

        // DONE
        public IEnumerable<Station> GetAllStations()
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

        public void UpdateStation(Station station)
        {
            throw new NotImplementedException();
        }

        public void UpdateStation(int stationCode, Action<Station> update)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
