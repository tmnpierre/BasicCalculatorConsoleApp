using System;

namespace BasicCalculatorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1, num2;
            string input;
            char operation;

            Console.WriteLine("Enter the first number:");
            input = Console.ReadLine();
            while (!double.TryParse(input, out num1))
            {
                Console.WriteLine("Invalid input. Please enter a valid number:");
                input = Console.ReadLine();
            }

            Console.WriteLine("Enter the second number:");
            input = Console.ReadLine();
            while (!double.TryParse(input, out num2))
            {
                Console.WriteLine("Invalid input. Please enter a valid number:");
                input = Console.ReadLine();
            }

            Console.WriteLine("Enter the operation (+, -, *, /):");
            operation = Console.ReadKey().KeyChar;
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
                    return;
            }

            Console.WriteLine($"Result: {result}");
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
                Console.WriteLine("Error: Division by zero.");
                return 0;
            }
            else
            {
                return num1 / num2;
            }
        }
    }
}
