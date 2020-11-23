using System;

namespace Task3
{
    class TestOverride
    {
        public class Employee
        {
            public string name;

            // Basepay is defined as protected, so that it may be
            // accessed only by this class and derived classes.
            protected decimal basepay;

            // Constructor to set the name and basepay values.
            public Employee(string name, decimal basepay)
            {
                this.name = name;
                this.basepay = basepay;
            }

            // Declared virtual so it can be overridden.
            public virtual decimal CalculatePay()
            {
                return basepay;
            }
        }

        // Derive a new class from Employee.
        public class SalesEmployee : Employee
        {
            // New field that will affect the base pay.
            private decimal salesbonus;

            // The constructor calls the base-class version, and
            // initializes the salesbonus field.
            public SalesEmployee(string name, decimal basepay,
                      decimal salesbonus) : base(name, basepay)
            {
                this.salesbonus = salesbonus;
            }

            // Override the CalculatePay method
            // to take bonus into account.
            public override decimal CalculatePay()
            {
                return basepay + salesbonus;
            }
        }

        // Derive a new class from Employee.
        public class PartTimeEmployee : Employee
        {
            // New field that will affect the base pay.
            private int workingDays;

            // The constructor calls the base-class version, and
            // initializes the salesbonus field.
            public PartTimeEmployee(string name, decimal basepay,
                      int workingDays) : base(name, basepay)
            {
                this.workingDays = workingDays;
            }

            // Override the CalculatePay method
            // to take bonus into account.
            public override decimal CalculatePay()
            {
                return basepay * workingDays / 25;
            }
        }

        static void Main()
        {
            Random rnd = new Random();
            // Create some new employees.
            var employee1 = new SalesEmployee("Alice",
                          1000, 500);
            var employee3 = new PartTimeEmployee("Charlie",
                          1000, 10);
            var employee2 = new Employee("Bob", 1200);

            Console.WriteLine($"Employee1 {employee1.name} earned: {employee1.CalculatePay()}");
            Console.WriteLine($"Employee2 {employee2.name} earned: {employee2.CalculatePay()}");
            Console.WriteLine($"Employee3 {employee2.name} earned: {employee3.CalculatePay()}");

            Employee[] employees = new Employee[10];
            for (int i = 0; i < 10; ++i)
            {
                if (rnd.Next(3) == 0)
                    employees[i] = new PartTimeEmployee("Smith", rnd.Next(2000), rnd.Next(30));
                else
                    employees[i] = new SalesEmployee("Smith", rnd.Next(2000), rnd.Next(1000));
            }
            Array.Sort(employees, (x, y) => (x.CalculatePay()).CompareTo(y.CalculatePay()));
            Array.Reverse(employees);
            for (int i = 0; i < 10; ++i)
                Console.WriteLine($"Employee {employees[i].name} earned: {employees[i].CalculatePay()}");
        }
    }
}
