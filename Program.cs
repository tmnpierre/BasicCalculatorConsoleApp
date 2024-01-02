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
                Console.Clear();
                ShowMainMenu();
                int choice = ReadIntFromConsole();

                switch (choice)
                {
                    case 1:
                        PerformCalculationMenu(history);
                        break;
                    case 2:
                        DisplayHistory(history);
                        break;
                    case 3:
                        DisplayHelp();
                        break;
                    case 4:
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        static void ShowMainMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Perform Calculation");
            Console.WriteLine("2. View History");
            Console.WriteLine("3. Help");
            Console.WriteLine("4. Quit");
            Console.WriteLine("Enter your choice (1-4):");
        }

        static void PerformCalculationMenu(List<string> history)
        {
            Console.Clear();
            Console.WriteLine("Enter your calculation (or 'back' to return to main menu):");
            string input = Console.ReadLine().Trim().ToLower();

            if (input != "back")
            {
                PerformCalculation(input, history);
            }
        }

        static void DisplayHistory(List<string> history)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nCalculation History:");
            foreach (var entry in history)
            {
                Console.WriteLine(entry);
            }
            Console.ResetColor();
        }

        static void DisplayHelp()
        {
            Console.WriteLine("\nHelp - How to use the calculator:");
            Console.WriteLine("  - To perform calculations, enter the operation followed by numbers.");
            Console.WriteLine("  - Supported operations: +, -, *, /, ^, sqrt, log.");
            Console.WriteLine("  - Enter 'h' to view calculation history.");
            Console.WriteLine("  - Enter 'q' to quit the application.\n");
        }

        static void PerformCalculation(string input, List<string> history)
        {
            double num1, num2;
            string operation;

            if (input == "sqrt" || input == "log")
            {
                Console.WriteLine("Enter the number:");
                num1 = ReadDoubleFromConsole();
                num2 = 0;
                operation = input;
            }
            else
            {
                string[] parts = input.Split(' ');
                if (parts.Length != 3)
                {
                    Console.WriteLine("Invalid format. Use [number] [operation] [number].");
                    return;
                }
                if (!double.TryParse(parts[0], out num1) || !double.TryParse(parts[2], out num2))
                {
                    Console.WriteLine("Invalid numbers. Please enter valid numbers.");
                    return;
                }
                operation = parts[1];
            }

            try
            {
                double result = PerformAdvancedOperation(num1, num2, operation);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Result: {result}");
                history.Add($"{num1} {operation} {num2} = {result}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
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

        static int ReadIntFromConsole()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine().Trim(), out int number))
                {
                    return number;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
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
