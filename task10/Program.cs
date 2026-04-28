using System;
using System.Collections.Generic;

class Employee : IComparable<Employee>, ICloneable
{
    public string Name { get; set; }
    public double Salary { get; set; }

    public Employee(string name, double salary)
    {
        Name = name;
        Salary = salary;
    }

    public int CompareTo(Employee other)
    {
        return this.Salary.CompareTo(other.Salary);
    }

    public object Clone()
    {
        return new Employee(this.Name, this.Salary);
    }

    public override string ToString()
    {
        return $"Name: {Name}, Salary: {Salary}";
    }
}

class Manager : Employee, IComparable<Manager>
{
    public string Department { get; set; }

    public Manager(string name, double salary, string department) : base(name, salary)
    {
        Department = department;
    }

    public int CompareTo(Manager other)
    {
        return this.Salary.CompareTo(other.Salary);
    }

    public override string ToString()
    {
        return $"Manager: {Name}, Salary: {Salary}, Dept: {Department}";
    }
}

class SortingAlgorithm<T> where T : IComparable<T>, ICloneable
{
    public void Sort(T[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j].CompareTo(arr[j + 1]) > 0)
                {
                    T temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    public static void Swap<U>(U[] arr, int i, int j)
    {
        U temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}

class SortingTwo<T>
{
    public void Sort(T[] arr, Func<T, T, int> comparer)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (comparer(arr[j], arr[j + 1]) > 0)
                {
                    T temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}

class Program
{
    static T GetDefault<T>()
    {
        return default(T);
    }

    static List<string> ApplyTransform(List<string> list, Func<string, string> transform)
    {
        List<string> result = new List<string>();
        foreach (var s in list)
            result.Add(transform(s));
        return result;
    }

    static int ApplyOperation(int a, int b, Func<int, int, int> op)
    {
        return op(a, b);
    }

    static List<R> TransformList<T, R>(List<T> list, Func<T, R> transform)
    {
        List<R> result = new List<R>();
        foreach (var item in list)
            result.Add(transform(item));
        return result;
    }

    static List<int> ApplyFuncToList(List<int> list, Func<int, int> func)
    {
        List<int> result = new List<int>();
        foreach (var item in list)
            result.Add(func(item));
        return result;
    }

    static void ApplyAction(List<string> list, Action<string> action)
    {
        foreach (var item in list)
            action(item);
    }

    static List<int> FilterEven(List<int> list, Predicate<int> predicate)
    {
        List<int> result = new List<int>();
        foreach (var item in list)
            if (predicate(item))
                result.Add(item);
        return result;
    }

    static List<string> FilterStrings(List<string> list, Func<string, bool> condition)
    {
        List<string> result = new List<string>();
        foreach (var s in list)
            if (condition(s))
                result.Add(s);
        return result;
    }

    static double ApplyMathOp(double a, double b, Func<double, double, double> op)
    {
        return op(a, b);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("=== Problem 1: Sort Employee by Salary (Ascending) ===");
        Employee[] employees = {
            new Employee("Ali", 5000),
            new Employee("Sara", 3000),
            new Employee("Omar", 7000),
            new Employee("Mona", 4500)
        };
        SortingAlgorithm<Employee> sorter = new SortingAlgorithm<Employee>();
        sorter.Sort(employees);
        foreach (var e in employees)
            Console.WriteLine(e);

        Console.WriteLine("\n=== Problem 2: Sort Integers Descending (Lambda) ===");
        int[] nums = { 5, 2, 9, 1, 7 };
        SortingTwo<int> sorter2 = new SortingTwo<int>();
        sorter2.Sort(nums, (a, b) => b.CompareTo(a));
        Console.WriteLine(string.Join(", ", nums));

        Console.WriteLine("\n=== Problem 3: Sort Strings by Length ===");
        string[] words = { "banana", "hi", "apple", "go", "elephant" };
        SortingTwo<string> strSorter = new SortingTwo<string>();
        strSorter.Sort(words, (a, b) => a.Length.CompareTo(b.Length));
        Console.WriteLine(string.Join(", ", words));

        Console.WriteLine("\n=== Problem 4: Sort Manager Objects by Salary ===");
        Manager[] managers = {
            new Manager("Khaled", 9000, "IT"),
            new Manager("Rania", 6000, "HR"),
            new Manager("Tarek", 7500, "Finance")
        };
        SortingTwo<Manager> mgrSorter = new SortingTwo<Manager>();
        mgrSorter.Sort(managers, (a, b) => a.Salary.CompareTo(b.Salary));
        foreach (var m in managers)
            Console.WriteLine(m);

        Console.WriteLine("\n=== Problem 5: Sort Employees by Name Length (Func delegate) ===");
        Employee[] emps2 = {
            new Employee("Ali", 3000),
            new Employee("Mohamed", 5000),
            new Employee("Sara", 4000)
        };
        Func<Employee, Employee, bool> nameCompare = (a, b) => a.Name.Length > b.Name.Length;
        for (int i = 0; i < emps2.Length - 1; i++)
            for (int j = 0; j < emps2.Length - i - 1; j++)
                if (nameCompare(emps2[j], emps2[j + 1]))
                {
                    Employee tmp = emps2[j];
                    emps2[j] = emps2[j + 1];
                    emps2[j + 1] = tmp;
                }
        foreach (var e in emps2)
            Console.WriteLine(e);

        Console.WriteLine("\n=== Problem 6: Anonymous Function vs Lambda for Sorting ===");
        int[] arr6 = { 4, 1, 6, 2, 8 };
        SortingTwo<int> s6 = new SortingTwo<int>();
        s6.Sort(arr6, delegate (int a, int b) { return a.CompareTo(b); });
        Console.Write("Anonymous: ");
        Console.WriteLine(string.Join(", ", arr6));

        int[] arr6b = { 4, 1, 6, 2, 8 };
        s6.Sort(arr6b, (a, b) => a.CompareTo(b));
        Console.Write("Lambda: ");
        Console.WriteLine(string.Join(", ", arr6b));

        Console.WriteLine("\n=== Problem 7: Generic Swap Method ===");
        int[] swapArr = { 10, 20, 30, 40 };
        Console.WriteLine("Before: " + string.Join(", ", swapArr));
        SortingAlgorithm<Employee>.Swap(swapArr, 0, 3);
        Console.WriteLine("After swapping index 0 and 3: " + string.Join(", ", swapArr));

        Console.WriteLine("\n=== Problem 8: Sort Employees by Salary then Name ===");
        Employee[] emps8 = {
            new Employee("Ziad", 5000),
            new Employee("Ali", 5000),
            new Employee("Badr", 3000)
        };
        SortingTwo<Employee> s8 = new SortingTwo<Employee>();
        s8.Sort(emps8, (a, b) =>
        {
            int cmp = a.Salary.CompareTo(b.Salary);
            return cmp != 0 ? cmp : string.Compare(a.Name, b.Name);
        });
        foreach (var e in emps8)
            Console.WriteLine(e);

        Console.WriteLine("\n=== Problem 9: GetDefault for Value and Reference Types ===");
        Console.WriteLine("Default int: " + GetDefault<int>());
        Console.WriteLine("Default double: " + GetDefault<double>());
        Console.WriteLine("Default string: " + (GetDefault<string>() == null ? "null" : GetDefault<string>()));
        Console.WriteLine("Default Employee: " + (GetDefault<Employee>() == null ? "null" : GetDefault<Employee>().ToString()));

        Console.WriteLine("\n=== Problem 10: Clone Employee Array Before Sorting ===");
        Employee[] original = {
            new Employee("Nour", 6000),
            new Employee("Hana", 2000),
            new Employee("Sami", 4000)
        };
        Employee[] cloned = new Employee[original.Length];
        for (int i = 0; i < original.Length; i++)
            cloned[i] = (Employee)original[i].Clone();
        SortingAlgorithm<Employee> s10 = new SortingAlgorithm<Employee>();
        s10.Sort(cloned);
        Console.WriteLine("Original:");
        foreach (var e in original) Console.WriteLine(e);
        Console.WriteLine("Cloned & Sorted:");
        foreach (var e in cloned) Console.WriteLine(e);

        Console.WriteLine("\n=== Problem 11: String Transformations with Delegate ===");
        List<string> strings11 = new List<string> { "hello", "world", "csharp" };
        var upper = ApplyTransform(strings11, s => s.ToUpper());
        Console.WriteLine("Uppercase: " + string.Join(", ", upper));
        var reversed = ApplyTransform(strings11, s =>
        {
            char[] c = s.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        });
        Console.WriteLine("Reversed: " + string.Join(", ", reversed));

        Console.WriteLine("\n=== Problem 12: Math Operations with Delegate ===");
        Console.WriteLine("Add: " + ApplyOperation(10, 5, (a, b) => a + b));
        Console.WriteLine("Sub: " + ApplyOperation(10, 5, (a, b) => a - b));
        Console.WriteLine("Mul: " + ApplyOperation(10, 5, (a, b) => a * b));
        Console.WriteLine("Div: " + ApplyOperation(10, 5, (a, b) => a / b));

        Console.WriteLine("\n=== Problem 13: Generic Delegate Transform List ===");
        List<int> intList = new List<int> { 1, 2, 3, 4, 5 };
        var strList = TransformList<int, string>(intList, n => n.ToString());
        Console.WriteLine("Ints to Strings: " + string.Join(", ", strList));

        Console.WriteLine("\n=== Problem 14: Func<T, TResult> Square ===");
        Func<int, int> square = x => x * x;
        var squared = ApplyFuncToList(intList, square);
        Console.WriteLine("Squares: " + string.Join(", ", squared));

        Console.WriteLine("\n=== Problem 15: Action<T> Print Strings ===");
        List<string> names = new List<string> { "Ahmed", "Lina", "Yusuf" };
        ApplyAction(names, s => Console.WriteLine(">> " + s));

        Console.WriteLine("\n=== Problem 16: Predicate<T> Filter Even Numbers ===");
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Predicate<int> isEven = n => n % 2 == 0;
        var evens = FilterEven(numbers, isEven);
        Console.WriteLine("Even numbers: " + string.Join(", ", evens));

        Console.WriteLine("\n=== Problem 17: Filter Strings with Anonymous Function ===");
        List<string> words17 = new List<string> { "apple", "ant", "banana", "avocado", "cherry" };
        var startsWithA = FilterStrings(words17, delegate (string s) { return s.StartsWith("a"); });
        Console.WriteLine("Starts with 'a': " + string.Join(", ", startsWithA));
        var containsN = FilterStrings(words17, delegate (string s) { return s.Contains("an"); });
        Console.WriteLine("Contains 'an': " + string.Join(", ", containsN));

        Console.WriteLine("\n=== Problem 18: Math with Anonymous Function ===");
        Func<int, int, int> addAnon = delegate (int a, int b) { return a + b; };
        Func<int, int, int> subAnon = delegate (int a, int b) { return a - b; };
        Func<int, int, int> mulAnon = delegate (int a, int b) { return a * b; };
        Console.WriteLine("Add: " + addAnon(8, 3));
        Console.WriteLine("Sub: " + subAnon(8, 3));
        Console.WriteLine("Mul: " + mulAnon(8, 3));

        Console.WriteLine("\n=== Problem 19: Filter Strings with Lambda ===");
        List<string> words19 = new List<string> { "hi", "apple", "bee", "elephant", "go", "cat" };
        var longWords = FilterStrings(words19, s => s.Length > 3);
        Console.WriteLine("Length > 3: " + string.Join(", ", longWords));
        var hasE = FilterStrings(words19, s => s.Contains("e"));
        Console.WriteLine("Contains 'e': " + string.Join(", ", hasE));

        Console.WriteLine("\n=== Problem 20: Math on Doubles with Lambda ===");
        Console.WriteLine("Division: " + ApplyMathOp(10.0, 3.0, (a, b) => a / b));
        Console.WriteLine("Power: " + ApplyMathOp(2.0, 8.0, (a, b) => Math.Pow(a, b)));

        Console.ReadLine();
    }
}
