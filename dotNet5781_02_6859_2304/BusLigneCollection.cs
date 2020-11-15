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
    class BusLigneCollection: IEnumerable,IEnumerator
    {
        List<BusLigne> mylist;

        //---- Debut Essai ----//
        // ctor to fill 10 bus with random values //
        static public Random r = new Random(DateTime.Now.Millisecond);
        public BusLigneCollection()
        {
            for (int i = 0; i < 10; i++)
            {
                mylist.Add(new BusLigne());
            }
        }
        //---- Fin Essai ----//
        public object Current => throw new NotImplementedException();

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        void AddLigne(BusLigne ligne)
        {
            try
            {
                if (mylist.Contains(ligne))
                {
                    if (mylist.ElementAt(mylist.IndexOf(ligne)).First==ligne.Last)   //doute si ya besoin
                    {
                        mylist.Add(ligne);
                        //  throw new ArgumentOutOfRangeException("this ligne already exist");

                    }
                    else throw new ArgumentOutOfRangeException("this ligne already exist (and it is not the one in the opposite way)");
                }
                else
                    mylist.Add(ligne);
            }

            catch (Exception ex)   //no exception!
            {
                Console.WriteLine(ex.Message);
            }
        }

        void DeleteLigne(BusLigne ligne) //ajout si ligne exist dans l'autre sens
        {
         try
            {
                if (!mylist.Contains(ligne))
                    throw new ArgumentOutOfRangeException("this ligne doesn't exist");

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            mylist.Remove(ligne);
        }
    }
}
