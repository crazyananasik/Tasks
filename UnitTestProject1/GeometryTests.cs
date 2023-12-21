using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MathTaskClassLibrary;
using CLASS;

namespace MathTaskClassLibraryTests
{
    [TestClass]
    public class GeometryTests
    {
        [TestMethod]
        public void CalculateAreaTest()
        {
            //исходные данные
            int a = 3; 
            int b = 5;
            int expected = 15; //ожидаемое значение

            //полученные значения с помощью тестируемого метода
            Geometry g = new Geometry();
            int actual = g.CalculateArea(a, b);
            //сравнение ожидаемого результата с полученным
            Assert.AreEqual(expected, actual);
        }
    }
    [TestClass]
    public class QuadraticEquationTest
    {
        [TestMethod]
        public void EquationTest()
        {
            double a = 2;
            double b = 10;
            double c = 5;
            double[] resalt = { -0.56, -4.44};
            QuadraticEquation g = new QuadraticEquation();
            double[] actual = g.Equation(a, b, c);
            Assert.AreEqual(resalt[0], actual[0], 0.01);
            Assert.AreEqual(resalt[1], actual[1], 0.01);
        }
    }

    [TestClass]
    public class YearTest
    {
        [TestMethod]
        public void DaysTest()
        {
            int year = 2008;
            int resalt = 366;
            Year d = new Year();
            int actual = d.Days(year);
            Assert.AreEqual(resalt, actual);
        }
    }

    [TestClass]
    public class StringNumberTest
    {
        [TestMethod]
        public void SumTest()
        {
            string number = "12345";
            int resalt = 15;
            StringNumber s = new StringNumber();
            int actual = s.Sym(number);
            Assert.AreEqual(resalt, actual);
        }
    }
    //IncreaseSalary. Проверьте корректность работы при "нормальном" значении параметра,
    //а также нулевом и отрицательном. Корректность работы = если все ок, ЗП увеличена, если не ок, получаем ошибку.

    [TestClass]
    public class StaffTest
    {
        [TestMethod]
        public void IncreaseSalaryTest()
        {
            int increase = 50;
            int resalt = 75;
            Staff s = new Staff();
            int actual = s.IncreaseSalary(increase);
            Assert.AreEqual(resalt, actual);

        }
    }
}
