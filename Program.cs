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

                    Console.WriteLine("Enter the operation (+, -, *, /):");
                    char operation = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    double result;
                    switch (operation)
                    {
                        case '+':
                            result = Add(num1, num2);
                            break;
                        case '-':
                            result = Subtract(num1, num2);
                            break;
                        case '*':
                            result = Multiply(num1, num2);
                            break;
                        case '/':
                            result = Divide(num1, num2);
                            break;
                        default:
                            Console.WriteLine("Invalid operation.");
                            continue;
                    }

                    Console.WriteLine($"Result: {result}");
                    Console.WriteLine("Press 'q' to quit or any other key to continue...");
                    if (Console.ReadKey().KeyChar == 'q')
                    {
                        keepRunning = false;
                    }
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        static double ReadDoubleFromConsole(string prompt)
        {
            double number;
            string input;
            Console.WriteLine(prompt);
            input = Console.ReadLine().Trim();

            while (!double.TryParse(input, out number))
            {
                Console.WriteLine("Invalid input. Please enter a valid number:");
                input = Console.ReadLine().Trim();
            }

            return number;
        }

        static double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

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
