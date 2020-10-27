using System;
using System.Collections.Generic;
using System.Text;

namespace doNet5781_01_6859_2304
{
    class Bus
    {
        private string busId;
        private DateTime dateInit ;
        private int km;
        private int tank;

        public void SetBusId (string newId) { busId = newId;}
        public void SetDate (DateTime newDate) {dateInit = newDate;}
        public void SetKm (int newKm) { km = newKm;}
        public void SetTank (int newTank) { tank = newTank;}

        public string GetId() { return busId; }
        public DateTime GetDate() { return dateInit; }
        public int GetKm() { return km; }
        public int GetTank() {return tank;}
    }
}
