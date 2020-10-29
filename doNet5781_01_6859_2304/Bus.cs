using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace doNet5781_01_6859_2304
{
    public class Bus
    {
        private string busId;        //pk + foncé?
        private DateTime dateInit;
        private int km;
        private int tank;

        // ctor with 2 arguments
        public Bus(string newId, DateTime newDate, int newKm = 0, int newTank = 0 /*pk new?*/) { busId = newId; dateInit = newDate; }

        // properties

        public string BUS_ID
        {
            get { return busId; }
            set { busId = value; }
        }
        // Bus kavEgged = new Bus { BUS_ID = "123-456-789" }; // utilisation de properties
        //int x = int.Parse("123-456-789");

        public void SetBusId(string newId) { busId = newId; }  //pk pas utilise properties?
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
            buslist.AddLast(new Bus(newBusId, date, 0, 1200));
        }
        public static void ChooseBus(string Id, LinkedList<Bus> busList)
        {

            bool flag = false;
            Random r = new Random();
            int busDistance = r.Next(0, 1200);

            foreach (Bus bb in busList)
            {

                if (Id == bb.BUS_ID)
                {
                    flag = true;
                    if(bb.GetKm()==20000)
                    {
                        treatmentRevision(bb.BUS_ID, busList);
                    }

                    if(bb.GetKm()+busDistance>20000)
                    {
                        Console.WriteLine("dangerous bus go for a bus revision");
                        return;
                    }

                  
                    if(bb.GetTank()-busDistance<= 0)
                    {
                        Console.WriteLine("you don't have enough fuel for this trip");
                        return;
                    }

                    bb.tank = bb.GetTank() - busDistance;
                    bb.km = bb.GetKm() + busDistance;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("ERROR id doesn't exist");
            }
        }
        public static void treatmentRefuel(string Id, LinkedList<Bus> busList)
        {
            foreach (Bus bb in busList)
            {
                if (Id == bb.BUS_ID)
                {
                    bb.tank = 1200;
                }

            }

        }
        public static void treatmentRevision(string Id, LinkedList<Bus> busList)
        {
            foreach (Bus bb in busList)
            {
                if (Id == bb.BUS_ID)
                {
                    DateTime currentDate = DateTime.Now;
                    bb.dateInit = currentDate;
                    bb.km = 0;
                }

            }
        }
        public static void PrintAll(LinkedList<Bus> busList)
        {
            foreach (Bus bb in busList)
            {
               // Console.WriteLine({ 0}-3,{1}-3,bb.GetKm(),bb.BUS_ID);

            }
        }
    }
}
