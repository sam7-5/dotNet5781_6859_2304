using DAL.DO;
using System.Collections.Generic;

namespace DAL
{
    public class myDAL 
    {
        DS.DataSource dataSource = new DS.DataSource();

        public IEnumerable<Station> GetStations() => dataSource.GetAllStations();
        public IEnumerable<Bus> GetBuses() => dataSource.GetAllBuses();
    }
}
