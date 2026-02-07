using System;
using System.Linq;

namespace Task04Solutions
{
    // Part 02 - Problem 2: Enum Definition
    enum DayOfWeek
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== C# Arrays and Control Structures - Task 04 Solutions ===\n");

            // Uncomment the problem you want to run
            Problem1_ArrayInitialization();
            // Problem2_ShallowVsDeepCopy();
            // Problem3_TwoDimensionalArray();
            // Problem4_ArrayMethods();
            // Problem5_LoopDemonstrations();
            // Problem6_InputValidation();
            // Problem7_MatrixFormat();
            // Problem8_MonthName();
            // Problem9_SortAndSearch();
            // Problem10_SumCalculation();
            // Part2_Problem2_EnumDemo();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // ========== PART 01 - PROBLEM 1 ==========
        static void Problem1_ArrayInitialization()
        {
            Console.WriteLine("\n--- Problem 1: Array Initialization ---\n");

            // Method 1: Using new int[size]
            int[] array1 = new int[5];
            Console.WriteLine("Method 1: new int[size]");
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = (i + 1) * 10;
            }
            Console.Write("Array1: ");
            foreach (int num in array1)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("\n");

            // Method 2: Initializer list
            int[] array2 = new int[] { 2, 4, 6, 8, 10 };
            Console.WriteLine("Method 2: Initializer list");
            Console.Write("Array2: ");
            foreach (int num in array2)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("\n");

            // Method 3: Array syntax sugar
            int[] array3 = { 1, 3, 5, 7, 9 };
            Console.WriteLine("Method 3: Array syntax sugar");
            Console.Write("Array3: ");
            foreach (int num in array3)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("\n");

            // Demonstrate IndexOutOfRangeException
            Console.WriteLine("Demonstrating IndexOutOfRangeException:");
            try
            {
                Console.WriteLine("Attempting to access array3[10]...");
                int value = array3[10]; // This will throw an exception
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }

            Console.WriteLine("\n*** ANSWER: The default value for int arrays is 0 ***");
            int[] defaultArray = new int[3];
            Console.Write("Default values in int array: ");
            foreach (int num in defaultArray)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        // ========== PART 01 - PROBLEM 2 ==========
        static void Problem2_ShallowVsDeepCopy()
        {
            Console.WriteLine("\n--- Problem 2: Shallow vs Deep Copy ---\n");

            // Create original array
            int[] arr1 = { 10, 20, 30, 40, 50 };
            Console.Write("Original arr1: ");
            foreach (int num in arr1) Console.Write(num + " ");
            Console.WriteLine();

            // Shallow copy
            int[] arr2 = arr1;
            Console.WriteLine("\nShallow copy: arr2 = arr1");
            Console.Write("arr2: ");
            foreach (int num in arr2) Console.Write(num + " ");
            Console.WriteLine();

            // Modify arr2
            arr2[0] = 999;
            Console.WriteLine("\nAfter modifying arr2[0] = 999:");
            Console.Write("arr1: ");
            foreach (int num in arr1) Console.Write(num + " ");
            Console.Write("\narr2: ");
            foreach (int num in arr2) Console.Write(num + " ");
            Console.WriteLine("\n*** Both arrays are affected! ***");

            // Deep copy using Clone
            int[] arr3 = { 100, 200, 300, 400, 500 };
            int[] arr4 = (int[])arr3.Clone();
            Console.WriteLine("\n\nDeep copy using Clone(): arr4 = (int[])arr3.Clone()");
            Console.Write("arr3: ");
            foreach (int num in arr3) Console.Write(num + " ");
            Console.Write("\narr4: ");
            foreach (int num in arr4) Console.Write(num + " ");

            // Modify arr4
            arr4[0] = 888;
            Console.WriteLine("\n\nAfter modifying arr4[0] = 888:");
            Console.Write("arr3: ");
            foreach (int num in arr3) Console.Write(num + " ");
            Console.Write("\narr4: ");
            foreach (int num in arr4) Console.Write(num + " ");
            Console.WriteLine("\n*** Only arr4 is affected! ***");

            Console.WriteLine("\n*** ANSWER: Array.Clone() creates a shallow copy and returns object type. ***");
            Console.WriteLine("*** Array.Copy() allows copying to an existing array with more control. ***");
        }

        // ========== PART 01 - PROBLEM 3 ==========
        static void Problem3_TwoDimensionalArray()
        {
            Console.WriteLine("\n--- Problem 3: 2D Array - Student Grades ---\n");

            int[,] grades = new int[3, 3]; // 3 students, 3 subjects

            // Take input from user
            string[] subjects = { "Math", "Science", "English" };
            for (int student = 0; student < 3; student++)
            {
                Console.WriteLine($"\nEnter grades for Student {student + 1}:");
                for (int subject = 0; subject < 3; subject++)
                {
                    Console.Write($"  {subjects[subject]}: ");
                    while (!int.TryParse(Console.ReadLine(), out grades[student, subject]) ||
                           grades[student, subject] < 0 || grades[student, subject] > 100)
                    {
                        Console.Write($"  Invalid input. Enter grade for {subjects[subject]} (0-100): ");
                    }
                }
            }

            // Print grades using nested loops
            Console.WriteLine("\n\n--- Student Grades Report ---");
            Console.WriteLine("Student\t\tMath\tScience\tEnglish");
            Console.WriteLine("-------\t\t----\t-------\t-------");
            for (int student = 0; student < 3; student++)
            {
                Console.Write($"Student {student + 1}\t");
                for (int subject = 0; subject < 3; subject++)
                {
                    Console.Write($"{grades[student, subject]}\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n*** ANSWER: GetLength(dimension) returns length of specific dimension. ***");
            Console.WriteLine($"*** Length returns total elements. For this array: ***");
            Console.WriteLine($"*** GetLength(0) = {grades.GetLength(0)} (students) ***");
            Console.WriteLine($"*** GetLength(1) = {grades.GetLength(1)} (subjects) ***");
            Console.WriteLine($"*** Length = {grades.Length} (total elements) ***");
        }

        // ========== PART 01 - PROBLEM 4 ==========
        static void Problem4_ArrayMethods()
        {
            Console.WriteLine("\n--- Problem 4: Array Methods Demonstration ---\n");

            int[] numbers = { 45, 12, 78, 23, 56, 89, 34, 12 };

            // Original array
            Console.WriteLine("Original Array:");
            PrintArray(numbers);

            // 1. Array.Sort()
            Console.WriteLine("\n1. Array.Sort():");
            int[] sortedArray = (int[])numbers.Clone();
            Array.Sort(sortedArray);
            PrintArray(sortedArray);
            Console.WriteLine("   Changes: Array is sorted in ascending order");

            // 2. Array.Reverse()
            Console.WriteLine("\n2. Array.Reverse():");
            int[] reversedArray = (int[])numbers.Clone();
            Array.Reverse(reversedArray);
            PrintArray(reversedArray);
            Console.WriteLine("   Changes: Array elements are reversed");

            // 3. Array.IndexOf()
            Console.WriteLine("\n3. Array.IndexOf():");
            int searchValue = 12;
            int index = Array.IndexOf(numbers, searchValue);
            Console.WriteLine($"   First occurrence of {searchValue} is at index: {index}");

            // 4. Array.Copy()
            Console.WriteLine("\n4. Array.Copy():");
            int[] copiedArray = new int[5];
            Array.Copy(numbers, copiedArray, 5);
            Console.Write("   Copied first 5 elements: ");
            PrintArray(copiedArray);
            Console.WriteLine("   Changes: First 5 elements copied to new array");

            // 5. Array.Clear()
            Console.WriteLine("\n5. Array.Clear():");
            int[] clearArray = (int[])numbers.Clone();
            Array.Clear(clearArray, 2, 3); // Clear 3 elements starting from index 2
            PrintArray(clearArray);
            Console.WriteLine("   Changes: Elements at indices 2-4 are set to 0");

            Console.WriteLine("\n*** ANSWER: Array.Copy() is general purpose copying. ***");
            Console.WriteLine("*** Array.ConstrainedCopy() is atomic - either all elements copy or none. ***");
            Console.WriteLine("*** ConstrainedCopy() throws exception if copy cannot complete fully. ***");
        }

        static void PrintArray(int[] arr)
        {
            Console.Write("   [ ");
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("]");
        }

        // ========== PART 01 - PROBLEM 5 ==========
        static void Problem5_LoopDemonstrations()
        {
            Console.WriteLine("\n--- Problem 5: Loop Demonstrations ---\n");

            int[] numbers = { 10, 20, 30, 40, 50 };

            // For loop
            Console.WriteLine("Using for loop:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();

            // Foreach loop
            Console.WriteLine("\nUsing foreach loop:");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // While loop (reverse order)
            Console.WriteLine("\nUsing while loop (reverse order):");
            int index = numbers.Length - 1;
            while (index >= 0)
            {
                Console.Write(numbers[index] + " ");
                index--;
            }
            Console.WriteLine();

            Console.WriteLine("\n*** ANSWER: foreach is preferred for read-only operations because: ***");
            Console.WriteLine("*** 1. Cleaner, more readable syntax ***");
            Console.WriteLine("*** 2. No index management needed ***");
            Console.WriteLine("*** 3. Cannot accidentally modify array through index ***");
            Console.WriteLine("*** 4. Less prone to off-by-one errors ***");
        }

        // ========== PART 01 - PROBLEM 6 ==========
        static void Problem6_InputValidation()
        {
            Console.WriteLine("\n--- Problem 6: Input Validation (Positive Odd Number) ---\n");

            int number;
            bool isValid;

            do
            {
                Console.Write("Enter a positive odd number: ");
                string input = Console.ReadLine();

                // Defensive coding with TryParse
                isValid = int.TryParse(input, out number);

                if (!isValid)
                {
                    Console.WriteLine("Invalid input! Please enter a valid integer.");
                }
                else if (number <= 0)
                {
                    Console.WriteLine("Number must be positive!");
                    isValid = false;
                }
                else if (number % 2 == 0)
                {
                    Console.WriteLine("Number must be odd!");
                    isValid = false;
                }

            } while (!isValid);

            Console.WriteLine($"\nValid input received: {number}");

            Console.WriteLine("\n*** ANSWER: Input validation is important to: ***");
            Console.WriteLine("*** 1. Prevent crashes from invalid data ***");
            Console.WriteLine("*** 2. Ensure data integrity ***");
            Console.WriteLine("*** 3. Provide better user experience ***");
            Console.WriteLine("*** 4. Avoid security vulnerabilities ***");
        }

        // ========== PART 01 - PROBLEM 7 ==========
        static void Problem7_MatrixFormat()
        {
            Console.WriteLine("\n--- Problem 7: 2D Array Matrix Format ---\n");

            int[,] matrix = {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 }
            };

            Console.WriteLine("Matrix representation:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],4}"); // Right-aligned with width 4
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n*** ANSWER: Format 2D arrays for better readability by: ***");
            Console.WriteLine("*** 1. Using string formatting with width specifiers (e.g., {0,4}) ***");
            Console.WriteLine("*** 2. Adding borders or separators ***");
            Console.WriteLine("*** 3. Aligning columns properly ***");
            Console.WriteLine("*** 4. Using consistent spacing ***");
        }

        // ========== PART 01 - PROBLEM 8 ==========
        static void Problem8_MonthName()
        {
            Console.WriteLine("\n--- Problem 8: Month Name (if-else vs switch) ---\n");

            Console.Write("Enter a month number (1-12): ");
            int monthNumber;

            while (!int.TryParse(Console.ReadLine(), out monthNumber) ||
                   monthNumber < 1 || monthNumber > 12)
            {
                Console.Write("Invalid input! Enter a number between 1 and 12: ");
            }

            // Using if-else
            Console.WriteLine("\nUsing if-else statement:");
            string monthName = "";
            if (monthNumber == 1) monthName = "January";
            else if (monthNumber == 2) monthName = "February";
            else if (monthNumber == 3) monthName = "March";
            else if (monthNumber == 4) monthName = "April";
            else if (monthNumber == 5) monthName = "May";
            else if (monthNumber == 6) monthName = "June";
            else if (monthNumber == 7) monthName = "July";
            else if (monthNumber == 8) monthName = "August";
            else if (monthNumber == 9) monthName = "September";
            else if (monthNumber == 10) monthName = "October";
            else if (monthNumber == 11) monthName = "November";
            else if (monthNumber == 12) monthName = "December";

            Console.WriteLine($"Month: {monthName}");

            // Using switch
            Console.WriteLine("\nUsing switch statement:");
            string monthNameSwitch = monthNumber switch
            {
                1 => "January",
                2 => "February",
                3 => "March",
                4 => "April",
                5 => "May",
                6 => "June",
                7 => "July",
                8 => "August",
                9 => "September",
                10 => "October",
                11 => "November",
                12 => "December",
                _ => "Invalid"
            };

            Console.WriteLine($"Month: {monthNameSwitch}");

            Console.WriteLine("\n*** ANSWER: Prefer switch over if-else when: ***");
            Console.WriteLine("*** 1. Testing a single variable against multiple constant values ***");
            Console.WriteLine("*** 2. You have 3+ conditions to check ***");
            Console.WriteLine("*** 3. Code readability is important ***");
            Console.WriteLine("*** 4. Performance matters (switch can be optimized better) ***");
        }

        // ========== PART 01 - PROBLEM 9 ==========
        static void Problem9_SortAndSearch()
        {
            Console.WriteLine("\n--- Problem 9: Sort and Search ---\n");

            int[] numbers = { 45, 12, 78, 23, 56, 89, 34, 12, 67 };

            Console.WriteLine("Original Array:");
            PrintArray(numbers);

            // Sort the array
            Array.Sort(numbers);
            Console.WriteLine("\nAfter Array.Sort():");
            PrintArray(numbers);

            // Search using IndexOf
            int searchValue = 12;
            int firstIndex = Array.IndexOf(numbers, searchValue);
            Console.WriteLine($"\nArray.IndexOf({searchValue}): {firstIndex}");

            // Search using LastIndexOf
            int lastIndex = Array.LastIndexOf(numbers, searchValue);
            Console.WriteLine($"Array.LastIndexOf({searchValue}): {lastIndex}");

            Console.WriteLine("\n*** ANSWER: Time complexity of Array.Sort() is O(n log n) ***");
            Console.WriteLine("*** It uses an introspective sort (introsort) algorithm ***");
            Console.WriteLine("*** This combines quicksort, heapsort, and insertion sort ***");
        }

        // ========== PART 01 - PROBLEM 10 ==========
        static void Problem10_SumCalculation()
        {
            Console.WriteLine("\n--- Problem 10: Sum Calculation (for vs foreach) ---\n");

            int[] numbers = { 10, 20, 30, 40, 50 };

            Console.Write("Array: ");
            PrintArray(numbers);

            // Using for loop
            int sumFor = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sumFor += numbers[i];
            }
            Console.WriteLine($"\nSum using for loop: {sumFor}");

            // Using foreach loop
            int sumForeach = 0;
            foreach (int num in numbers)
            {
                sumForeach += num;
            }
            Console.WriteLine($"Sum using foreach loop: {sumForeach}");

            Console.WriteLine("\n*** ANSWER: foreach is generally more efficient for sum calculation because: ***");
            Console.WriteLine("*** 1. No array bounds checking overhead ***");
            Console.WriteLine("*** 2. Direct element access without indexing ***");
            Console.WriteLine("*** 3. Better compiler optimization ***");
            Console.WriteLine("*** 4. Cleaner code with less room for error ***");
            Console.WriteLine("*** However, performance difference is negligible in most cases ***");
        }

        // ========== PART 02 - PROBLEM 2 ==========
        static void Part2_Problem2_EnumDemo()
        {
            Console.WriteLine("\n--- Part 2 Problem 2: Day of Week Enum ---\n");

            Console.Write("Enter a day number (1-7): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int dayNumber))
            {
                try
                {
                    // Using Enum.Parse to convert integer to enum
                    DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayNumber.ToString());

                    // Check if the value is defined in the enum
                    if (Enum.IsDefined(typeof(DayOfWeek), day))
                    {
                        Console.WriteLine($"Day {dayNumber} is: {day}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {dayNumber} is not a valid day number (1-7)");
                        Console.WriteLine("*** ANSWER: Values outside 1-7 are not defined in the enum ***");
                        Console.WriteLine("*** The cast will succeed but Enum.IsDefined() returns false ***");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a number.");
            }

            Console.WriteLine("\n*** Part 2 Problem 3 ANSWER: ***");
            Console.WriteLine("*** If user enters value outside 1-7: ***");
            Console.WriteLine("*** - Direct cast will create an undefined enum value ***");
            Console.WriteLine("*** - Use Enum.IsDefined() to validate ***");
            Console.WriteLine("*** - Or handle with try-catch for Enum.Parse ***");
        }
    }
}
