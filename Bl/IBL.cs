﻿using DLAPI;
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
        void UpdateStation(int stationCode, Action<BO.Station> update); // updt specific fields in Station
        void DeleteStation(int stationCode);

        IEnumerable<int> GetAllLinesIdPassThrough(BO.Station station);
        IEnumerable<BO.Station> GetAllStationsOfArea(BO.Enums.Area area);
        #endregion

        #region AdjaSttion

        IEnumerable<BO.AdjacentStations> GetAllAdjStations(BO.Station stationBO);
        IEnumerable<BO.AdjacentStations> GetAllAdjStations();
        void AddAdjStation(BO.AdjacentStations adjacentStations);
        #endregion

        #region LineStation

        IEnumerable<BO.LineStation> GetAllPrevLineStations(BO.Station stationBO);
        IEnumerable<BO.LineStation> GetAllLineStations();
        void UpdateLineStation(BO.LineStation station);
        void AddLineStation(BO.LineStation lineStation);
        #endregion

        #region Line
        IEnumerable<BO.Line> GetAllLines();
        BO.Line GetLine(int lineId);
        void AddLine(BO.Line line);
        void UpdateLine(BO.Line line);
        void UpdateLine(BO.Line line, Action<BO.Line> update);
        void DeleteLine(int lineId);

        IEnumerable<BO.Line> GetAllLinesPassThrough(BO.Station staion);
        void DeleteLine(BO.Line line);
        void DeleteStationOfLine(BO.Line line, BO.StationCustom station);

        #endregion

        #region StationCusrom

        IEnumerable<BO.StationCustom> GetAllCusStationOfLine(BO.Line line);
        IEnumerable<BO.StationCustom> GetAllPrevCusStations(BO.Station station);
        IEnumerable<BO.StationCustom> GetAllNextCusStations(BO.Station station);

        void AddStationToLine(BO.StationCustom station, BO.Line line,int code);
        void UpdateStation(BO.StationCustom station);

        #endregion

    }
}