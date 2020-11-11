using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotNet5781_02_6859_2304
{
    class BusLigneCollection:IEnumerable
    {
        List<BusLigne> mylist;

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        void AddLigne(BusLigne ligne)
        {
            try
            {


                if (mylist.Contains(ligne))
                {
                    if (/*inversede ligne*/)
                    {
                        int i = mylist.IndexOf(ligne);
                        //  mylist.Find(i);

                    }
                    else throw new ArgumentOutOfRangeException("this ligne already exist (and it is not the one in the opposite way)");


                }
                else throw new ArgumentOutOfRangeException("this ligne doesn't exist");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }

            mylist.Add(ligne);
        }
        void DeleteLigne(BusLigne ligne)
        {
            mylist.Remove(ligne);
        }

    }
}
