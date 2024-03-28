using System;

namespace lab3
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите x");
                double i = double.Parse(Console.ReadLine().Trim());

                Program program = new Program();
                Console.WriteLine(program.MathSystem(i));
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Некорректный ввод. Пожалуйста, введите число.");
            }

        }
        public double MathSystem(double x)
        {
            if (x >= 0)
            {
                return Module(Pov(FindSin(x), 2) - FindCos(x));
            }
            else
                return Ln(FindSin(x)) + Root(FindCos(x));
        }


        // Степень
        private double Pov(double input, int pow)
        {
            if (pow == 0)
            {
                return 1;
            }
            else if (pow > 0)
            {
                double result = input;
                for (int i = 1; i < pow; i++)
                {
                    result *= input;
                }
                return result;
            }
            else
            {
                double result = 1 / input;
                for (int i = -1; i > pow; i--)
                {
                    result /= input;
                }
                return result;
            }
        }

        // Факториал
        private double Factorial(double n)
        {
            if (n < 0)
            {
                return double.NaN;
            }
            // Факториал 0 равен 1
            if (n == 0)
            {
                return 1;
            }
            long result = 1;
            // Вычисление факториала
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        // Синус
        public double FindSin(double x)
        {
            double result = 0.0;
            for (int i = 0; i < 10; i++)
            {
                int exponent = 2 * i + 1;
                double term = Pov(-1, i) * Pov(x, exponent) /
                Factorial(exponent);
                result += term;
            }
            return result;
        }

        // Косинус
        public double FindCos(double x)
        {
            double result = 0.0;
            for (int i = 0; i < 10; i++)
            {
                int exponent = 2 * i;
                double term = Pov(-1, i) * Pov(x, exponent) /
                Factorial(exponent);
                result += term;
            }
            return result;
        }

        // Логарифм
        public double Ln(double x)
        {
            double result = 0.0;
            for (int n = 1; n <= 10; n++)
            {
                double term = Pov(-1, n - 1) * Pov(x - 1, n) / n;
                result += term;
            }
            return result;
        }

        // Модуль
        public double Module(double x)
        {
            if (x >= 0)
            {
                return x;
            }
            else
            {
                return -x;
            }
        }

        // Корень
        public double Root(double x)
        {
            if (x < 0)
            {
                return double.NaN;
            }
            // Начальное приближение
            double appr = x / 2;
            double diff;
            do
            {
                double subAppr = appr;
                appr = 0.5 * (subAppr + (x / subAppr));
                diff = Math.Abs(appr - subAppr);
            }
            // Проверка на достижение необходимой точности
            while (diff > double.Epsilon);
            return appr;
        }
    }
}
