using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task2
{
    [Serializable]
    public class Human
    {
        public string Name { get; set; }

        public Human() { }

        public Human(string name)
        {
            this.Name = name;
        }
    }



    [Serializable]
    public class Professor : Human
    {
        public Professor(string name) : base(name) { }
        public Professor() : base() { }
    }



    [Serializable]
    public class Dept
    {
        public string DeptName { get; set; }

        List<Human> staff;
        public List<Human> Staff { get { return staff; } }

        public Dept() {  }

        public Dept(string name, Human[] staffList)
        {
            this.DeptName = name;
            staff = new List<Human>(staffList);
        }    
    }



    [Serializable]
    public class University
    {
        public string UniversityName { get; set; }
        public List<Dept> Departments { get; set; }
    }

    class Program
    {
        static public void Main(string[] args)
        {
            University university = new University();
            university.UniversityName = "HSE";
            university.Departments = new List<Dept>();
            for (int i = 0; i < 5; ++i)
            {
                List<Human> humans = new List<Human>();
                for (int j = 0; j < 3; ++j)
                    humans.Add(new Human($"Human {i * 5 + j}"));
                humans.Add(new Professor($"Professor {i}"));
                Dept dept = new Dept($"Dept {i}", humans.ToArray());
                university.Departments.Add(dept);
            }

            XmlSerializer formatter = new XmlSerializer(typeof(University), new Type[] { typeof(Professor), typeof(Human), typeof(Dept) });

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("File.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, university);

                Console.WriteLine("Объект сериализован");
            }

            using (FileStream stream = new FileStream("File.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                University universityFromFile = formatter.Deserialize(stream) as University;

                Console.WriteLine("Объект десериализован");
            }
        }
    }
}
