using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPhones.Models
{
    class DockingStation
    {
        public string Number { get; }
        public List<string> IMEIList = new List<string>();

        public DockingStation(string number)
        {
            Number = number;

            Console.WriteLine("Создана базовая станция " + Number);
            Console.ReadKey();
        }

        //регистрация телефонов
        public void PhoneReg(Phone phone) 
        {
            IMEIList.Add(phone.IMEI);
            phone.dockingStationNumber = Number;

            Console.WriteLine("Идет регистрация телефона с IMEI " + phone.IMEI);
            Console.ReadKey();
        }

        public void DataProcessing(object sender, CallEventsArgs e)
        {
            Console.WriteLine("Идет обработка вызова " + e.Number + ", телефоном " + e.IMEI);
            Console.ReadKey();
        }
    }
}
