using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLAPI
{
    // CRUD Logic:
    // Create - add new instance
    // Request - ask for an instance or for a collection
    // Update - update properties of an instance
    // Delete - delete an instance

    public interface IDL
    {
        #region Station
        IEnumerable<DO.Station> GetAllStations();
        DO.Station GetStation(int stationCode);
        void AddStation(DO.Station station);
        void UpdateStation(DO.Station station);
        void UpdateStation(int stationCode, Action<DO.Station> update); // updt specific fields in Stqation
        void DeleteStation(int stationCode);
        #endregion

        #region Bus
        // to code...
        #endregion

        #region Line
        // to code...
        #endregion

        #region LineStation // difference with Station ?
        // to code...
        #endregion

        #region BusOnTrip
        // to code...
        #endregion

        #region AdjacentStations
        // to code...
        #endregion

    }
}
