using Microsoft.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTaskClassLibrary
{
    public class Geometry
    {
        public int CalculateArea(int a, int b)
        {
            if (a < 0 || b < 0) throw new System.ArgumentException();
            return a * b;
        }
    }
    //1.	Дано целое число N (1 ≤ N ≤ 26). Сформировать строку,
    //содержащую N первых прописных (т.е. заглавных) букв латинского алфавита.
    public class CapitalLetters
    {
        public void N ()
        {
            Console.WriteLine("введите число от 1 до 26");
            int n = int.Parse(Console.ReadLine());
            if (n >= 1 && n <= 26)
            {
                char startChar = 'A';
                char[] alphabet = new char[n];
                for(int i = 0; i < n; i++)
                {
                    alphabet[i] = (char) (startChar + i);
                }
                string result = new string(alphabet);
                Console.WriteLine($"строка из {n} чисел содержит заглавные буквы: {result}");
            }
            else
            {
                Console.WriteLine("строка содержит недопустимое значение");
            }
            
        }
    }

    public class QuadraticEquation
    {
        public double[] Equation(double a, double b, double c)
        {
            double[] resalt;
            double D = Math.Pow(b, 2) - 4 * a * c;
            if(D > 0)
            {
                double x1 = (-b + Math.Pow(D, 0.5)) / (2*a);
                double x2 = (-b - Math.Pow(D, 0.5)) / (2 * a);
                resalt = new double[] { x1, x2 };
            }
            else if(D == 0)
            {
                double x1 = -b/(2*a);
                resalt = new double[] { x1 };
            }
            else
            {
                resalt = new double[0];
            }
            return resalt;
        }
    }
    //3.	Дан номер года (положительное целое число). Определить количество дней в этом году, учитывая,
    //что обычный год насчитывает 365 дней, а високосный -366 дней. Високосным считается год, делящийся на 4,
    //за исключением тех годов, которые делятся на 100 и не делятся на 400 (например, годы 300, 1300, и 1900 не являются високосными, а 1200 и 2000 – являются).
    public class Year
    {
        public int Days(int year)
        {
            if( year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
            {
                return 366;
            }
            else
            {
                return 365;
            }
        }
    }

    //5.Дана строка, изображающая целое положительное число. Вывести сумму цифр этого числа
    public class StringNumber
    {
        public int Sym(string number)
        {
            int sum = 0;
            foreach (char digit in number)
            {
                if (char.IsDigit(digit))
                {
                    sum += int.Parse(digit.ToString());
                }
            }
            return sum;
        }
    }
}
