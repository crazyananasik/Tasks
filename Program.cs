using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLASS
/*
САЛОН КРАСОТЫ
   База данных должна содержать сведения о следующих объектах:
   Сотрудники - фамилия, имя, отчество, адрес, дата рождения, должность, оклад, сведения о перемещении (должность, причина перевода, номер и дата приказа).
   Мастера - фамилия, специализация (список услуг, которые может оказывать), список материалов, находя-щихся на руках у мастера (наименование, количество, единица измерения, стоимость).
   Клиенты - фамилия, имя, отчество, телефон, дата и время заказа, заказ (услуга, стоимость услуги, мастер, оказывающий услугу).

   Выходные документы
   1.	Счет клиенту.
   2.	Справка о распределение материалов по мастерам.

   Бизнес-правила
   1.	Каждый мастер специализируется в оказании нескольких услуг.
   2.	Клиент делает только один заказ, в котором может заказать несколько услуг. Повторные заказы этого кли-ента рассматриваются как заказы нового клиента.
   3.	Услугу оказывает мастер, имеющий соответствующую специализацию и свободный в указанное время. После выполнения заказа с мастера списываются использованные материалы.
   4.	Сведения о выполненных заказах сохраняются в течение года.
   5.	Сведения об уволенных сотрудниках сохраняются в течение 5 лет.

   Количество исполнителей – 1.
*/
{
    public class Staff
    {
        string _name;
        string _lastName;
        string _patronymic;
        string _address;
        DateTime _dateofbirth;
        string _position;
        decimal _salary;
        Transfer[] _transfers;

        public void PrintToConsole()
        {
            Console.WriteLine($"сотрудник {_lastName} {_name} {_patronymic} {_address} {_dateofbirth} {_position} {_salary} рублей {_transfers}");
        }

        public Staff(string name, string lastName, string patronymic, string address, DateTime dateofbirth, string position, decimal salary)
        {
            this._name = name;
            this._lastName = lastName;
            this._patronymic = patronymic;
            this._address = address;
            this._dateofbirth = dateofbirth;
            this._position = position;
            this._salary = salary;
            _transfers = new Transfer[0];
        }

        public Staff()
        {
            _name = "Иванов";
            _lastName = "Иван";
            _patronymic = "Иванович";
            _address = "Ф";
            _dateofbirth = new DateTime(1111, 11, 11);
            _position = "Администратор";
            _salary = 25;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("имя не может быть пустым");
                _name = value;
            }
        }

        public string LastName
        {
            get { 
                return _lastName;
            }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("фамилия не может быть пустым");
                _lastName = value; 
            }
        }

        public string Patronymic
        {
            get { return _patronymic; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("отчество не может быть пустым");
                _patronymic = value; 
            }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public DateTime Dateofbirth
        {
            get { return _dateofbirth; }
            set { _dateofbirth = value; }
        }

        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public decimal Salary
        {
            get { return _salary; }
            private set { _salary = value; }
        }

        public Transfer[] Transfers
        {
            get { return _transfers; }
            set { _transfers = value; }
        }

        /// <summary>
        /// метод IncreaseSalary, который будет увеличивать зарплату сотрудника на заданную сумму
        /// public void IncreaseSalary(int increase) (параметр - это как раз сумма, на которую нужно увеличить)
        /// </summary>
        /// <param name="increase"></param>
        public int IncreaseSalary(int increase)
        {
            Salary = Salary + increase;
            return increase;
        }

        public int CalculateAgeBetweenDates(DateTime today, DateTime dateofbirth)
        {
            int age = today.Year - dateofbirth.Year;
            if (dateofbirth.Month < today.Month)
            {
                age--;
            }
            else if (dateofbirth.Month == today.Month)
            {
                if (dateofbirth.Day > today.Day)
                {
                    age--;
                }
                else
                {
                    return age;
                }
            }
            else
            {
                return age;
            }
            
            return age;
        }

        public int CalculateAge()
        {
            DateTime dateofbirth = Dateofbirth;
            DateTime today = DateTime.Now;
            int age = CalculateAgeBetweenDates (dateofbirth, today);
            return age; 
           //var  t = DateTime.Today - Dateofbirth;
           // return (int)(t.TotalDays / 365);
        }
        //Метод AddTransfer: Этот метод добавляет новую информацию о переводе в массив _transfers.
        //Он принимает объект Transfer в качестве параметра и добавляет его в массив
        //(для простоты реализации можно изменить тип переменной на список.. либо, если оставлять массив, то нам придется
        //создавать новый массив размера, большим, чем старый на 1..и сделать это во временную переменную, скопировать туда значения
        //старого массива, потом последним элементом transfer из параметра, и потом обновлять переменную класса)
        public void AddTranfer(Transfer newTransfer)
        {
            Transfer[] newArray = new Transfer[_transfers.Length + 1];
            for (int i = 0; i < _transfers.Length; i++)
            {
                newArray[i] = _transfers[i];
            }
            newArray[_transfers.Length] = newTransfer;
            _transfers = newArray;
        }
        public string GetDescription()
        {
            if(Patronymic == "")
            {
                return $"Сотрудник: {LastName} {Name}, {Dateofbirth.ToString("d")} г. р., Должность: {Position}, Зарплата: {Salary}";
            }
            else
            {
                return $"Сотрудник: {LastName} {Name} {Patronymic}, {Dateofbirth.ToString("d")} г. р., Должность: {Position}, Зарплата: {Salary}";

            }


           
               
           
           
        }

        //Метод Retire: Этот метод устанавливает статус сотрудника как "на пенсии" и устанавливает его зарплату на 0.
        public void Return()
        {
            _position = "На пенсии";
            _salary = 0;
        }
    }


    public class Transfer
    {
        string _position;
        string _reasonfForTransfer;
        decimal _numberOrder;
        DateTime _dateOrder;

        public Transfer()
        {
            _position = "Уборщик";
            _reasonfForTransfer = "повышение";
            _dateOrder = new DateTime(2013, 06, 23);
            _numberOrder = 345;
        }


        public DateTime DateOrder
        {
            get { return _dateOrder; }
            set 
            {
                if(_dateOrder > DateTime.Today)
                {
                    throw new ArgumentException("такой даты не существует");
                }
                _dateOrder = value; 
            }
            
        }
        public string Position
        {
            get { return _position; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("поле не должно быть пустым");
                _position = value;
            }
        }

        public string ReasonfForTransfer
        {
            get { return _reasonfForTransfer; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(ReasonfForTransfer));
            }
        }

        public decimal NumberOrder
        {
            get { return _numberOrder; }
            set { _numberOrder = value; }
        }

        //Метод ChangePosition: Этот метод может быть использован для изменения должности сотрудника.
        //Он принимает новую должность в качестве параметра и обновляет поле _position.
        public void ChangePosition(string new_position)
        {
            if (string.IsNullOrWhiteSpace(new_position))
            {
                throw new ArgumentException("Новая должность не может быть пустой.");
            }
            _position = new_position;
        }
    }

    public class Master
    {
        string _lastName;
        Specialization[] _specialization;
        ListOfMaterials[] _listOfMaterials;

        public Master(string lastName, string specialization)
        {
            _lastName = lastName;
            _specialization = new Specialization[0];
            _listOfMaterials = new ListOfMaterials[0];
        }

        public Master()
        {
            _lastName = "Иванова";
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if(string.IsNullOrEmpty(value))
                    throw new ArgumentException("поле не должно быть пустым");
                _lastName = value;
            }

        }
        public string GetDescription()
        {
            return $"Мастер: {LastName}";
        }



        public Specialization[] Specialization
        {
            get { return _specialization; }
            set { _specialization = value; }
        } 

        public ListOfMaterials[] ListOfMaterials 
        {
            get { return _listOfMaterials; }
            set { _listOfMaterials = value; }
        }
    }
    public class ListOfMaterials
    {
        string _name;
        int _quantity;
        string _unitOfMeasurement;
        int _cost;


        public ListOfMaterials()
        { 
            _name = "гель лак";
            _quantity = 24;
            _unitOfMeasurement = "мл";
            _cost = 1300;
        }

        public string Name
        {
            get { return _name; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("поле не должно быть пустым"); 
                _name = value; 
            }
        }

        public int Quantity 
        { 
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string UnitOfMeasurenent 
        {
            get { return _unitOfMeasurement; }
            set { _unitOfMeasurement = value; }
        }

        public int Cost 
        {
            get { return _cost; }
            set { _cost = value; }
        }
    }

    public class Specialization
    {
        Master[] Master;
        string _specializations;

        public Specialization(Master[] Masters)
        {
            Master = new Master[0];
        }

        public Specialization()
        {
            _specializations = "мастер по маникюру";
        }

        public string Specializations
        {
            get { return _specializations; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("поле не может быть пустым");
                _specializations = value; 
            }
        }
        public string GetDescription()
        {
            return $"Специализация: {_specializations}";
        }
    }

    public class Customer
    {
        string _lastname;
        string _name;
        string _patronymic;
        long _phoneNumber;
        DateTime _dateOfOrder;
        Order[] _order;

        public Customer()
        {
            _lastname = "Иванов";
            _name = "Иван";
            _patronymic = "Иванович";
            _phoneNumber = 1111111111;
            _dateOfOrder = new DateTime(2013, 02, 15, 18, 30, 00);
        }

        public string LastName
        {
            get { return _lastname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("поле не должно быть пустым");
                _lastname = value;
            }

        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("поле не должно быть пустым");
                _name = value;
            }
        }

        public string Patronymic
        {
            get { return _patronymic; }
            set { _patronymic = value; }
        }

        public long PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public DateTime DateOfOrder
        {
            get { return _dateOfOrder; }
            set { _dateOfOrder = value; }
        }

        public Order[] Order
        {
            get { return _order; }
            set { _order = value; }
        }
        public string GetDescription()
        {
            return $"Клиент: {LastName} {Name} Телефон: {PhoneNumber} Дата: {DateOfOrder}";
        }
    }

    public class Order
    {
        string _service;
        int _costService;
        Master[] Master;

        public Order()
        {
            _service = "маникюр";
            _costService = 1400;
        }

        public Order(Master[] Master)
        {
            Master = new Master[0];
        }

        public string Service
        {
            get { return _service; }
            set { _service = value; }
        }

        public int CostService
        {
            get { return _costService; }
            set { _costService = value; }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
            Staff staff = new Staff();
            int t =  staff.CalculateAge();
            Console.WriteLine(t);
            Console.WriteLine(staff.GetDescription());
            Master master = new Master();
            Console.Write(master.GetDescription() + " ");
            Specialization specialization = new Specialization();
            Console.WriteLine(specialization.GetDescription());
            Customer customer = new Customer();
            Console.WriteLine(customer.GetDescription());

            Staff staff1 = new Staff("Иванов", "Иван", "Иванович", "ф", new DateTime(2003, 02, 15), "Администратор", 255000) ;
            staff1.PrintToConsole();

            Console.ReadKey();
        }
    }
}
