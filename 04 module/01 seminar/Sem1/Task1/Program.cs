using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task1
{
    [Serializable]
    class Student
    {
        public string Name = "Student";

        public int Course = 1;
    }

    [Serializable]
    class Group
    {
        public string Name = "Group";

        public Student[] students = new Student[0];

        public Group()
        {

        }

        public Group(string n, Student[] s)
        {
            Name = n;
            students = s;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Кол-во студентов: ");
            Student[] students = new Student[int.Parse(Console.ReadLine())];
            for (int i = 0; i < students.Length; ++i)
                students[i] = new Student();
            Console.Write("Название группы: ");
            Group group1 = new Group(Console.ReadLine(), students);

            Console.Write("Кол-во студентов: ");
            students = new Student[int.Parse(Console.ReadLine())];
            for (int i = 0; i < students.Length; ++i)
                students[i] = new Student();
            Console.Write("Название группы: ");
            Group group2 = new Group(Console.ReadLine(), students);

            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, group1);
                formatter.Serialize(stream, group2);
            }

            BinaryFormatter formatter1 = new BinaryFormatter();
            Group g1, g2;

            using (Stream stream1 = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                g1 = (Group)formatter1.Deserialize(stream1);
                g2 = (Group)formatter1.Deserialize(stream1);
            }

            Console.WriteLine(g1.Name);
            for (int i = 0; i < g1.students.Length; ++i)
            {
                Console.WriteLine(g1.students[i].Course + " " + g1.students[i].Name);
            }
            Console.WriteLine(g2.Name);
            for (int i = 0; i < g2.students.Length; ++i)
            {
                Console.WriteLine(g2.students[i].Course + " " + g2.students[i].Name);
            }
        }
    }
}
