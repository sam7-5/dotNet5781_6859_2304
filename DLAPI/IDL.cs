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
        // DONE !
        #region Station
        IEnumerable<DO.Station> GetAllStations();
        DO.Station GetStation(int stationCode);
        void AddStation(DO.Station station);
        void UpdateStation(DO.Station station);
        void DeleteStation(int stationCode);
        #endregion

        #region Bus
        // to code...
        #endregion

        // DONE !
        #region Line
        IEnumerable<DO.Line> GetAllLines();
        DO.Line GetLine(int lineId);
        void AddLine(DO.Line line);
        void UpdateLine(DO.Line line);
        void DeleteLine(int lineId);
        #endregion

        // DONE !
        #region LineStation // difference with Station ?
        IEnumerable<DO.LineStation> GetAllLineStation();
        DO.LineStation GetLineStation(int lineId);
        void AddLineStation(DO.LineStation lineStation);
        void UpdateLineStation(DO.LineStation lineStation);
        void DeleteLineStation(int lineId);
        #endregion

        // DONE !
        #region AdjacentStations
        IEnumerable<DO.AdjacentStations> GetAllAdjStation();
        DO.AdjacentStations GetAdjtStation(int station1, int station2);
        void AddAdjacentStation(DO.AdjacentStations AdjStation);
        void UpdateAdjStation(DO.AdjacentStations AdjStation);
        void DeleteAdjStation(int station1, int station2);
        #endregion

        // Almost Done, strange pb in DLobject: can't acess to Properties
        #region LineTrip
        /*
        IEnumerable<DO.LineTrip> GetAllLineTrip();
        DO.LineTrip GetLineTrip(int lineId);
        void AddLineTrip(DO.LineTrip line);
        void UpdateLineTrip(DO.LineTrip line);
        void UpdateLineTrip(DO.LineTrip line, Action<DO.LineTrip> update);
        void DeleteLineTrip(int lineId);
        */
        #endregion
    }
}
