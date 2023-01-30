using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOpenCafe = true;

            Table[] tables =
            {
                new Table(1,4), //0
                new Table(2,7), //1
                new Table(3,10) //2
            };

                    //true
            while (isOpenCafe)
            {
                Console.WriteLine("Админ-панель");
                for (int i = 0; i < tables.Length; i++)
                {
                    tables[i].ShowInfo();
                }

                #region Допфункции

                Console.Write("\nВведите номер стола:");
                int wishTable = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("\nВведите количество лиц для брони:");
                int getPlaces = Convert.ToInt32(Console.ReadLine());

                bool isReComplete = tables[wishTable].Reserve(getPlaces);

                if (isReComplete) Console.WriteLine("Прошло успешно");
                else Console.WriteLine("Бронь не прошла");
                #endregion

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Table
    {
        private int Number;
        private int MaxPlaces;
        private int FreePlaces;

        public Table(int number, int maxPlaces) { 
            Number = number;
            MaxPlaces = maxPlaces;
            FreePlaces = maxPlaces;
        }

        public void ShowInfo() => Console.WriteLine($"Стол {Number}. Свободно мест {FreePlaces} из {MaxPlaces}.");

        #region Допфункции
        public bool Reserve(int places) {
            if (FreePlaces >= places)
            {
                FreePlaces -= places;
                return true;
            }
            else { 
                return false;
            }
        }

        public bool TakeOffReserve() { 
            return FreePlaces > 0;
        }

        #endregion
    }
}
