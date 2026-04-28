using System;
using System.Collections.Generic;

namespace Task7
{
    #region Problem 1 - Car Class with Multiple Constructors

    class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }

        public Car()
        {
            Id = 0;
            Brand = "Unknown";
            Price = 0;
        }

        public Car(int id)
        {
            Id = id;
            Brand = "Unknown";
            Price = 0;
        }

        public Car(int id, string brand)
        {
            Id = id;
            Brand = brand;
            Price = 0;
        }

        public Car(int id, string brand, double price)
        {
            Id = id;
            Brand = brand;
            Price = price;
        }
    }

    #endregion

    #region Problem 2 - Calculator with Overloaded Sum Methods

    class Calculator
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }

        public int Sum(int a, int b, int c)
        {
            return a + b + c;
        }

        public double Sum(double a, double b)
        {
            return a + b;
        }
    }

    #endregion

    #region Problem 3, 4, 5 - Parent and Child Classes

    class Parent
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Parent(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual int Product()
        {
            return X * Y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    class ChildWithNew : Parent
    {
        public int Z { get; set; }

        public ChildWithNew(int x, int y, int z) : base(x, y)
        {
            Z = z;
        }

        public new int Product()
        {
            return X * Y * Z;
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }

    class ChildWithOverride : Parent
    {
        public int Z { get; set; }

        public ChildWithOverride(int x, int y, int z) : base(x, y)
        {
            Z = z;
        }

        public override int Product()
        {
            return X * Y * Z;
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }

    #endregion

    #region Problem 6 - IShape Interface with Rectangle

    interface IShape
    {
        double Area { get; }
        void Draw();
    }

    class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Area => Width * Height;

        public void Draw()
        {
            Console.WriteLine($"Drawing Rectangle {Width} x {Height}");
        }
    }

    #endregion

    #region Problem 7 - Default Interface Method (C# 8.0)

    interface IShapeWithDefault
    {
        double Area { get; }
        void Draw();

        void PrintDetails()
        {
            Console.WriteLine($"Shape Area: {Area}");
        }
    }

    class Circle : IShapeWithDefault
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Area => Math.PI * Radius * Radius;

        public void Draw()
        {
            Console.WriteLine($"Drawing Circle with radius {Radius}");
        }
    }

    #endregion

    #region Problem 8 - IMovable Interface with Car

    interface IMovable
    {
        void Move();
    }

    class MovableCar : IMovable
    {
        public string Brand { get; set; }

        public MovableCar(string brand)
        {
            Brand = brand;
        }

        public void Move()
        {
            Console.WriteLine($"{Brand} is moving.");
        }
    }

    #endregion

    #region Problem 9 - Multiple Interface Implementation

    interface IReadable
    {
        void Read();
    }

    interface IWritable
    {
        void Write();
    }

    class FileHandler : IReadable, IWritable
    {
        public string Name { get; set; }

        public FileHandler(string name)
        {
            Name = name;
        }

        public void Read()
        {
            Console.WriteLine($"Reading from {Name}");
        }

        public void Write()
        {
            Console.WriteLine($"Writing to {Name}");
        }
    }

    #endregion

    #region Problem 10 - Abstract Class Shape with Rectangle

    abstract class Shape
    {
        public virtual void Draw()
        {
            Console.WriteLine("Drawing Shape");
        }

        public abstract double CalculateArea();
    }

    class ColoredRectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public ColoredRectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override void Draw()
        {
            Console.WriteLine($"Drawing Rectangle {Width} x {Height}");
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            #region Problem 1 Demo

            Console.WriteLine("=== Problem 1: Car Constructors ===");
            Car car1 = new Car();
            Car car2 = new Car(1);
            Car car3 = new Car(2, "Toyota");
            Car car4 = new Car(3, "BMW", 50000);
            Console.WriteLine($"Car1: Id={car1.Id}, Brand={car1.Brand}, Price={car1.Price}");
            Console.WriteLine($"Car2: Id={car2.Id}, Brand={car2.Brand}, Price={car2.Price}");
            Console.WriteLine($"Car3: Id={car3.Id}, Brand={car3.Brand}, Price={car3.Price}");
            Console.WriteLine($"Car4: Id={car4.Id}, Brand={car4.Brand}, Price={car4.Price}");

            #endregion

            #region Problem 2 Demo

            Console.WriteLine("\n=== Problem 2: Calculator Overloaded Sum ===");
            Calculator calc = new Calculator();
            Console.WriteLine($"Sum(3, 4) = {calc.Sum(3, 4)}");
            Console.WriteLine($"Sum(1, 2, 3) = {calc.Sum(1, 2, 3)}");
            Console.WriteLine($"Sum(2.5, 3.7) = {calc.Sum(2.5, 3.7)}");

            #endregion

            #region Problem 3 Demo

            Console.WriteLine("\n=== Problem 3: Constructor Chaining ===");
            ChildWithOverride child = new ChildWithOverride(1, 2, 3);
            Console.WriteLine($"Child: X={child.X}, Y={child.Y}, Z={child.Z}");

            #endregion

            #region Problem 4 Demo

            Console.WriteLine("\n=== Problem 4: new vs override ===");
            Parent p1 = new ChildWithNew(2, 3, 4);
            Console.WriteLine($"new keyword via Parent ref - Product: {p1.Product()}");

            Parent p2 = new ChildWithOverride(2, 3, 4);
            Console.WriteLine($"override keyword via Parent ref - Product: {p2.Product()}");

            ChildWithNew c1 = new ChildWithNew(2, 3, 4);
            Console.WriteLine($"new keyword via Child ref - Product: {c1.Product()}");

            #endregion

            #region Problem 5 Demo

            Console.WriteLine("\n=== Problem 5: ToString Polymorphism ===");
            Parent parent = new Parent(1, 2);
            Parent childAsParent = new ChildWithOverride(1, 2, 3);
            Console.WriteLine($"Parent: {parent}");
            Console.WriteLine($"Child via Parent ref: {childAsParent}");

            #endregion

            #region Problem 6 Demo

            Console.WriteLine("\n=== Problem 6: IShape with Rectangle ===");
            IShape shape = new Rectangle(5, 3);
            shape.Draw();
            Console.WriteLine($"Area: {shape.Area}");

            #endregion

            #region Problem 7 Demo

            Console.WriteLine("\n=== Problem 7: Default Interface Method ===");
            IShapeWithDefault circle = new Circle(4);
            circle.Draw();
            circle.PrintDetails();

            #endregion

            #region Problem 8 Demo

            Console.WriteLine("\n=== Problem 8: IMovable with Car ===");
            IMovable movable = new MovableCar("Tesla");
            movable.Move();

            #endregion

            #region Problem 9 Demo

            Console.WriteLine("\n=== Problem 9: Multiple Interfaces ===");
            FileHandler file = new FileHandler("data.txt");
            file.Read();
            file.Write();

            #endregion

            #region Problem 10 Demo

            Console.WriteLine("\n=== Problem 10: Abstract Class Shape ===");
            Shape rect = new ColoredRectangle(6, 4);
            rect.Draw();
            Console.WriteLine($"Area: {rect.CalculateArea()}");

            #endregion

            Console.ReadKey();
        }
    }
}
