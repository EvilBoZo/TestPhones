using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPhones.Models
{
    // Класс данных для события исходящего звонка
    class CallEventsArgs
    {
        public string IMEI { get; }
        public string Number { get; }

        public CallEventsArgs(string iMEI, string number)
        {
            IMEI = iMEI;
            Number = number;
        }
    }

    class Phone
    {
        public string IMEI { get; }
        public string SIM { get; set; }

        // телефонная книга <имя - ключ, номер - значение)>
        protected Dictionary<string, string> phoneBook = new Dictionary<string, string>();

        /* свойство для соединения с базовой станцией,
        для соединении пользуемся методом Dial,
        свойство заполняется при выполнении метода регистрации телефона базовой станцией,
        автоматически появляется запись в телефонной книге */
        private string DockingStationNumber;

        public string dockingStationNumber
        {
            get
            {
                return DockingStationNumber;
            }
            set
            {
                DockingStationNumber = value;
                phoneBook.Add("Номер базовой станции", DockingStationNumber);
            }
        }

        /* конструктор телефона, должны ввести уникальный IMEI,
        если введем в некорректном формате, то IMEI не присвоится */
        public Phone(params char[] numbers)
        {
            IMEI = "";
            if (numbers.Length == 15)
            {
                for (int i = 0; i <= 14; i++)
                {
                    if (Char.IsDigit(numbers[i]))
                    {
                        IMEI = IMEI + numbers[i];
                    } else
                    {
                        IMEI = "";
                        break;
                    }
                }
            }

            Console.WriteLine("Создан телефон " + IMEI);
            Console.ReadKey();
        }

        public delegate void CallHandler(object sender, CallEventsArgs e);
        public event CallHandler CallEvent;

        public void Call(string callNumber)
        {
            // непосредственно звонок
            Console.WriteLine("Вызов " + callNumber);
            Console.ReadKey();

            // вызов события по звонку
            CallEvent?.Invoke(this, new CallEventsArgs(IMEI, callNumber));
        }

        public void Dial(string name)
        {
            // получаем номер телефона для звонка из телефонной книги
            string callNumber = phoneBook[name];
            Call(callNumber);
        }

        public void Dial(params char[] numbers)
        {
            string callNumber = "";

            for (int i = 0; i <= numbers.Length; i++)
            {
                /* получаем номер телефона для звонка из набора цифр
                (предполагаем что массив символов подготовлен в корректном формате) */
                callNumber = callNumber + numbers[i];
            }
            Call(callNumber);
        }
    }
}
