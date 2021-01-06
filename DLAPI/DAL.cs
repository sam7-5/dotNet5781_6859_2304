using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS;

namespace DLAPI
{
    sealed class DAL: IDL // not to heritate
    {                     // need to implemente singleton logic to DAL Class

        // implement IDL with CRUD Logic
        // ======= INPORTANT : IMPLEMENTE STATIC CLONE TOOL ======= //
        #region Station
        public DO.Station GetStation(int codeStation)
        {
            //------------------- This is the best way, not for now --------------//
            /*
            DO.Station station = ds.listStations.Find(st => st.Code == codeStation);
            if (station != null)
                return station.Clone();
            else
                throw new DO.BadStationIdException(codeStation, "bad station code: {codeStation}");
            */

            return DataSource.listStations.Find(st => st.Code == codeStation);
        }
        public IEnumerable<DO.Station> GetAllStations()
        {
            //------------------- This is the best way, not for now --------------//
            /*
            return from station in ds.listStations
                   select station.Clone();
            */
            return DataSource.listStations;
        }
        public void AddStation(DO.Station station)
        {
            if (DataSource.listStations.FirstOrDefault(st => st.Code == station.Code) != null)
                ds.listStations.Add(station);
            else
                throw new NotImplementedException(); // not find
        }
        public void UpdateStation(DO.Station station)
        {
            DO.Station stationToUpdate = DataSource.listStations.Find(st => st.Code == station.Code);

            if (stationToUpdate != null)
            {
                DataSource.listStations.Remove(station);
                DataSource.listStations.Add(stationToUpdate/*.Clone()*/);
            }
            else
                throw new NotImplementedException();
        }
        public void UpdateStation(int stationCode, Action<DO.Station> update)
        {
            throw new NotImplementedException();
        }
        public void DeleteStation(int stationCode)
        {
            DO.Station stationToDlt = DataSource.listStations.Find(st => st.Code == stationCode);
           
            if (stationToDlt != null)
                DataSource.listStations.Remove(stationToDlt);
            else
                throw new NotImplementedException();
        }
        #endregion




    }
}
