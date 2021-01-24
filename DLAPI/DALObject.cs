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
            DO.Station station = DataSource.listStations.Find(st => st.Code == codeStation);
            if (station != null)
                return new Station(station); // copy mechanism
            else
                throw new DO.BadStationCodeException(codeStation, $"bad Station code: {codeStation}");
        }
        public IEnumerable<DO.Station> GetAllStations() => DataSource.listStations;

        public void AddStation(DO.Station station)
        {
            if (DataSource.listStations.FirstOrDefault(st => st.Code == station.Code) != null)
                throw new BadStationCodeException(station.Code, $"Station with the same code already exist"); // already in
            else
                DataSource.listStations.Add(station);
        }
        public void UpdateStation(DO.Station stationToAdd)
        {
            DO.Station station = DataSource.listStations.Find(st => st.Code == stationToAdd.Code);

            if (station != null)
            {
                DataSource.listStations.Remove(station);
                DataSource.listStations.Add(new Station(stationToAdd));
            }
            else
                throw new BadStationCodeException(station.Code, $"bad station code: {station.Code}");
        }

        public void DeleteStation(int stationCode)
        {
            DO.Station stationToDlt = DataSource.listStations.Find(st => st.Code == stationCode);

            if (stationToDlt != null)
                DataSource.listStations.Remove(stationToDlt);
            else
                throw new DO.BadStationCodeException(stationCode, $"bad station code: {stationCode}");
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
                throw new BadLineIDException(line.ID, $"problem: for the moment we can't have two lines with the same ID");
            else
                DataSource.listLines.Add(line);
        }
        public DO.Line GetLine(int lineId)
        {
            DO.Line line = DataSource.listLines.Find(ln => ln.ID == lineId);
            if (line != null)
                return new Line(line);
            else
                throw new BadLineIDException(lineId, $"bade Line ID {lineId}");
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
                throw new BadLineIDException(line.ID, $"bade Line ID {line.ID}");
        }
        public void DeleteLine(int lineId)
        {
            DO.Line lineToDlt = DataSource.listLines.Find(ln => ln.ID == lineId);
            if (lineToDlt != null)
                DataSource.listLines.Remove(lineToDlt);
            else
                throw new BadLineIDException(lineId, $"bade Line ID {lineId}");
        }
        #endregion

        #region LineStation
        public IEnumerable<DO.LineStation> GetAllLineStation()
        {
            return DataSource.listLineStations;
        }
        public DO.LineStation GetLineStation(int stationCode)
        {
            DO.LineStation lineStation = DataSource.listLineStations.Find(lst => lst.Station == stationCode);
            if (lineStation != null)
                return new LineStation(lineStation);
            else
                return new LineStation();
            //make station work when we add one 
            // throw new BadStationCodeException(stationCode, $"bad Station code: {stationCode}");
        }
        public void AddLineStation(DO.LineStation lineStation)
        {
            if (DataSource.listLineStations.FirstOrDefault(lst => lst.Station == lineStation.Station) != null)
                throw new BadStationCodeException(lineStation.Station, $"Station with the same code already exist");
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
                throw new BadStationCodeException(lineStation.Station, $"bad Station code: {lineStation.Station}");
        }
        public void DeleteLineStation(int lineId)
        {
            DO.LineStation lstToDlt = DataSource.listLineStations.Find(lst => lst.Station == lineId);
            if (lstToDlt != null)
                DataSource.listLineStations.Remove(lstToDlt);
            else
                throw new BadStationCodeException(lineId, $"bad Station code: {lineId}");
        }
        #endregion

        #region AdjStation
        public IEnumerable<DO.AdjacentStations> GetAllAdjStation()
        {
            return DataSource.listAdjacentStations;
        }
        public DO.AdjacentStations GetAdjtStation(int station1, int station2)
        {
            DO.AdjacentStations adjacentStations = DataSource.listAdjacentStations.Find(st => st.Station1 == station1 || st.Station2 == station2);
            if (adjacentStations != null)
                return new AdjacentStations(adjacentStations);
            else
                /*
                throw new BadAdjStationCodeException(station1, station2, $"bad stations codes: {station1}, {station2}");
                */
                return new AdjacentStations();
        }
        public void AddAdjacentStation(DO.AdjacentStations AdjStation)
        {
            if (DataSource.listAdjacentStations.Find(adjSt => adjSt.Station1 == AdjStation.Station1 && adjSt.Station2 == AdjStation.Station2) != null)
                throw new BadAdjStationCodeException(AdjStation.Station1, AdjStation.Station2, $"thise pair of station already exist");
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
                throw new BadAdjStationCodeException(AdjStation.Station1, AdjStation.Station2, "bad codes");
        }

        public void DeleteAdjStation(int station1, int station2)
        {
            DO.AdjacentStations adjToDlt = DataSource.listAdjacentStations.Find(st => st.Station1 == station1 && st.Station2 == station2);
            if (adjToDlt != null)
                DataSource.listAdjacentStations.Remove(adjToDlt);
            else
                throw new BadAdjStationCodeException(station1, station2, "bad codes");
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

} // namespace DLApi