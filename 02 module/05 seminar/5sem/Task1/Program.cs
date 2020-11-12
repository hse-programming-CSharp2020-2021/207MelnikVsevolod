using System;

/*
 Реализовать класс, представляющий сведения о человеке Person.
Реализовать свойства: Ф.И.О.(string FullName), дата рождения (DateTime BirthDate),
пол (bool IsMale). Реализовать метод для вывода информации о человеке void ShowInfo().
Реализовать класс, представляющий сведения о студенте Student
(наследуется от Person). Реализовать свойства: название ВУЗа (string Institute),
специальность (string Speciality).
Реализовать класс, представляющий сведения о сотруднике фирмы Employee (наследуется от Person).
Реализовать свойства: название компании (string CompanyName), должность (string Post), график (string Schedule),
оклад (decimal Salary).

В основной программе решить задачи:
- Создать  объекты всех трех типов и вызвать ShowInfo(), чтобы показать всю доступную информацию.
- Создать массив Person[] arr и присвоить его членам объекты всех трех типов. Продемонстрировать работу
метода ShowInfo() на массиве. 

 */
class Person
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsMale { get; set; }
    public Person(string fullname, DateTime bitrhdate, bool ismale)
    {
        FullName = fullname;
        BirthDate = bitrhdate;
        IsMale = ismale;
    }
    public virtual void ShowInfo()
    {
        Console.WriteLine($"{FullName} {BirthDate} {IsMale}");
    }
}

class Student : Person
{
    public string Institute { get; set; }
    public string Speciality { get; set; }
    public Student(string fullname, DateTime bitrhdate, bool ismale, string inst, string spec)
        : base(fullname, bitrhdate, ismale)
    {
        Institute = inst;
        Speciality = spec;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"{FullName} {BirthDate} {IsMale} {Institute} {Speciality}");
    }
}

class Employee : Person
{
    public string CompanyName { get; set; }
    public string Post { get; set; }
    public string Schedule { get; set; }
    public decimal Salary { get; set; }
    public Employee(string fullname, DateTime birthdate, bool ismale, string company_name, string post, string schedule, decimal salary)
        : base(fullname, birthdate, ismale)
    {
        CompanyName = company_name;
        Post = post;
        Schedule = schedule;
        Salary = salary;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"{FullName} {BirthDate} {IsMale} {CompanyName} {Post} {Schedule} {Salary}");
    }
}

class Program
{
    static Random rnd = new Random();

    static string RandomString(int len)
    {
        string str = "";
        for (int i = 0; i < len; ++i)
        {
            str += (char)rnd.Next('a', 'z' + 1);
        }
        return str;
    }

    static void Main()
    {
        Person person = new Person(RandomString(rnd.Next(3, 10)), new DateTime(2020, 10, 10), rnd.Next(2) == 0);
        person.ShowInfo();

        Student student = new Student(RandomString(rnd.Next(3, 10)), new DateTime(2000, 12, 15), rnd.Next(2) == 0,
            RandomString(rnd.Next(3, 10)), RandomString(rnd.Next(3, 10)));
        student.ShowInfo();

        Employee employee = new Employee(RandomString(rnd.Next(3, 10)), new DateTime(2020, 10, 10), rnd.Next(2) == 0,
            RandomString(rnd.Next(3, 10)), RandomString(rnd.Next(3, 10)), RandomString(rnd.Next(3, 10)), rnd.Next(500000));
        employee.ShowInfo();

        Console.WriteLine("Элементы массива:");
        Person[] arr = new Person[3] { person, student, employee};
        for (int i = 0; i < 3; ++i)
            arr[i].ShowInfo();
    }
}
