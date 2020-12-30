using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DO;

namespace DAL
{
    public class myDAL 
    {
        DS.DataSource dataSource = new DS.DataSource();

        public IEnumerable<Station> GetStations() => dataSource.ListStations;

    }
}
