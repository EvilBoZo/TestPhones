using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPhones.Models
{
    class DockingStation3G : DockingStation
    {
        public DockingStation3G(string number) : base(number) { }

        public void PhoneReg(Phone3G phone) // перегрузка метода регистрации 3G телефонов
        {
            IMEIList.Add(phone.IMEI);
            phone.dockingStationNumber = Number;
            // дополнительные действия для 3G
        }
    }
}
