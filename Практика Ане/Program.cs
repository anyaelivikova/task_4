using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_Ане
{
    class Program
    {
        public delegate double Function(double x);
        static void Main(string[] args)
        {
            Console.WriteLine("<<< задача 4 >>>");
            double e = 0;
            while (true)
            {
                try
                {
                    Console.Write("Введите положительное значение допустимой погрешности: ");
                    e = Convert.ToDouble(Console.ReadLine());
                    if (e <= 0) throw new Exception();
                    break;
                }
                catch { Console.WriteLine("\nДопущена ошибка при вводе\n"); }
            }

            double a = 0, b = Math.PI / 2; // границы отрезка поиска значения
            Function f = (x => 2 * Math.Pow(Math.Sin(x), 2) / 3 - 3 * Math.Pow(Math.Cos(x), 2) / 4); // формула
            while (Math.Abs(f((a + b) / 2) - 0) > e) // пока в центре отрезка значение формулы больше погрешности
            {
                double aver = (a + b) / 2;
                if (f(aver) * f(b) > 0) b = aver; // проверка на знаки: если aver и b одного знака, то > 0
                else a = aver;
            }

            Console.WriteLine($"С учетом погрешности e = {e} на отрезке [0, PI/2]\nРешением уравнения 2sin^2(x)/3 - 3cos^2(x)/4 = 0 является x = {(a + b) / 2}");
            Console.ReadKey();
        }
    }
}
