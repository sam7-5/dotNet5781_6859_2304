using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doNet5781_01_6859_2304
{
    public class Bus
    {
        private string busId;
        private DateTime dateInit;
        private int km;
        private int tank;

        // ctor with 2 arguments
        public Bus(string newId, DateTime newDate, int newKm = 0, int newTank = 0) { busId = newId; dateInit = newDate; }

        // properties

        public string BUS_ID
        {
            get { return busId; }
            set { busId = value; }
        }
        // Bus kavEgged = new Bus { BUS_ID = "123-456-789" }; // utilisation de properties
        //int x = int.Parse("123-456-789");

        public void SetBusId(string newId) { busId = newId; }
        public void SetDate(DateTime newDate) { dateInit = newDate; }
        public void SetKm(int newKm) { km = newKm; }
        public void SetTank(int newTank) { tank = newTank; }

        public string GetId() { return busId; }
        public DateTime GetDate() { return dateInit; }
        public int GetKm() { return km; }
        public int GetTank() { return tank; }

        public static void addBus(LinkedList<Bus> buslist)
        {
            DateTime date;
            bool res = DateTime.TryParse(Console.ReadLine(), out date);
            String newBusId = Console.ReadLine();
            buslist.AddLast(new Bus(newBusId, date));
        }
        public static Bus ChooseBus(string Id, LinkedList<Bus> busList)
        {
            //new Random(DateTime.Now.Millisecond)
            //foreach (string id in busList)
            //{

            //    return Bus;
            //}


            Console.WriteLine("ERROR id doesn't exist");
            return null;
        }
        public static Bus treatmentRefuel(string Id)
        {
            return null;
        }
        public static Bus treatmentRevision(string Id)
        {
            return null;
        }
        public static void PrintAll()
        {

        }

    }
}
