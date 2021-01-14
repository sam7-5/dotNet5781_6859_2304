
using DLAPI;
using System;
using System.Collections.Generic;

namespace BL
{
   public interface IBL
    {
        #region Station
        IEnumerable<BO.Station> GetAllStations();
        BO.Station GetStation(int stationCode);
        void AddStation(BO.Station station);
        void UpdateStation(BO.Station station);
        void UpdateStation(int stationCode, Action<BO.Station> update); // updt specific fields in Stqation
        void DeleteStation(int stationCode);

        #endregion

    }
}