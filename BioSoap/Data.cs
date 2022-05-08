using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioSoap
{
        [Serializable]
        class Location
        {
            public string Adress { get; set; }
            public int StudCount { get; set; }
            public override string ToString()
            {
                return $"Адресс: {Adress} | Вместительность: {StudCount} студ.";
            }

        }
        [Serializable]
        class Subject
        {
            public string Name { get; set; }

            public override string ToString()
            {
                return $"{Name}";
            }
        }
        [Serializable]
        class Student
        {
            string FIO { get; set; }
            string School { get; set; }
            public Subject[] Subjects;
            Location Loc;
            public Student(string fio, string school, Location loc, List<Subject> subjects)
            {
                FIO = fio;
                School = school;
                Loc = loc;
                Subjects = subjects.ToArray();
            }
            public override string ToString()
            {
                string str = "Предметы: ";
                foreach (var item in Subjects)
                    str += item.ToString() + " | ";
                return $"{FIO} | {School} \n{Loc}\n{str}";
            }
        }
        [Serializable]
        class Data
    {
            List<Student> Students;
            public Data()
            {
                Students = new List<Student>();
            }
            public void AddStud(Student s)
            {
                Students.Add(s);
            }
            public void AddToBinary()
            {
                BinaryFormatter binary = new BinaryFormatter();
                using (FileStream fs = new FileStream("stud.bin", FileMode.OpenOrCreate))
                {
                    binary.Serialize(fs, Students);
                }
            }
            public void GetFromBinary()
            {
                BinaryFormatter binary = new BinaryFormatter();
                using (FileStream fs = new FileStream("stud.bin", FileMode.OpenOrCreate))
                {
                    Students = (List<Student>)binary.Deserialize(fs);

                }
            }

            public void SoapSave()
            {
                SoapFormatter formatter = new SoapFormatter();
                using (FileStream fs = new FileStream("save.soap", FileMode.OpenOrCreate))
                {
                    Student[] std = Students.ToArray();

                    formatter.Serialize(fs, std);
                }
            }
            public void GetFromSoap()
            {
                SoapFormatter soap = new SoapFormatter();
                using (FileStream fs = new FileStream("save.soap", FileMode.OpenOrCreate))
                {
                    Student[] std = (Student[])soap.Deserialize(fs);

                    Students = std.ToList();

                }
            }
            public void Show()
            {
                foreach (var item in Students)
                    Console.WriteLine(item + "\n");
            }
        }
}
