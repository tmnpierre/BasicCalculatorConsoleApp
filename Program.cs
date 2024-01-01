using System;

namespace BasicCalculatorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                try
                {
                    double num1 = ReadDoubleFromConsole("Enter the first number:");
                    double num2 = ReadDoubleFromConsole("Enter the second number:");

                    Console.Write("Enter the operation (+, -, *, /): ");
                    char operation = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    double result = PerformOperation(num1, num2, operation);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Result: {result}");
                    Console.ResetColor();
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid number format. Please enter valid numbers.");
                    Console.ResetColor();
                }
                catch (InvalidOperationException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid operation: {ex.Message}");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    Console.ResetColor();
                }

                Console.Write("Press 'q' to quit or any other key to continue...");
                if (Console.ReadKey().KeyChar == 'q')
                {
                    keepRunning = false;
                }
                Console.WriteLine();
            }
        }

        static double ReadDoubleFromConsole(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                if (double.TryParse(Console.ReadLine().Trim(), out double number))
                {
                    return number;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        static double PerformOperation(double num1, double num2, char operation)
        {
            return operation switch
            {
                '+' => Add(num1, num2),
                '-' => Subtract(num1, num2),
                '*' => Multiply(num1, num2),
                '/' => Divide(num1, num2),
                _ => throw new InvalidOperationException("Unsupported operation."),
            };
        }

        static double Add(double num1, double num2) => num1 + num2;
        static double Subtract(double num1, double num2) => num1 - num2;
        static double Multiply(double num1, double num2) => num1 * num2;
        static double Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return num1 / num2;
        }
    }
}
