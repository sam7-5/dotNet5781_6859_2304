using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DLAPI;
using BO;
//using DO;
using System.Collections.Generic;


//-------------------------------------------------------//
//  !!! we considere BL/BO as DL/DO for testing only !!! 
//-------------------------------------------------------//
namespace BL
{
    class BLImp : IBL
    {
        IDL dl = DLFactory.GetDL();

        public void AddStation(Station station)
        {
            throw new NotImplementedException();
        }

        public void DeleteStation(int stationCode)
        {
            throw new NotImplementedException();
        }

        // exception here to debug
        public IEnumerable<Station> GetAllStations()
        {
            return (IEnumerable<BO.Station>)(from stationDO in dl.GetAllStations()
                   orderby stationDO.Code
                   select stationDO);
        }

        public Station GetStation(int stationCode)
        {
            throw new NotImplementedException();
        }

        public void UpdateStation(Station station)
        {
            throw new NotImplementedException();
        }

        public void UpdateStation(int stationCode, Action<Station> update)
        {
            throw new NotImplementedException();
        }
    }
}
