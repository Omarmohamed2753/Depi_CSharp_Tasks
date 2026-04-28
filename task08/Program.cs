using System;
using System.Collections.Generic;

interface IVehicle
{
    void StartEngine();
    void StopEngine();
}

class Car : IVehicle
{
    public void StartEngine() => Console.WriteLine("Car engine started.");
    public void StopEngine() => Console.WriteLine("Car engine stopped.");
}

class Bike : IVehicle
{
    public void StartEngine() => Console.WriteLine("Bike engine started.");
    public void StopEngine() => Console.WriteLine("Bike engine stopped.");
}

abstract class Shape
{
    public abstract double GetArea();
    public void Display() => Console.WriteLine("Area: " + GetArea());
}

class Rectangle : Shape
{
    double width, height;
    public Rectangle(double w, double h) { width = w; height = h; }
    public override double GetArea() => width * height;
}

class Circle : Shape
{
    double radius;
    public Circle(double r) { radius = r; }
    public override double GetArea() => Math.PI * radius * radius;
}

class Product : IComparable<Product>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(int id, string name, double price)
    {
        Id = id; Name = name; Price = price;
    }

    public int CompareTo(Product other) => Price.CompareTo(other.Price);

    public override string ToString() => $"[{Id}] {Name} - ${Price}";
}

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Grade { get; set; }

    public Student(int id, string name, double grade)
    {
        Id = id; Name = name; Grade = grade;
    }

    public Student(Student other)
    {
        Id = other.Id;
        Name = string.Copy(other.Name);
        Grade = other.Grade;
    }

    public override string ToString() => $"Id={Id}, Name={Name}, Grade={Grade}";
}

interface IWalkable
{
    void Walk();
}

class Robot : IWalkable
{
    public void Walk() => Console.WriteLine("Robot walking normally.");

    void IWalkable.Walk() => Console.WriteLine("Robot walking via IWalkable explicitly.");
}

struct Account
{
    private int accountId;
    private string accountHolder;
    private double balance;

    public int AccountId { get => accountId; set => accountId = value; }
    public string AccountHolder { get => accountHolder; set => accountHolder = value; }
    public double Balance { get => balance; set => balance = value; }

    public Account(int id, string holder, double bal)
    {
        accountId = id; accountHolder = holder; balance = bal;
    }

    public override string ToString() => $"Account[{accountId}] {accountHolder} Balance={balance}";
}

interface ILogger
{
    void Log(string message)
    {
        Console.WriteLine("Default Log: " + message);
    }
}

class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine("ConsoleLogger: " + message);
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public Book() { Title = "Unknown"; Author = "Unknown"; }
    public Book(string title) { Title = title; Author = "Unknown"; }
    public Book(string title, string author) { Title = title; Author = author; }

    public override string ToString() => $"\"{Title}\" by {Author}";
}

interface IShapeSeries
{
    int CurrentShapeArea { get; set; }
    void GetNextArea();
    void ResetSeries();
}

class SquareSeries : IShapeSeries
{
    int side = 0;
    public int CurrentShapeArea { get; set; }

    public void GetNextArea()
    {
        side++;
        CurrentShapeArea = side * side;
    }

    public void ResetSeries() { side = 0; CurrentShapeArea = 0; }
}

class CircleSeries : IShapeSeries
{
    int radius = 0;
    public int CurrentShapeArea { get; set; }

    public void GetNextArea()
    {
        radius++;
        CurrentShapeArea = (int)(Math.PI * radius * radius);
    }

    public void ResetSeries() { radius = 0; CurrentShapeArea = 0; }
}

class ShapeItem : IComparable<ShapeItem>
{
    public string Name { get; set; }
    public double Area { get; set; }

    public ShapeItem(string name, double area) { Name = name; Area = area; }
    public int CompareTo(ShapeItem other) => Area.CompareTo(other.Area);
    public override string ToString() => $"{Name}: Area={Area:F2}";
}

abstract class GeometricShape
{
    public double Dimension1 { get; set; }
    public double Dimension2 { get; set; }
    public abstract double CalculateArea();
    public abstract double Perimeter { get; }
}

class Triangle : GeometricShape
{
    public Triangle(double d1, double d2) { Dimension1 = d1; Dimension2 = d2; }
    public override double CalculateArea() => 0.5 * Dimension1 * Dimension2;
    public override double Perimeter => Dimension1 + Dimension2 + Math.Sqrt(Dimension1 * Dimension1 + Dimension2 * Dimension2);
    public override string ToString() => $"Triangle: Area={CalculateArea():F2}, Perimeter={Perimeter:F2}";
}

class Rect : GeometricShape
{
    public Rect(double d1, double d2) { Dimension1 = d1; Dimension2 = d2; }
    public override double CalculateArea() => Dimension1 * Dimension2;
    public override double Perimeter => 2 * (Dimension1 + Dimension2);
    public override string ToString() => $"Rectangle: Area={CalculateArea():F2}, Perimeter={Perimeter:F2}";
}

class ShapeFactory
{
    public static GeometricShape CreateShape(string shapeType, double dim1, double dim2)
    {
        if (shapeType.ToLower() == "triangle") return new Triangle(dim1, dim2);
        if (shapeType.ToLower() == "rectangle") return new Rect(dim1, dim2);
        throw new ArgumentException("Unknown shape: " + shapeType);
    }
}

class Program
{
    static void PrintTenShapes(IShapeSeries series)
    {
        series.ResetSeries();
        for (int i = 0; i < 10; i++)
        {
            series.GetNextArea();
            Console.WriteLine("  Area: " + series.CurrentShapeArea);
        }
    }

    static void SelectionSort(int[] numbers)
    {
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int minIdx = i;
            for (int j = i + 1; j < numbers.Length; j++)
                if (numbers[j] < numbers[minIdx]) minIdx = j;
            int tmp = numbers[minIdx];
            numbers[minIdx] = numbers[i];
            numbers[i] = tmp;
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("=== IVehicle Demo ===");
        IVehicle car = new Car();
        IVehicle bike = new Bike();
        car.StartEngine(); car.StopEngine();
        bike.StartEngine(); bike.StopEngine();

        Console.WriteLine("\n=== Abstract Shape Demo ===");
        Shape rect = new Rectangle(4, 5);
        Shape circ = new Circle(3);
        rect.Display();
        circ.Display();

        Console.WriteLine("\n=== IComparable Product Sort ===");
        Product[] products = {
            new Product(1, "Laptop", 999.99),
            new Product(2, "Mouse", 29.99),
            new Product(3, "Keyboard", 59.99)
        };
        Array.Sort(products);
        foreach (var p in products) Console.WriteLine(p);

        Console.WriteLine("\n=== Deep vs Shallow Copy (Student) ===");
        Student s1 = new Student(1, "Alice", 90);
        Student s2 = new Student(s1);
        s2.Name = "Bob";
        s2.Grade = 85;
        Console.WriteLine("Original: " + s1);
        Console.WriteLine("Deep Copy: " + s2);

        Console.WriteLine("\n=== Explicit Interface (Robot) ===");
        Robot robot = new Robot();
        robot.Walk();
        ((IWalkable)robot).Walk();

        Console.WriteLine("\n=== Struct Encapsulation (Account) ===");
        Account acc = new Account(101, "John", 5000.0);
        Console.WriteLine(acc);

        Console.WriteLine("\n=== ILogger with Default Implementation ===");
        ILogger defaultLogger = new ConsoleLogger();
        defaultLogger.Log("Hello from logger");

        Console.WriteLine("\n=== Constructor Overloading (Book) ===");
        Book b1 = new Book();
        Book b2 = new Book("C# in Depth");
        Book b3 = new Book("Clean Code", "Robert Martin");
        Console.WriteLine(b1); Console.WriteLine(b2); Console.WriteLine(b3);

        Console.WriteLine("\n=== Shape Series - Square ===");
        PrintTenShapes(new SquareSeries());

        Console.WriteLine("\n=== Shape Series - Circle ===");
        PrintTenShapes(new CircleSeries());

        Console.WriteLine("\n=== Shape Sort by Area ===");
        ShapeItem[] shapes = {
            new ShapeItem("Circle", Math.PI * 4 * 4),
            new ShapeItem("Square", 3 * 3),
            new ShapeItem("Rectangle", 5 * 7)
        };
        Array.Sort(shapes);
        foreach (var s in shapes) Console.WriteLine(s);

        Console.WriteLine("\n=== Geometric Shapes ===");
        GeometricShape t = new Triangle(6, 4);
        GeometricShape r = new Rect(5, 3);
        Console.WriteLine(t);
        Console.WriteLine(r);

        Console.WriteLine("\n=== Selection Sort ===");
        int[] areas = { 50, 12, 35, 28, 9 };
        SelectionSort(areas);
        Console.WriteLine("Sorted: " + string.Join(", ", areas));

        Console.WriteLine("\n=== Factory Pattern ===");
        GeometricShape fs1 = ShapeFactory.CreateShape("rectangle", 6, 4);
        GeometricShape fs2 = ShapeFactory.CreateShape("triangle", 3, 5);
        Console.WriteLine(fs1);
        Console.WriteLine(fs2);
    }
}
