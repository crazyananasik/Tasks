using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CLASS;
using System.Net;
using System.Collections.Generic;

namespace TestCLASS
{
    [TestClass]
    public class StaffTest
    {
        [TestMethod]
        public void IncreaseSalary_NormalValue_SalaryIncreased()
        {
            Staff staff = new Staff("Иванов", "Иван", "Иванович", "Aдресс", new DateTime(1990, 1, 1), "админ", 100);
            staff.IncreaseSalary(50);
            Assert.AreEqual(150, staff.Salary);
        }
        [TestMethod]
        public void IncreaseSalary_ZeroValue_SalaryNotChanged()
        {
            Staff staff = new Staff("Иванов", "Иван", "Иванович", "Aдресс", new DateTime(1995, 5, 5), "админ", 200);
            staff.IncreaseSalary(0);
            Assert.AreEqual(200, staff.Salary);
        }

        [TestMethod]
        public void IncreaseSalary_NegativeValue_ThrowsException()
        {
            Staff staff = new Staff("Иванов", "Иван", "Иванович", "Aдресс", new DateTime(1985, 12, 12), "админ", 300);
            staff.IncreaseSalary(-50);
            Assert.AreEqual(250, staff.Salary);
        }
        //CalculateAge - в качестве года рождения берем 2000 год(чтобы удобнее было считать), в качестве дня рождения рассматриваем
        //2 случая - один -1 от текущей даты, второй +1 день.Соответственно разница в первом случае человеку будет 23 года,
        //во втором должно быть 22 (т.к.у второго дня рождения еще не наступило)
       
        [TestMethod]
        [DataRow(2000, 12, 1, 2023, 12, 2, 23)]
        [DataRow(2000, 12, 3, 2023, 12, 2, 22)]
        public void CalculateAgeBetweenDatesTest(int bdayYear, int bdayMonth, int bdayDay, int todayYear, int todayMonth, int todayDay, int age)
        {
            Staff staff = new Staff();
            DateTime bdate = new DateTime(bdayYear, bdayMonth, bdayDay);
            DateTime today = new DateTime(todayYear, todayMonth, todayDay);
            int d = staff.CalculateAgeBetweenDates(today, bdate);
            Assert.AreEqual(age, d);
        }

        public static IEnumerable<object[]> CalculateAgeTestData
        {
            get
            {
                return new[]
                {

                     new object[] { new DateTime(2000,12,1), new DateTime(2023,12,2), 23 },
                      new object[] { new DateTime(2000,12,3), new DateTime(2023,12,2), 22 },
                };
            }
        }

        [TestMethod]
        [DynamicData(nameof(CalculateAgeTestData))]
        public void CalculateAgeBetweenDatesTest2(DateTime bdate, DateTime today, int age)
        {
            Staff staff = new Staff();
            int d = staff.CalculateAgeBetweenDates(today, bdate);
            Assert.AreEqual(age, d);
        }
        //Метод Retire проверяем, что независимо от прошлых перемещений,
        //вызов этого метода действительно меняет должность на "На пенсии"
        [TestMethod]
        public void ReturnTest()
        {
            Staff staff = new Staff("Иванов", "Иван", "Иванович", "Aдресс", new DateTime(1990, 1, 1), "админ", 100);
            staff.Return();
            Assert.AreEqual("На пенсии", staff.Position);
            Assert.AreEqual(0, staff.Salary);
        }
        //GetDescription - проверяем корректность формирования строки.
        //        Проверяем 2 случая: с отчеством и без.Должны получиться 2 строки
        //        (прям копипастите в тест как ожидаемое значение GetDescription):
        //"Сотрудник: Иванов Иван Иванович, 2000 г.р., Должность: Дворник, Зарплата: 100000"
        //"Сотрудник: Иванов Иванович, 2000 г.р., Должность: Дворник, Зарплата: 100000";
        [TestMethod]
        [DataRow("Иван", "Иванов", "Иванович", "Address", 2000, 1, 1, "Дворник", 100000.0, "Сотрудник: Иванов Иван Иванович, 01.01.2000 г. р., Должность: Дворник, Зарплата: 100000")]
        [DataRow("Иван", "Иванов", "", "Address", 2000, 1, 1, "Дворник", 100000.0, "Сотрудник: Иванов Иван, 01.01.2000 г. р., Должность: Дворник, Зарплата: 100000")]
        [DataRow("Иван", "Иванов", "Сидорович", "Address", 2000, 1, 1, "Дворник", 100000.0, "Сотрудник: Иванов Иван Сидорович, 01.01.2000 г. р., Должность: Дворник, Зарплата: 100000")]
        public void GetDescriptionTest(string name, string lastName, string patronymic, string address,int bdayYear, int bdayMonth, int bdayDay, string position, double salary, string expectedWithoutPatronymic)
        {
            DateTime dateofbirth = new DateTime(bdayYear, bdayMonth, bdayDay);
            Staff staff = new Staff(name, lastName, patronymic, address, dateofbirth, position,(decimal) salary);

            string actual = staff.GetDescription();
            Assert.AreEqual(expectedWithoutPatronymic, actual);
        }
    }
}
