using DO;
using DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DLAPI
{
    internal sealed class DALObject : IDL
    {
        #region Singleton
        static readonly DALObject instance = new DALObject();
        static DALObject() { }// static ctor to ensure instance init is done just before first usage
        DALObject() { } // default => private
        public static DALObject Instance { get => instance; }// The public Instance property to use
        #endregion

        // implement IDL with CRUD Logic
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
                throw new NotImplementedException(); // already in
            else
                DataSource.listStations.Add(station);
        }
        public void UpdateStation(DO.Station stationToAdd)
        {
            DO.Station station = DataSource.listStations.Find(st => st.Code == stationToAdd.Code);

            if (station != null)
            {
                DataSource.listStations.Remove(station);
                DataSource.listStations.Add(stationToAdd/*.Clone()*/);
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

        #region Line
        public IEnumerable<DO.Line> GetAllLines()
        {
            return DataSource.listLines;
        }
        public void AddLine(DO.Line line)
        {
            if (DataSource.listLines.FirstOrDefault(st => st.ID == line.ID) != null)
                throw new NotImplementedException();
            else
                DataSource.listLines.Add(line);
        }
        public DO.Line GetLine(int lineId)
        {
            return DataSource.listLines.Find(ln => ln.ID == lineId);
        }
        public void UpdateLine(DO.Line line)
        {
            DO.Line line1 = DataSource.listLines.Find(ln => ln.ID == line.ID);

            if (line1 != null)
            {
                DataSource.listLines.Remove(line1);
                DataSource.listLines.Add(line/*.Clone()*/);
            }
            else
                throw new NotImplementedException();
        }
        public void UpdateLine(DO.Line line, Action<DO.Line> update)
        {
            throw new NotImplementedException();
        }
        public void DeleteLine(int lineId)
        {
            DO.Line lineToDlt = DataSource.listLines.Find(ln => ln.ID == lineId);
            if (lineToDlt != null)
                DataSource.listLines.Remove(lineToDlt);
            else
                throw new NotImplementedException();
        }
        #endregion

        #region LineStation
        public IEnumerable<DO.LineStation> GetAllLineStation()
        {
            return DataSource.listLineStations;
        }
        public DO.LineStation GetLineStation(int stationCode)
        {
            return DataSource.listLineStations.Find(lst => lst.Station == stationCode);
        }
        public void AddLineStation(DO.LineStation lineStation)
        {
            if (DataSource.listLineStations.FirstOrDefault(lst => lst.Station == lineStation.Station) != null)
                throw new NotImplementedException(); // not find
            else
                DataSource.listLineStations.Add(lineStation);
        }
        public void UpdateLineStation(DO.LineStation lineStation)
        {
            DO.LineStation lineStation1 = DataSource.listLineStations.Find(lst => lst.LineId == lineStation.LineId);
            if (lineStation1 != null)
            {
                DataSource.listLineStations.Remove(lineStation1);
                DataSource.listLineStations.Add(lineStation);
            }
            else
                throw new NotImplementedException();
        }
        public void UpdateLineStation(DO.LineStation line, Action<DO.LineStation> update)
        {
            throw new NotImplementedException();
        }
        public void DeleteLineStation(int lineId)
        {
            DO.LineStation lstToDlt = DataSource.listLineStations.Find(lst => lst.Station == lineId);
            if (lstToDlt != null)
                DataSource.listLineStations.Remove(lstToDlt);
            else
                throw new NotImplementedException();
        }
        #endregion

        #region AdjStation
        public IEnumerable<DO.AdjacentStations> GetAllAdjStation()
        {
            return DataSource.listAdjacentStations;
        }
        public DO.AdjacentStations GetAdjtStation(int station1, int station2)
        {
            return DataSource.listAdjacentStations.Find(st => st.Station1 == station1 || st.Station2 == station2);
        }
        public void AddAdjacentStation(DO.AdjacentStations AdjStation)
        {
            if (DataSource.listAdjacentStations.Find(adjSt => adjSt.Station1 == AdjStation.Station1 && adjSt.Station2 == AdjStation.Station2) != null)
                throw new NotImplementedException(); // already exist !
            else
                DataSource.listAdjacentStations.Add(AdjStation);
        }
        public void UpdateAdjStation(DO.AdjacentStations AdjStation)
        {
            DO.AdjacentStations adjSt1 = DataSource.listAdjacentStations.Find(st => st.Station1 == AdjStation.Station1 && st.Station2 == AdjStation.Station2);
            if (adjSt1 != null)
            {
                DataSource.listAdjacentStations.Remove(adjSt1);
                DataSource.listAdjacentStations.Add(AdjStation);
            }
            else
                throw new NotImplementedException();
        }
        public void UpdateAdjStation(DO.AdjacentStations AdjStation, Action<DO.LineStation> update)
        {
            throw new NotImplementedException();
        }
        public void DeleteAdjStation(int station1, int station2)
        {
            DO.AdjacentStations adjToDlt = DataSource.listAdjacentStations.Find(st => st.Station1 == station1 && st.Station2 == station2);
            if (adjToDlt != null)
                DataSource.listAdjacentStations.Remove(adjToDlt);
            else
                throw new NotImplementedException();
        }
        #endregion

        #region LineTrip
        public IEnumerable<DO.LineTrip> GetAllLineTrip()
        {
            return DataSource.listLineTrip;
        }
        public DO.LineTrip GetLineTrip(int lineId)
        {
            return DataSource.listLineTrip.Find(lt => lt.Id == lineId);
        }
        public void AddLineTrip(DO.LineTrip lineTrip)
        {
            if (DataSource.listLineTrip.Find(lt => lt.Id == lineTrip.Id) != null)
                throw new NotImplementedException(); // already exist in our ds !
            DataSource.listLineTrip.Add(lineTrip);
        }
        public void UpdateLineTrip(DO.LineTrip lineTrip)
        {
            DO.LineTrip lineTrip1 = DataSource.listLineTrip.Find(lt => lt.Id == lineTrip.Id);
            if (lineTrip1 != null)
            {
                DataSource.listLineTrip.Remove(lineTrip1);
                DataSource.listLineTrip.Add(lineTrip);
            }
            else
                throw new NotImplementedException();

        }
        public void UpdateLineTrip(DO.LineTrip line, Action<DO.LineTrip> update)
        {
            throw new NotImplementedException();
        }
        public void DeleteLineTrip(int lineId)
        {
            DO.LineTrip lineTripToDlt = DataSource.listLineTrip.Find(lt => lt.Id == lineId);
            if (lineTripToDlt != null)
                DataSource.listLineTrip.Remove(lineTripToDlt);
            else
                throw new NotImplementedException();
        }
        #endregion
    }
}