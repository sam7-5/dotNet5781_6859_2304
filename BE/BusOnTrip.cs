using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class BusOnTrip
    {
        int Id;
        int LicenseNum;
        int LineId;
        TimeSpan PlannedTakeOff;
        TimeSpan ActualTakeOff;
        int PrevStation;
        TimeSpan PrevStationAT;
        TimeSpan NextStationAt;
    }
}
