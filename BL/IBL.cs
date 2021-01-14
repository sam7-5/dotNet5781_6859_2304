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
        void UpdateStation(int stationCode, Action<BO.Station> update); // updt specific fields in Stqation
        void DeleteStation(int stationCode);
        //---------------------------//
        IEnumerable<int> GetAllLinesPassThrough(BO.Station station);
        IEnumerable<BO.StationCustom> GetAllPrevCusStations(BO.Station station);
        IEnumerable<BO.Station> GetAllStationsOfArea(BO.Enums.Area area);
        void AddStation(BO.StationCustom);
        void UpdateStation(BO.StationCustom);
        //--------------------------//
        #endregion

        #region line
        //-----------------------------------------------------------------//
        IEnumerable<BO.Line> GetAllLines();
        IEnumerable<BO.StationCustom> GetAllCusStationOfLine(BO.Line line);
        IEnumerable<BO.StationCustom> GetAllCusStationOfLine(int line);
        void DeleteLine(BO.Line line);
        void AddLine(BO.Line line);
        void UpdateLine(BO.Line line);
        void DeleteStationOfLine(BO.Line line, BO.Station station);
        //-----------------------------------------------------------------//
        #endregion

    }
}