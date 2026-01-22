using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ПРОСТОЙ КАЛЬКУЛЯТОР ===\n");

            bool continueCalculation = true;

            while (continueCalculation)
            {
                try
                {
                    // Ввод первого числа
                    Console.Write("Введите первое число: ");
                    double num1 = GetValidNumber();

                    // Ввод операции
                    Console.Write("Введите операцию (+, -, *, /, %, ^): ");
                    char operation = GetValidOperation();

                    // Ввод второго числа
                    Console.Write("Введите второе число: ");
                    double num2 = GetValidNumber();

                    // Выполнение вычисления
                    double result = Calculate(num1, num2, operation);

                    // Вывод результата
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nРезультат: {num1} {operation} {num2} = {result}\n");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nОшибка: {ex.Message}\n");
                    Console.ResetColor();
                }

                // Проверка на продолжение
                Console.Write("Продолжить вычисления? (y/n): ");
                continueCalculation = Console.ReadLine().ToLower() == "y";
                Console.WriteLine();
            }

            Console.WriteLine("Спасибо за использование калькулятора!");
        }

        static double GetValidNumber()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double number))
                {
                    return number;
                }
                Console.Write("Некорректный ввод. Пожалуйста, введите число: ");
            }
        }

        static char GetValidOperation()
        {
            char[] validOperations = { '+', '-', '*', '/', '%', '^' };

            while (true)
            {
                string input = Console.ReadLine();
                if (input.Length == 1 && Array.IndexOf(validOperations, input[0]) != -1)
                {
                    return input[0];
                }
                Console.Write("Некорректная операция. Доступные операции: +, -, *, /, %, ^: ");
            }
        }

        static double Calculate(double num1, double num2, char operation)
        {
            return operation switch
            {
                '+' => num1 + num2,
                '-' => num1 - num2,
                '*' => num1 * num2,
                '/' => num2 != 0 ? num1 / num2 : throw new DivideByZeroException("Деление на ноль невозможно!"),
                '%' => num2 != 0 ? num1 % num2 : throw new DivideByZeroException("Деление на ноль невозможно!"),
                '^' => Math.Pow(num1, num2),
                _ => throw new InvalidOperationException("Неизвестная операция")
            };
        }
    }
}