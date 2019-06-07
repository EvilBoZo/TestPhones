using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPhones.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            DockingStation dockStation = new DockingStation("1234567890");
            Phone iPhone = new Phone(new char[] { '1', '2', '3', '4', '1', '2', '3', '4', '1', '2', '3', '4', '2', '3', '4' });

            dockStation.PhoneReg(iPhone);
            iPhone.CallEvent += dockStation.DataProcessing;
            iPhone.Dial("Номер базовой станции");
        }
    }
}
