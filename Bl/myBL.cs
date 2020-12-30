using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class myBL
    {
       
        public DAL.myDAL myDataAcess = new DAL.myDAL();

        // can't acces to static method Getstation of myDal

       /* public List<DAL.DO.Station> stations()
        {
            var sts = myDataAcess.PrintSomething();
        }
       */
        
    }
}
