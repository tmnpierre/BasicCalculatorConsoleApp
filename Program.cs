using System;
using System.Collections.Generic;

namespace BasicCalculatorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> history = new List<string>();
            bool keepRunning = true;

            while (keepRunning)
            {
                try
                {
                    double num1, num2;
                    Console.Write("Enter the operation (+, -, *, /, ^, sqrt, log): ");
                    string operation = Console.ReadLine().Trim().ToLower();

                    if (operation == "sqrt" || operation == "log")
                    {
                        Console.WriteLine("Enter the number:");
                        num1 = ReadDoubleFromConsole();
                        num2 = 0;
                    }
                    else
                    {
                        Console.WriteLine("Enter the first number:");
                        num1 = ReadDoubleFromConsole();
                        Console.WriteLine("Enter the second number:");
                        num2 = ReadDoubleFromConsole();
                    }

                    double result = PerformAdvancedOperation(num1, num2, operation);
                    history.Add($"{num1} {operation} {num2} = {result}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Result: {result}");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }

                Console.Write("Press 'h' to view history, 'q' to quit, or any other key to continue...");
                char userInput = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (userInput == 'q')
                {
                    keepRunning = false;
                }
                else if (userInput == 'h')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nCalculation History:");
                    foreach (var entry in history)
                    {
                        Console.WriteLine(entry);
                    }
                    Console.ResetColor();
                }
            }
        }

        static double ReadDoubleFromConsole()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine().Trim(), out double number))
                {
                    return number;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        static double PerformAdvancedOperation(double num1, double num2, string operation)
        {
            return operation switch
            {
                "+" => Add(num1, num2),
                "-" => Subtract(num1, num2),
                "*" => Multiply(num1, num2),
                "/" => Divide(num1, num2),
                "^" => Math.Pow(num1, num2),
                "sqrt" => Math.Sqrt(num1),
                "log" => Math.Log(num1),
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
