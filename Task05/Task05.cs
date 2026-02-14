
namespace task05
{
    public class Program
    {
            static void Main(string[] args)
            {
                Console.WriteLine("=== Task 5 Solutions ===\n");

                // Uncomment the region you want to test

            //DivisionWithExceptionHandling();
            //DefensiveCode();
            //NullableTypes();
            //ArrayIndexOutOfBounds();
            //MultiDimensionalArray();
            //JaggedArray();
            //NullableReferenceTypes();
            //BoxingUnboxing();
            //OutParameters();
            //OptionalParameters();
            //NullPropagation();
            //SwitchExpression();
            //ParamsKeyword();

            //PrintNumbersInRange();
            //MultiplicationTable();
            //EvenNumbers();
            //Exponentiation();
            //ReverseString();
            //ReverseInteger();
            //LongestDistance();
            //ReverseWords();

            Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }

            #region Part01 - Problem 1: Division with Exception Handling
            static void DivisionWithExceptionHandling()
            {
                Console.WriteLine("=== Problem 1: Division with Exception Handling ===");

                try
                {
                    Console.Write("Enter first integer: ");
                    int num1 = int.Parse(Console.ReadLine());

                    Console.Write("Enter second integer: ");
                    int num2 = int.Parse(Console.ReadLine());

                    int result = num1 / num2;
                    Console.WriteLine($"Result: {num1} / {num2} = {result}");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Error: Cannot divide by zero!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter valid integers!");
                }
                finally
                {
                    Console.WriteLine("Operation complete");
                }

                Console.WriteLine();
            }
            #endregion

            #region Part01 - Problem 2: Defensive Code with Validation
           
            static void DefensiveCode()
            {
                Console.WriteLine("=== Problem 2: Defensive Code with Validation ===");
                TestDefensiveCode();
                Console.WriteLine();
            }

            static void TestDefensiveCode()
            {
                int x, y;

                // Validate X (must be positive)
                do
                {
                    Console.Write("Enter X (positive integer): ");
                    string inputX = Console.ReadLine();

                    if (!int.TryParse(inputX, out x) || x <= 0)
                    {
                        Console.WriteLine("Invalid input! X must be a positive integer.");
                        x = 0; // Reset to continue loop
                    }
                } while (x <= 0);

                // Validate Y (must be greater than 1)
                do
                {
                    Console.Write("Enter Y (integer greater than 1): ");
                    string inputY = Console.ReadLine();

                    if (!int.TryParse(inputY, out y) || y <= 1)
                    {
                        Console.WriteLine("Invalid input! Y must be greater than 1.");
                        y = 0; // Reset to continue loop
                    }
                } while (y <= 1);

                Console.WriteLine($"Valid inputs received: X = {x}, Y = {y}");
                Console.WriteLine($"Result of X / Y = {x / y}");
            }
            #endregion

            #region Part01 - Problem 3: Nullable Types
            
            static void NullableTypes()
            {
                Console.WriteLine("=== Problem 3: Nullable Types ===");

                int? nullableInt = null;

                Console.WriteLine($"Nullable integer is null: {!nullableInt.HasValue}");

                int defaultValue = nullableInt ?? 100;
                Console.WriteLine($"Using ?? operator - Value: {defaultValue}");

                Console.WriteLine($"\nHasValue: {nullableInt.HasValue}");

                if (nullableInt.HasValue)
                {
                    Console.WriteLine($"Value: {nullableInt.Value}");
                }
                else
                {
                    Console.WriteLine("Cannot access Value because nullableInt is null");
                }

                nullableInt = 42;
                Console.WriteLine($"\nAfter assignment:");
                Console.WriteLine($"HasValue: {nullableInt.HasValue}");
                Console.WriteLine($"Value: {nullableInt.Value}");

                Console.WriteLine();
            }
            #endregion

            #region Part01 - Problem 4: Array Index Out of Bounds
            static void ArrayIndexOutOfBounds()
            {
                Console.WriteLine("=== Problem 4: Array Index Out of Bounds ===");

                int[] numbers = new int[5] { 10, 20, 30, 40, 50 };

                Console.WriteLine("Array contents:");
                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.WriteLine($"Index {i}: {numbers[i]}");
                }

                Console.Write("\nEnter an index to access: ");

                try
                {
                    int index = int.Parse(Console.ReadLine());

                    if (index >= 0 && index < numbers.Length)
                    {
                        Console.WriteLine($"Value at index {index}: {numbers[index]}");
                    }
                    else
                    {
                        Console.WriteLine($"Index {index} is out of bounds! Valid range: 0 to {numbers.Length - 1}");
                    }

                    Console.WriteLine("\nAttempting to access index 10 (out of bounds):");
                    int value = numbers[10];
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Exception caught: {ex.Message}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input format!");
                }

                Console.WriteLine();
            }
            #endregion

            #region Part01 - Problem 5: Multi-Dimensional Array
            static void MultiDimensionalArray()
            {
                Console.WriteLine("=== Problem 5: Multi-Dimensional Array ===");

                int[,] matrix = new int[3, 3];

                Console.WriteLine("Enter values for a 3x3 matrix:");
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write($"Enter value for position [{i},{j}]: ");
                        matrix[i, j] = int.Parse(Console.ReadLine());
                    }
                }

                Console.WriteLine("\nMatrix:");
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write($"{matrix[i, j],5}");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("\nRow sums:");
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    int rowSum = 0;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        rowSum += matrix[i, j];
                    }
                    Console.WriteLine($"Row {i}: {rowSum}");
                }

                Console.WriteLine("\nColumn sums:");
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int colSum = 0;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        colSum += matrix[i, j];
                    }
                    Console.WriteLine($"Column {j}: {colSum}");
                }

                Console.WriteLine();
            }
            #endregion

            #region Part01 - Problem 6: Jagged Array
            
            static void JaggedArray()
            {
                Console.WriteLine("=== Problem 6: Jagged Array ===");

                // Create jagged array with 3 rows
                int[][] jaggedArray = new int[3][];

                // Define sizes for each row
                Console.Write("Enter size for row 0: ");
                int size0 = int.Parse(Console.ReadLine());
                jaggedArray[0] = new int[size0];

                Console.Write("Enter size for row 1: ");
                int size1 = int.Parse(Console.ReadLine());
                jaggedArray[1] = new int[size1];

                Console.Write("Enter size for row 2: ");
                int size2 = int.Parse(Console.ReadLine());
                jaggedArray[2] = new int[size2];

                // Populate each row with user input
                for (int i = 0; i < jaggedArray.Length; i++)
                {
                    Console.WriteLine($"\nEnter {jaggedArray[i].Length} values for row {i}:");
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        Console.Write($"  Value {j}: ");
                        jaggedArray[i][j] = int.Parse(Console.ReadLine());
                    }
                }

                // Print all values row by row
                Console.WriteLine("\nJagged Array Contents:");
                for (int i = 0; i < jaggedArray.Length; i++)
                {
                    Console.Write($"Row {i}: ");
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        Console.Write($"{jaggedArray[i][j]} ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
            #endregion

            #region Part01 - Problem 7: Nullable Reference Types
            
            static void NullableReferenceTypes()
            {
                Console.WriteLine("=== Problem 7: Nullable Reference Types ===");

                string? nullableString = null;

                Console.Write("Do you want to assign a value? (yes/no): ");
                string? response = Console.ReadLine();

                if (response?.ToLower() == "yes")
                {
                    Console.Write("Enter a string value: ");
                    nullableString = Console.ReadLine();
                }

                // Using null-forgiveness operator (!)
                // This tells compiler we know it's not null
                if (nullableString != null)
                {
                    Console.WriteLine($"String length using !: {nullableString!.Length}");
                    Console.WriteLine($"String value: {nullableString}");
                }
                else
                {
                    Console.WriteLine("String is null");
                }

                // Safe navigation
                Console.WriteLine($"String length using ?.: {nullableString?.Length ?? 0}");

                Console.WriteLine();
            }
            #endregion

            #region Part01 - Problem 8: Boxing and Unboxing
            
            static void BoxingUnboxing()
            {
                Console.WriteLine("=== Problem 8: Boxing and Unboxing ===");

                // Boxing: Converting value type to reference type (object)
                int valueType = 123;
                object boxedValue = valueType; // Boxing occurs here
                Console.WriteLine($"Original value type: {valueType}");
                Console.WriteLine($"Boxed value: {boxedValue}");
                Console.WriteLine($"Boxed value type: {boxedValue.GetType()}");

                // Unboxing: Converting reference type back to value type
                try
                {
                    int unboxedValue = (int)boxedValue; // Unboxing occurs here
                    Console.WriteLine($"Unboxed value: {unboxedValue}");

                    // Demonstrating invalid cast exception
                    Console.WriteLine("\nAttempting invalid unboxing (object to long):");
                    long invalidUnbox = (long)boxedValue; // This will throw InvalidCastException
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine($"Exception caught: {ex.Message}");
                    Console.WriteLine("Cannot unbox to a different type!");
                }

                // Correct way to convert to different type
                long correctConversion = Convert.ToInt64(boxedValue);
                Console.WriteLine($"Correct conversion to long: {correctConversion}");

                Console.WriteLine();
            }
            #endregion

            #region Part01 - Problem 9: Out Parameters
            
            static void OutParameters()
            {
                Console.WriteLine("=== Problem 9: Out Parameters ===");

                Console.Write("Enter first integer: ");
                int num1 = int.Parse(Console.ReadLine());

                Console.Write("Enter second integer: ");
                int num2 = int.Parse(Console.ReadLine());

                // Call method with out parameters
                SumAndMultiply(num1, num2, out int sum, out int product);

                Console.WriteLine($"\nResults:");
                Console.WriteLine($"Sum: {sum}");
                Console.WriteLine($"Product: {product}");

                Console.WriteLine();
            }

            static void SumAndMultiply(int a, int b, out int sum, out int product)
            {
                sum = a + b;         // Must be initialized
                product = a * b;     // Must be initialized
            }
            #endregion

            #region Part01 - Problem 10: Optional Parameters
            
            static void OptionalParameters()
            {
                Console.WriteLine("=== Problem 10: Optional Parameters ===");

                Console.Write("Enter a string to print: ");
                string text = Console.ReadLine();

                // Call with default parameter
                Console.WriteLine("\nUsing default count (5):");
                PrintMultipleTimes(text);

                // Call with specified count
                Console.WriteLine("\nWith count = 3:");
                PrintMultipleTimes(text, 3);

                // Call with named parameters
                Console.WriteLine("\nUsing named parameters:");
                PrintMultipleTimes(count: 2, text: text);

                Console.WriteLine();
            }

            static void PrintMultipleTimes(string text, int count = 5)
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"{i + 1}. {text}");
                }
            }
            #endregion

            #region Part01 - Problem 11: Null Propagation Operator
            
            static void NullPropagation()
            {
                Console.WriteLine("=== Problem 11: Null Propagation Operator ===");

                int[]? nullableArray = null;

                // Using null propagation operator
                Console.WriteLine("When array is null:");
                Console.WriteLine($"Array length: {nullableArray?.Length ?? -1}");
                Console.WriteLine($"First element: {nullableArray?[0] ?? -1}");

                // Assign array
                nullableArray = new int[] { 10, 20, 30, 40, 50 };

                Console.WriteLine("\nWhen array is initialized:");
                Console.WriteLine($"Array length: {nullableArray?.Length ?? -1}");
                Console.WriteLine($"First element: {nullableArray?[0] ?? -1}");

                // Demonstrating chained null propagation
                string? result = nullableArray?.Length.ToString()?.ToUpper();
                Console.WriteLine($"Chained null propagation result: {result}");

                // Without null propagation (would throw exception if null)
                nullableArray = null;
                try
                {
                    // int length = nullableArray.Length; // Would throw NullReferenceException
                    int length = nullableArray?.Length ?? 0; // Safe
                    Console.WriteLine($"\nSafe access with null array: {length}");
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }

                Console.WriteLine();
            }
            #endregion

            #region Part01 - Problem 12: Switch Expression
            
            static void SwitchExpression()
            {
                Console.WriteLine("=== Problem 12: Switch Expression ===");

                Console.Write("Enter a day of the week: ");
                string day = Console.ReadLine()?.Trim() ?? "";

                // Using switch expression (C# 8.0+)
                int dayNumber = day.ToLower() switch
                {
                    "monday" => 1,
                    "tuesday" => 2,
                    "wednesday" => 3,
                    "thursday" => 4,
                    "friday" => 5,
                    "saturday" => 6,
                    "sunday" => 7,
                    _ => 0 // Default case
                };

                if (dayNumber > 0)
                {
                    Console.WriteLine($"{day} is day number {dayNumber} of the week");
                }
                else
                {
                    Console.WriteLine("Invalid day name!");
                }

                // Demonstrating traditional switch statement for comparison
                Console.WriteLine("\nUsing traditional switch statement:");
                int dayNum2;
                switch (day.ToLower())
                {
                    case "monday":
                        dayNum2 = 1;
                        break;
                    case "tuesday":
                        dayNum2 = 2;
                        break;
                    case "wednesday":
                        dayNum2 = 3;
                        break;
                    case "thursday":
                        dayNum2 = 4;
                        break;
                    case "friday":
                        dayNum2 = 5;
                        break;
                    case "saturday":
                        dayNum2 = 6;
                        break;
                    case "sunday":
                        dayNum2 = 7;
                        break;
                    default:
                        dayNum2 = 0;
                        break;
                }
                Console.WriteLine($"Result: {dayNum2}");

                Console.WriteLine();
            }
            #endregion

            #region Part01 - Problem 13: Params Keyword
            
            static void ParamsKeyword()
            {
                Console.WriteLine("=== Problem 13: Params Keyword ===");

                // Call with individual values
                int sum1 = SumArray(1, 2, 3, 4, 5);
                Console.WriteLine($"Sum of 1, 2, 3, 4, 5: {sum1}");

                // Call with array
                int[] numbers = { 10, 20, 30, 40 };
                int sum2 = SumArray(numbers);
                Console.WriteLine($"Sum of array {string.Join(", ", numbers)}: {sum2}");

                // Call with no arguments
                int sum3 = SumArray();
                Console.WriteLine($"Sum with no arguments: {sum3}");

                // Call with mixed
                int sum4 = SumArray(100, 200);
                Console.WriteLine($"Sum of 100, 200: {sum4}");

                Console.WriteLine();
            }

            static int SumArray(params int[] numbers)
            {
                int sum = 0;
                foreach (int num in numbers)
                {
                    sum += num;
                }
                return sum;
            }
            #endregion

            #region Part02 - Problem 1: Print Numbers in Range
            
            static void PrintNumbersInRange()
            {
                Console.WriteLine("=== Problem 1: Print Numbers in Range ===");

                Console.Write("Enter a positive integer: ");
                int n = int.Parse(Console.ReadLine());

                if (n <= 0)
                {
                    Console.WriteLine("Please enter a positive integer!");
                    return;
                }

                Console.Write("Output: ");
                for (int i = 1; i <= n; i++)
                {
                    Console.Write(i);
                    if (i < n)
                        Console.Write(", ");
                }
                Console.WriteLine("\n");
            }
            #endregion

            #region Part02 - Problem 2: Multiplication Table
            
            static void MultiplicationTable()
            {
                Console.WriteLine("=== Problem 2: Multiplication Table ===");

                Console.Write("Enter an integer: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Output: ");
                for (int i = 1; i <= 12; i++)
                {
                    Console.Write(number * i);
                    if (i < 12)
                        Console.Write(", ");
                }
                Console.WriteLine("\n");
            }
            #endregion

            #region Part02 - Problem 3: Even Numbers
           
            static void EvenNumbers()
            {
                Console.WriteLine("=== Problem 3: Even Numbers ===");

                Console.Write("Enter a number: ");
                int n = int.Parse(Console.ReadLine());

                Console.Write("Output: ");
                bool first = true;
                for (int i = 2; i <= n; i += 2)
                {
                    if (!first)
                        Console.Write(", ");
                    Console.Write(i);
                    first = false;
                }
                Console.WriteLine("\n");
            }
            #endregion

            #region Part02 - Problem 4: Exponentiation
           
            static void Exponentiation()
            {
                Console.WriteLine("=== Problem 4: Exponentiation ===");

                Console.Write("Enter base number: ");
                int baseNum = int.Parse(Console.ReadLine());

                Console.Write("Enter exponent: ");
                int exponent = int.Parse(Console.ReadLine());

                long result = 1;
                for (int i = 0; i < exponent; i++)
                {
                    result *= baseNum;
                }

                Console.WriteLine($"Output: {result}");
                Console.WriteLine();
            }
            #endregion

            #region Part02 - Problem 5: Reverse String
            
            static void ReverseString()
            {
                Console.WriteLine("=== Problem 5: Reverse String ===");

                Console.Write("Enter a string: ");
                string input = Console.ReadLine();

                // Method 1: Using loop
                string reversed = "";
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reversed += input[i];
                }

                Console.WriteLine($"Output: \"{reversed}\"");

                // Alternative: Using built-in methods
                char[] charArray = input.ToCharArray();
                Array.Reverse(charArray);
                string reversed2 = new string(charArray);
                Console.WriteLine($"Alternative output: \"{reversed2}\"");

                Console.WriteLine();
            }
            #endregion

            #region Part02 - Problem 6: Reverse Integer
            
            static void ReverseInteger()
            {
                Console.WriteLine("=== Problem 6: Reverse Integer ===");

                Console.Write("Enter an integer: ");
                int number = int.Parse(Console.ReadLine());

                int reversed = 0;
                int temp = Math.Abs(number); // Handle negative numbers

                while (temp > 0)
                {
                    int digit = temp % 10;
                    reversed = reversed * 10 + digit;
                    temp /= 10;
                }

                // Restore sign if original was negative
                if (number < 0)
                    reversed = -reversed;

                Console.WriteLine($"Output: {reversed}");
                Console.WriteLine();
            }
            #endregion

            #region Part02 - Problem 7: Longest Distance Between Matching Elements
            
            static void LongestDistance()
            {
                Console.WriteLine("=== Problem 7: Longest Distance Between Matching Elements ===");

                Console.Write("Enter the size of the array: ");
                int size = int.Parse(Console.ReadLine());

                int[] array = new int[size];

                Console.WriteLine("Enter array elements:");
                for (int i = 0; i < size; i++)
                {
                    Console.Write($"Element {i}: ");
                    array[i] = int.Parse(Console.ReadLine());
                }

                int maxDistance = 0;
                int value1 = 0, value2 = 0;
                int index1 = 0, index2 = 0;

                // Find longest distance
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i] == array[j])
                        {
                            int distance = j - i - 1; // Count cells between them
                            if (distance > maxDistance)
                            {
                                maxDistance = distance;
                                value1 = array[i];
                                value2 = array[j];
                                index1 = i;
                                index2 = j;
                            }
                        }
                    }
                }

                if (maxDistance > 0)
                {
                    Console.WriteLine($"\nLongest distance: {maxDistance}");
                    Console.WriteLine($"Between elements at index {index1} and {index2} (value: {value1})");
                }
                else
                {
                    Console.WriteLine("\nNo matching elements found in the array.");
                }

                Console.WriteLine();
            }
            #endregion

            #region Part02 - Problem 8: Reverse Words in Sentence
           
            static void ReverseWords()
            {
                Console.WriteLine("=== Problem 8: Reverse Words in Sentence ===");

                Console.Write("Enter a sentence: ");
                string sentence = Console.ReadLine();

                // Split the sentence into words
                string[] words = sentence.Split(' ');

                // Reverse the array
                Array.Reverse(words);

                // Join and print in single statement
                Console.WriteLine($"Output: {string.Join(" ", words)}");

                Console.WriteLine();
            }
            #endregion
        }
}
