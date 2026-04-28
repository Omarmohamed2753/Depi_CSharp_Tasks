using System;
using System.Collections.Generic;

enum Weekdays
{
    Monday = 1,
    Tuesday,
    Wednesday,
    Thursday,
    Friday
}

enum Grades : short
{
    A = 5,
    B = 4,
    C = 3,
    D = 2,
    F = -1
}

enum Gender : byte
{
    Male = 0,
    Female = 1
}

class Department
{
    public string Name { get; set; }

    public Department(string name)
    {
        Name = name;
    }

    public override bool Equals(object obj)
    {
        if (obj is Department other)
            return Name == other.Name;
        return false;
    }

    public override int GetHashCode() => Name.GetHashCode();

    public override string ToString() => Name;
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public virtual Department Department { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Department: {Department?.Name}";
    }
}

class Employee : Person
{
    public int Id { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is Employee other)
            return Id == other.Id && Name == other.Name;
        return false;
    }

    public override int GetHashCode() => Id.GetHashCode();

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Department: {Department?.Name}";
    }
}

class Child : Employee
{
    private decimal _salary;

    public sealed override Department Department
    {
        get => base.Department;
        set => base.Department = value;
    }

    public decimal Salary
    {
        get => _salary;
        set => _salary = value;
    }

    public void DisplaySalary()
    {
        Console.WriteLine($"Employee {Name} has salary: {Salary:C}");
    }
}

static class Utility
{
    public static double RectanglePerimeter(double length, double width)
    {
        return 2 * (length + width);
    }

    public static double CelsiusToFahrenheit(double celsius)
    {
        return celsius * 9.0 / 5.0 + 32;
    }

    public static double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5.0 / 9.0;
    }
}

class ComplexNumber
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }

    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
    {
        double real = a.Real * b.Real - a.Imaginary * b.Imaginary;
        double imaginary = a.Real * b.Imaginary + a.Imaginary * b.Real;
        return new ComplexNumber(real, imaginary);
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}

class Helper
{
    public static T Max<T>(T a, T b) where T : IComparable<T>
    {
        return a.CompareTo(b) >= 0 ? a : b;
    }
}

class Helper2<T>
{
    public static int SearchArray(T[] arr, T target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].Equals(target))
                return i;
        }
        return -1;
    }

    public static void ReplaceArray(T[] arr, T oldValue, T newValue)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].Equals(oldValue))
                arr[i] = newValue;
        }
    }
}

struct Rectangle
{
    public double Length { get; set; }
    public double Width { get; set; }

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public override string ToString() => $"Rectangle(Length={Length}, Width={Width})";
}

struct Circle
{
    public double Radius { get; set; }
    public string Color { get; set; }

    public Circle(double radius, string color)
    {
        Radius = radius;
        Color = color;
    }

    public static bool operator ==(Circle a, Circle b) => a.Radius == b.Radius && a.Color == b.Color;
    public static bool operator !=(Circle a, Circle b) => !(a == b);

    public override bool Equals(object obj)
    {
        if (obj is Circle other)
            return Radius == other.Radius && Color == other.Color;
        return false;
    }

    public override int GetHashCode() => HashCode.Combine(Radius, Color);
}

class CircleClass
{
    public double Radius { get; set; }
    public string Color { get; set; }

    public CircleClass(double radius, string color)
    {
        Radius = radius;
        Color = color;
    }
}

class Program
{
    static void SwapRect(ref Rectangle a, ref Rectangle b)
    {
        Rectangle temp = a;
        a = b;
        b = temp;
    }

    static T[] ReverseArray<T>(T[] arr)
    {
        T[] result = new T[arr.Length];
        for (int i = 0; i < arr.Length; i++)
            result[i] = arr[arr.Length - 1 - i];
        return result;
    }

    static void SwapElements<T>(T[] arr, int i, int j)
    {
        T temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    static T FindMax<T>(T[] arr) where T : IComparable<T>
    {
        T max = arr[0];
        for (int i = 1; i < arr.Length; i++)
            if (arr[i].CompareTo(max) > 0)
                max = arr[i];
        return max;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("=== Weekdays Enum ===");
        foreach (Weekdays day in Enum.GetValues(typeof(Weekdays)))
            Console.WriteLine($"{day} = {(int)day}");

        Console.WriteLine("\n=== Grades Enum (short) ===");
        foreach (Grades g in Enum.GetValues(typeof(Grades)))
            Console.WriteLine($"{g} = {(short)g}");

        Console.WriteLine("\n=== Person with Department ===");
        Person p1 = new Person { Name = "Ahmed", Age = 30, Department = new Department("IT") };
        Person p2 = new Person { Name = "Sara", Age = 25, Department = new Department("HR") };
        Console.WriteLine(p1);
        Console.WriteLine(p2);

        Console.WriteLine("\n=== Child with Sealed Salary ===");
        Child child = new Child { Id = 1, Name = "Ali", Salary = 5000m, Department = new Department("Finance") };
        child.DisplaySalary();

        Console.WriteLine("\n=== Utility Static Methods ===");
        Console.WriteLine($"Perimeter of 5x3 rectangle: {Utility.RectanglePerimeter(5, 3)}");
        Console.WriteLine($"25°C in Fahrenheit: {Utility.CelsiusToFahrenheit(25)}");
        Console.WriteLine($"77°F in Celsius: {Utility.FahrenheitToCelsius(77)}");

        Console.WriteLine("\n=== ComplexNumber Multiplication ===");
        ComplexNumber c1 = new ComplexNumber(2, 3);
        ComplexNumber c2 = new ComplexNumber(1, 4);
        ComplexNumber product = c1 * c2;
        Console.WriteLine($"({c1}) * ({c2}) = ({product})");

        Console.WriteLine("\n=== Gender Enum (byte) ===");
        Console.WriteLine($"Size of byte: {sizeof(byte)} byte vs int: {sizeof(int)} bytes");
        foreach (Gender g in Enum.GetValues(typeof(Gender)))
            Console.WriteLine($"{g} = {(byte)g}");

        Console.WriteLine("\n=== Enum.TryParse ===");
        string input = "A";
        if (Enum.TryParse<Grades>(input, out Grades grade))
            Console.WriteLine($"Parsed: {grade} = {(short)grade}");
        else
            Console.WriteLine("Invalid grade input");

        string badInput = "Z";
        if (!Enum.TryParse<Grades>(badInput, out _))
            Console.WriteLine($"'{badInput}' is not a valid grade.");

        Console.WriteLine("\n=== Employee Equals + SearchArray ===");
        Employee[] employees = {
            new Employee { Id = 1, Name = "Mona", Department = new Department("IT") },
            new Employee { Id = 2, Name = "Khaled", Department = new Department("HR") },
            new Employee { Id = 3, Name = "Nour", Department = new Department("IT") }
        };
        Employee target = new Employee { Id = 2, Name = "Khaled" };
        int idx = Helper2<Employee>.SearchArray(employees, target);
        Console.WriteLine(idx >= 0 ? $"Found at index {idx}: {employees[idx]}" : "Not found");

        Console.WriteLine("\n=== Generic Max Method ===");
        Console.WriteLine($"Max(10, 20) = {Helper.Max(10, 20)}");
        Console.WriteLine($"Max(3.5, 2.1) = {Helper.Max(3.5, 2.1)}");
        Console.WriteLine($"Max(\"apple\", \"banana\") = {Helper.Max("apple", "banana")}");

        Console.WriteLine("\n=== ReplaceArray ===");
        int[] nums = { 1, 2, 3, 2, 4 };
        Helper2<int>.ReplaceArray(nums, 2, 99);
        Console.WriteLine("After replacing 2 with 99: " + string.Join(", ", nums));

        string[] words = { "cat", "dog", "cat" };
        Helper2<string>.ReplaceArray(words, "cat", "bird");
        Console.WriteLine("After replacing 'cat' with 'bird': " + string.Join(", ", words));

        Console.WriteLine("\n=== Rectangle Swap ===");
        Rectangle r1 = new Rectangle(5, 3);
        Rectangle r2 = new Rectangle(10, 7);
        Console.WriteLine($"Before: r1={r1}, r2={r2}");
        SwapRect(ref r1, ref r2);
        Console.WriteLine($"After:  r1={r1}, r2={r2}");

        Console.WriteLine("\n=== Search by Department ===");
        Employee[] emps = {
            new Employee { Id = 1, Name = "Layla", Department = new Department("IT") },
            new Employee { Id = 2, Name = "Omar", Department = new Department("HR") }
        };
        Department searchDept = new Department("IT");
        foreach (var emp in emps)
            if (emp.Department.Equals(searchDept))
                Console.WriteLine($"Found in IT: {emp}");

        Console.WriteLine("\n=== Circle Struct vs Class ===");
        Circle cs1 = new Circle(5.0, "Red");
        Circle cs2 = new Circle(5.0, "Red");
        Console.WriteLine($"Struct == : {cs1 == cs2}");
        Console.WriteLine($"Struct Equals: {cs1.Equals(cs2)}");

        CircleClass cc1 = new CircleClass(5.0, "Red");
        CircleClass cc2 = new CircleClass(5.0, "Red");
        Console.WriteLine($"Class == (reference): {cc1 == cc2}");
        Console.WriteLine($"Class Equals (reference): {cc1.Equals(cc2)}");

        Console.WriteLine("\n=== Reverse Array ===");
        int[] intArr = { 1, 2, 3, 4, 5 };
        int[] reversed = ReverseArray(intArr);
        Console.WriteLine("Reversed: " + string.Join(", ", reversed));

        Console.WriteLine("\n=== Generic Stack ===");
        var stack = new GenericStack<int>();
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        Console.WriteLine($"Peek: {stack.Peek()}");
        Console.WriteLine($"Pop: {stack.Pop()}");
        Console.WriteLine($"Peek after pop: {stack.Peek()}");

        Console.WriteLine("\n=== Swap Elements in Array ===");
        int[] swapArr = { 10, 20, 30, 40 };
        Console.WriteLine("Before: " + string.Join(", ", swapArr));
        SwapElements(swapArr, 1, 3);
        Console.WriteLine("After swapping index 1 and 3: " + string.Join(", ", swapArr));

        Console.WriteLine("\n=== Find Max in Array ===");
        int[] maxArr = { 3, 7, 1, 9, 4 };
        Console.WriteLine($"Max in array: {FindMax(maxArr)}");
        string[] strArr = { "banana", "apple", "cherry" };
        Console.WriteLine($"Max string: {FindMax(strArr)}");
    }
}

class GenericStack<T>
{
    private List<T> items = new List<T>();

    public void Push(T item) => items.Add(item);

    public T Pop()
    {
        if (items.Count == 0) throw new InvalidOperationException("Stack is empty");
        T item = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);
        return item;
    }

    public T Peek()
    {
        if (items.Count == 0) throw new InvalidOperationException("Stack is empty");
        return items[items.Count - 1];
    }

    public bool IsEmpty() => items.Count == 0;
}
