using System;

class Program
{
    static void Main(string[] args)
    {
        int x1 = 10;
        int y1 = 20;
        int sum = x1 + y1;
        Console.WriteLine(sum);

        int x2 = 10;
        int y2 = 5;
        Console.WriteLine(x2 + y2);

        string fullName = "Ahmed Ali";
        int age = 21;
        double monthlySalary = 5000.50;
        bool isStudent = true;

        int[] numbers = { 1, 2, 3 };
        int[] anotherReference = numbers;

        anotherReference[0] = 100;

        Console.WriteLine(numbers[0]);

        int x = 15;
        int y = 4;

        Console.WriteLine("Sum = " + (x + y));
        Console.WriteLine("Difference = " + (x - y));
        Console.WriteLine("Product = " + (x * y));
        Console.WriteLine("Division = " + (x / y));
        Console.WriteLine("Remainder = " + (x % y));

        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        if (number > 10 && number % 2 == 0)
        {
            Console.WriteLine("The number is greater than 10 and even.");
        }
        else
        {
            Console.WriteLine("Condition not satisfied.");
        }

        Console.Write("Enter a double number: ");
        double d = double.Parse(Console.ReadLine());

        int explicitCast = (int)d;
        double implicitCast = explicitCast;

        Console.WriteLine("Explicit cast to int = " + explicitCast);
        Console.WriteLine("Implicit cast back to double = " + implicitCast);

        Console.Write("Enter your age: ");

        try
        {
            string input = Console.ReadLine();
            int userAge = int.Parse(input);

            if (userAge > 0)
            {
                Console.WriteLine("Valid age");
            }
            else
            {
                Console.WriteLine("Invalid age");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input");
        }

        int value = 5;

        Console.WriteLine("Postfix = " + value++);
        Console.WriteLine("After Postfix = " + value);

        value = 5;

        Console.WriteLine("Prefix = " + ++value);
        Console.WriteLine("After Prefix = " + value);

        int x3 = 5;
        int y3 = ++x3 + x3++;

        Console.WriteLine("x = " + x3);
        Console.WriteLine("y = " + y3);
    }
}
