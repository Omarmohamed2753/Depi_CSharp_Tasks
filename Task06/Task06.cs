using System;

namespace StructAndClassTask
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Problem 1 - Point Struct with ToString
            Point p1 = new Point();
            Point p2 = new Point(5, 10);
            Console.WriteLine("Problem 1:");
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());
            Console.WriteLine();
            #endregion

            #region Problem 2 - TypeA Class with Access Modifiers
            TypeA typeA = new TypeA();
            Console.WriteLine("Problem 2:");
            Console.WriteLine($"H (public): {typeA.H}");
            Console.WriteLine($"G (internal): {typeA.G}");
            Console.WriteLine();
            #endregion

            #region Problem 3 - Employee Struct with Encapsulation
            Employee emp = new Employee(101, "John Doe", 50000);
            Console.WriteLine("Problem 3:");
            Console.WriteLine($"Employee Name: {emp.GetName()}");
            emp.SetName("Jane Smith");
            Console.WriteLine($"Updated Name: {emp.GetName()}");
            Console.WriteLine($"Employee ID: {emp.EmpId}");
            Console.WriteLine($"Salary: {emp.Salary}");
            Console.WriteLine();
            #endregion

            #region Problem 4 - Point Struct with Constructor Overloading
            Point p3 = new Point(7);
            Point p4 = new Point(3, 9);
            Console.WriteLine("Problem 4:");
            Console.WriteLine(p3.ToString());
            Console.WriteLine(p4.ToString());
            Console.WriteLine();
            #endregion

            #region Problem 5 - Custom ToString Formatting
            Point p5 = new Point(15, 25);
            Console.WriteLine("Problem 5:");
            Console.WriteLine(p5.ToString());
            Console.WriteLine();
            #endregion

            #region Problem 6 - Value Type vs Reference Type
            Console.WriteLine("Problem 6:");
            Point structPoint = new Point(10, 20);
            EmployeeClass classEmployee = new EmployeeClass { Id = 1, Name = "Alice" };

            Console.WriteLine("Before modification:");
            Console.WriteLine($"Struct Point: {structPoint.ToString()}");
            Console.WriteLine($"Class Employee: {classEmployee.Name}");

            ModifyStruct(structPoint);
            ModifyClass(classEmployee);

            Console.WriteLine("After modification:");
            Console.WriteLine($"Struct Point: {structPoint.ToString()}");
            Console.WriteLine($"Class Employee: {classEmployee.Name}");
            Console.WriteLine();
            #endregion
        }

        static void ModifyStruct(Point p)
        {
            p.X = 100;
            p.Y = 200;
        }

        static void ModifyClass(EmployeeClass emp)
        {
            emp.Name = "Modified";
        }
    }

    #region Point Struct
    struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(int x)
        {
            X = x;
            Y = 0;
        }

        public override string ToString()
        {
            return $"Point coordinates: ({X}, {Y})";
        }
    }
    #endregion

    #region TypeA Class
    class TypeA
    {
        private int F = 10;
        internal int G = 20;
        public int H = 30;

        public int GetF()
        {
            return F;
        }
    }
    #endregion

    #region Employee Struct
    struct Employee
    {
        private int empId;
        private string name;
        private decimal salary;

        public Employee(int id, string empName, decimal empSalary)
        {
            empId = id;
            name = empName;
            salary = empSalary;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string newName)
        {
            name = newName;
        }

        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }

        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }
    }
    #endregion

    #region EmployeeClass
    class EmployeeClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    #endregion
}
