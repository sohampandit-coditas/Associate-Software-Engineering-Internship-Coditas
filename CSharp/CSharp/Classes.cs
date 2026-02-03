using Microsoft.Identity.Client;
using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
namespace CSharp
{
    public class Employee
    {
        internal string name;
        private int age;
        public string type;
        internal int leaveBalance = 30;
        private static int allowedLeaves = 30;

        public void SetName(Employee employee)
        {
            Console.WriteLine("Enter the employee name: ");
            string name = Console.ReadLine();
            employee.name = name;
        }

        public void SetAge(Employee employee)
        {
            Console.WriteLine("Enter the employee's age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            employee.age = age;
        }

        public void SetType(Employee employee)
        {
            Console.WriteLine("Enter the employment type of the employee: ");
            string type = Console.ReadLine();
            employee.type = type;
        }

        public void UpdateLeaves(Employee employee, int leaves)
        {
            employee.leaveBalance = employee.leaveBalance - leaves;
        }



    }

    public class LeaveManager
    {
        public void LeaveApprover(Employee employee, int days)
        {
            if (employee.leaveBalance > days)
            {
                employee.UpdateLeaves(employee, days);
            }
            else
            {
                Console.WriteLine("Cannot apply for leaves!! Leave Balance: " + employee.leaveBalance);
            }
        }
        public void LeaveApprover(Employee employee, DateTime startDate, DateTime endDate)
        {
            int days = (int)(endDate - startDate).TotalDays;

            if (employee.leaveBalance > days)
            {
                employee.UpdateLeaves(employee, days);
            }
            else
            {
                Console.WriteLine("Cannot apply for leaves!! Leave Balance: " + employee.leaveBalance);
            }
        }
    }

    public class ContractLeaveManager : LeaveManager
    {
        public void LeaveApprover(Employee employee, int days)
        {
            employee.leaveBalance = 20;
            if (employee.leaveBalance > days)
            {
                employee.UpdateLeaves(employee, days);
            }
            else
            {
                Console.WriteLine("Cannot apply for leaves!! Leave Balance: " + employee.leaveBalance);
            }
        }
        public void LeaveApprover(Employee employee, DateTime startDate, DateTime endDate)
        {

            int days = (int)(endDate - startDate).TotalDays;
            days = days - 5;
            if (employee.leaveBalance > days)
            {
                days = days - 5;
                employee.UpdateLeaves(employee, days);
            }
            else
            {
                Console.WriteLine("Cannot apply for leaves!! Leave Balance: " + employee.leaveBalance);
            }
        }
    }

    public class Patient
    {
        string name;
        int age;
        string symptom;

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetAge(int age)
        {
            this.age = age;
        }

        public void SetSymptom(string symptom, string description = "")
        {
            this.symptom = symptom;

            if (description != "")
            {
                symptom += "-" + description;
            }
        }

        public string GetName()
        {
            return name;
        }

        public int GetAge()
        {
            return age;
        }

        public string GetSymptom()
        {
            return symptom;
        }
    }

    public class MedicalBot
    {
        public void StartConsultation(Patient patient)
        {
            string advice;
            AnalyzeSymptoms(patient.GetSymptom(), patient, out advice);
            Console.WriteLine(advice);
        }

        private void AnalyzeSymptoms(string symptom, Patient patient, out string advice)
        {
            bool IsSevere()
            {
                return symptom.ToLower().Contains("chest") || symptom.ToLower().Contains("breathing");
            }

            bool IsEmergency()
            {
                return patient.GetAge() > 60 && IsSevere();
            }

            if (IsSevere())
            {
                advice = "This is a serious cause of concern, please report to your doctor as soon as possible!!";
            }

            if (IsEmergency())
            {
                advice = "This is an emergency, please visit your hospital at the earliest!!!!";
            }

            else
            {
                advice = "This is a mild disease, take medications and rest!";
            }
        }
    }

    class FoodItem
    {
        private double basePrice;
        protected double price
        {
            get { return basePrice; }
            set
            {
                if (value > 0)
                {
                    price = value;
                }
            }
        }
        public string name { get; private set; }

        public FoodItem(string name, double price)
        {
            this.name = name;
            basePrice = price;
        }
        public virtual double CalculateBasePrice()
        {
            return basePrice;
        }

    }

    class Veg : FoodItem
    {
        public Veg(string name, double price, string type = "Veg") : base(name, price)
        {
        }

        public override double CalculateBasePrice()
        {
            return price + (price * 0.05);
        }
    }

    class NonVeg : FoodItem
    {
        public NonVeg(string name, double price, string type = "Non Veg") : base(name, price)
        {
        }

        public override double CalculateBasePrice()
        {
            return price + (price * 0.1);
        }
    }

    class Beverage : FoodItem
    {
        public Beverage(string name, double price, string type = "Beverage") : base(name, price)
        {
        }

        public override double CalculateBasePrice()
        {
            return price;
        }
    }

    class Menu
    {
        private List<FoodItem> items = new List<FoodItem>();

        public void AddItem(FoodItem item)
        {
            items.Add(item);
        }

        public FoodItem this[int index]
        {
            get { return items[index]; }
        }

        public void Show()
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i}.{items[i].name},{items[i].CalculateBasePrice()}");
            }
        }
    }

    class Cart
    {
        private List<FoodItem> cartItems = new List<FoodItem>();
        public void AddItem(FoodItem item)
        {
            cartItems.Add(item);
        }

        public void AddItem(FoodItem item, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                cartItems.Add(item);
            }
        }

        public double GetTotal()
        {
            double total = 0;
            foreach (FoodItem item in cartItems)
            {
                total += item.CalculateBasePrice();
            }
            return total;
        }
    }

    public class Zomato
    {
        private Menu menu;
        private Cart cart;

        public Zomato()
        {
            menu = new Menu();
            cart = new Cart();
            LoadMenu();
        }
        public void LoadMenu()
        {
            menu.AddItem(new Veg("Paneer Pasanda", 200));
            menu.AddItem(new NonVeg("Chicken Wings", 400));
            menu.AddItem(new Beverage("Coca Cola", 100));
        }

        public void ShowMenu()
        {
            menu.Show();
        }

        public void AddToCart(int menuIndex)
        {
            cart.AddItem(menu[menuIndex]);
        }

        public void AddToCart(int menuIndex, int quantity)
        {
            cart.AddItem(menu[menuIndex], quantity);
        }

        public double GetFinalAmount()
        {
            return cart.GetTotal();
        }
    }

    public class Modules
    {
        public class Module_3
        {
            public class Student
            {
                private int _id { get; set; }
                private string _name { get; set; }
                private double _marksObtained { get; set; }
                private double _percentage { get; set; }
                private bool _isPassed { get; set; }

                public Student(int id, string name)
                {
                    this._id = id;
                    this._name = name;
                    _marksObtained = 0;
                    _percentage = 0;
                    _isPassed = false;
                }

                private void CalculatePercentage(double maxMarks)
                {
                    _percentage = (_marksObtained / maxMarks) * 100;
                }

                private void DeterminePassStatus(double passPercentage)
                {
                    _isPassed = _percentage > passPercentage;
                }

                private void SetMarks(double marks, double maxMarks, double passPercentage)
                {
                    _marksObtained = marks;
                    CalculatePercentage(maxMarks);
                    DeterminePassStatus(passPercentage);
                }

                private void Display()
                {
                    Console.WriteLine($"ID: {_id}");
                    Console.WriteLine($"Name: {_name}");
                    Console.WriteLine($"Marks: {_marksObtained}");
                    Console.WriteLine($"Percentage: {_percentage}");
                    Console.WriteLine(_isPassed ? "Status: Pass" : "Status: Fail");
                }

                private bool CheckId(int id)
                {
                    return _id == id;
                }

                public void Perform(string action, double marks = 0, double maxMarks = 0, double passPercentage = 0)
                {
                    switch (action.ToLower())
                    {
                        case "enter marks":
                            SetMarks(marks, maxMarks, passPercentage);
                            break;
                        case "display":
                            Display();
                            break;
                    }
                }

                public bool IsId(int id)
                {
                    return CheckId(id);
                }

            }


        } 

        public class Module_5
        {
            public abstract class LibraryItem
            {
                public int _itemId { get; set; }
                protected string title {  get; set; }
                public bool isAvailable { get; set; }
                public LibraryItem(int itemId,string title) 
                {
                    this._itemId = itemId;
                    this.title = title;
                    isAvailable = true;
                }

                public void MarkAsBorrowed()
                {
                    isAvailable = false;
                }

                public void MarkAsReturned()
                {
                    isAvailable = true; 
                }

                public abstract string GetItemDetails();
            }

            public class book : LibraryItem
            {
                private string Author { get; set; }
                public book(int  id, string title, string author):base(id, title) 
                {
                    Author = author;
                }

                public override string GetItemDetails()
                {
                    return $"Book:{title},Author:{Author},Available: {isAvailable}";
                }
            }

            public class magazine : LibraryItem
            {
                private int issueNo { get; set; }

                public magazine(int id, string title, int issueNo) : base(id, title) 
                {
                    this.issueNo = issueNo;
                }

                public override string GetItemDetails()
                {
                    return $"issueNo: {issueNo}, Magazine: {title}, Available: {isAvailable}";
                }
            }

            public abstract class User
            {
                public int userId { get; set; }
                public string Name { get; set; }
                protected List<LibraryItem> borrowedItems;

                protected User(int id, string name)
                {
                    userId = id;
                    Name = name;
                    borrowedItems = new List<LibraryItem>();
                }

                public IReadOnlyList<LibraryItem> BorrowedItems => borrowedItems.AsReadOnly();

                public abstract int BorrowLimit { get; }

                public virtual bool canBorrow()
                {
                    return borrowedItems.Count < BorrowLimit;
                }

                public void BorrowItem(LibraryItem item)
                {
                    if (!item.isAvailable)
                    {
                        Console.WriteLine("Item is not available!");
                    }

                    if (!canBorrow())
                    {
                        Console.WriteLine("Cannot Borrow!");
                    }

                    borrowedItems.Add(item);
                    item.MarkAsBorrowed();
                }

                public void ReturnItem(LibraryItem item)
                {
                    if (borrowedItems.Remove(item))
                    {
                        item.MarkAsReturned();
                    }
                }
            }
                public class Student : User
                {
                    public Student(int userId, string name) : base(userId, name) { }
                    public override int BorrowLimit =>3;
                }

                public class Faculty : User
                {
                    public Faculty(int userId,string name) : base(userId, name) { }
                    public override int BorrowLimit => 5;
                }
            
        }
    }
}

