using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSoap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Data dataBase = new Data();

            List<Subject> fizmat = new List<Subject> { new Subject() { Name = "Английский"},
                new Subject() { Name = "Украинский язык" },
                new Subject() { Name = "Математика"}};
            List<Subject> gum = new List<Subject> { new Subject() { Name = "История Украины"},
                new Subject() { Name = "Украинский язык и литература" },
                new Subject() { Name = "География"}};
            dataBase.AddStud(new Student("Зубенко Михаил", "КЗШ №21", new Location() { Adress = "пр.Мира 10", StudCount = 300 }, fizmat));
            dataBase.AddStud(new Student("Жмышенко Валерий", "КЗШ №22", new Location() { Adress = "пр.Мира 10", StudCount = 300 }, fizmat));
            dataBase.AddStud(new Student("Богдан Богомдан", "КЗШ №23", new Location() { Adress = "пр.Мира 10", StudCount = 300 }, gum));
            dataBase.AddStud(new Student("Сухачёв Гарик", "КЗШ №24", new Location() { Adress = "пр.Мира 10", StudCount = 300 }, gum));
            //dataBase.AddToBinary();
            dataBase.SoapSave();
            /*Console.WriteLine("GET FROM BINARY");
            ZnoDataBase dataBase2 = new ZnoDataBase();
            dataBase2.GetFromBinary();*/

            //dataBase2.Show();

            Console.WriteLine("GET FROM SOAP");
            Data dataBase3 = new Data();
            dataBase3.GetFromSoap();
            dataBase3.Show();
        }
    }
}
