using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Line
    {
        #region
        private int id;
        private int code;
        private Area area;
        private int firstStation;
        private int lastStation;
        #endregion

        #region properties
        public int Id { get => id; set { id = value; } }
        public int Code { get => code; set { code = value; } }
        public Area Area { get => area; set { area = value; } }
        public int FirstStation { get => firstStation; set { firstStation = value; } }
        public int LastStation { get => lastStation; set { lastStation = value; } }
        #endregion
    }
}
