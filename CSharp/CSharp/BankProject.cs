/*using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace BankProject
{
    public class Bank
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the username: ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter the designation: ");
            string designation = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Enter the password: ");
            Console.ForegroundColor = Console.BackgroundColor;
            string password = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            int mainMenuChoice;
            if (userName == "Soham" && designation == "manager" && password=="TAB")
            {
                do
                {
                    Console.WriteLine(": : : Main Menu : : : ");
                    Console.WriteLine("1. Customer Info ");
                    Console.WriteLine("2. Accounts Info ");
                    Console.WriteLine("3. Exit ");

                    Console.WriteLine("Enter your choice: ");
                    mainMenuChoice = Convert.ToInt32(Console.ReadLine());

                    switch (mainMenuChoice)
                    {
                        case 1:
                            CustomerInfo();
                            break;
                        case 2:
                            AccountInfo();
                            break;
                        case 3:
                            Console.WriteLine("Thank You!");
                            break;
                        default:
                            Console.WriteLine("Enter a Valid Choice!");
                            break;
                    }
                } while (mainMenuChoice != 3);

            }
            else
            {
                Console.WriteLine("Invalid Credentials!!");
                Console.ReadKey();
            }
        }

        public static void CustomerInfo()
        {
            List<Customer> customers = new List<Customer>();
            int choice;
            do
            {

                Console.WriteLine("1. Add Customer Info");
                Console.WriteLine("2. Display Customer Info");
                Console.WriteLine("3. Delete Customer");
                Console.WriteLine("4. Update Customer Info");
                Console.WriteLine("5. Go back to main menu");
                Console.WriteLine("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {

                    case 1:
                        Customer C = new Customer();
                        Console.WriteLine("Enter the id of the Customer");
                        C.id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the name of the Customer: ");
                        C.Name = Console.ReadLine();
                        Console.WriteLine("Enter the name of the city: ");
                        C.City = Console.ReadLine();
                        Console.WriteLine("Enter the name of the state: ");
                        C.State = Console.ReadLine();
                        customers.Add(C);
                        break;

                    case 2:
                        if (customers.Count == 0)
                        {
                            Console.WriteLine("There are no customers!");
                            break;
                        }

                        else
                        {
                            foreach (Customer c in customers)
                            {
                                Console.WriteLine($"ID:{c.id}, Name:{c.Name}, City: {c.City}, State: {c.State}");
                            }
                            break;
                        }

                    case 3:
                        Console.WriteLine("Enter the id of the customer to be deleted: ");
                        int deleteId = Convert.ToInt32(Console.ReadLine());

                        Customer deletedCustomer = null;

                        foreach (Customer c in customers)
                        {
                            if (c.id == deleteId)
                            {
                                deletedCustomer = c;
                            }
                        }
                        if (deletedCustomer == null)
                        {
                            Console.WriteLine("Customer does'nt exist!");
                            break;
                        }

                        customers.Remove(deletedCustomer);
                        Console.WriteLine("Customer " + deletedCustomer.id + " has been deleted!");
                        break;

                    case 4:
                        Console.WriteLine("Enter the Customer to be updated: ");
                        int customerId = Convert.ToInt32(Console.ReadLine());
                        Customer updatedCustomer = null;
                        foreach (Customer c in customers)
                        {
                            if (c.id == customerId)
                            {
                                updatedCustomer = c;
                            }
                        }

                        if (updatedCustomer == null)
                        {
                            Console.WriteLine("The customer does'nt exist!");
                            break;
                        }

                        Console.WriteLine("Enter the new Name: ");
                        updatedCustomer.Name = Console.ReadLine();

                        Console.WriteLine("Enter the new City: ");
                        updatedCustomer.City = Console.ReadLine();

                        Console.WriteLine("Enter the new State: ");
                        updatedCustomer.State = Console.ReadLine();

                        Console.WriteLine("Customer Updated!!");
                        break;

                }
            } while (choice != 5);
        }

        public static void AccountInfo()
        {
            List<Account> accounts = new List<Account>();
            int next = 1;
            int choice;
            do { 
            Console.WriteLine("1. Add Account Info");
            Console.WriteLine("2. Display Account Info");
            Console.WriteLine("3. Delete Account");
            Console.WriteLine("4. Update Account Info");
            Console.WriteLine("5. Go Back to main menu!");
            choice = Convert.ToInt32(Console.ReadLine());
      
                switch (choice)
                {

                    case 1:
                        Account A = new Account();
                        Console.WriteLine("Enter the id of the Account");
                        A.id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the name of the Customer: ");
                        A.Name = Console.ReadLine();
                        Console.WriteLine("Enter the status of the account(DBT/NON-DBT): ");
                        A.Status = Console.ReadLine();
                        Console.WriteLine("Enter the amount of money present: ");
                        A.Money = Convert.ToInt32(Console.ReadLine());
                        accounts.Add(A);
                        break;

                    case 2:
                        if (accounts.Count == 0)
                        {
                            Console.WriteLine("There are no customers!");
                            break;
                        }

                        else
                        {
                            foreach (Account a in accounts)
                            {
                                Console.WriteLine($"ID:{a.id}, Name:{a.Name}, Status: {a.Status}, Money: {a.Money}");
                            }
                            break;
                        }

                    case 3:
                        Console.WriteLine("Enter the id of the account to be deleted: ");
                        int deleteId = Convert.ToInt32(Console.ReadLine());

                        Account deletedAccount = null;

                        foreach (Account a in accounts)
                        {
                            if (a.id == deleteId)
                            {
                                deletedAccount = a;
                            }
                        }
                        if (deletedAccount == null)
                        {
                            Console.WriteLine("Account does'nt exist!");
                            break;
                        }

                        accounts.Remove(deletedAccount);
                        Console.WriteLine("Account " + deletedAccount.id + " has been deleted!");
                        break;

                    case 4:
                        Console.WriteLine("Enter the Customer to be updated: ");
                        int accountId = Convert.ToInt32(Console.ReadLine());
                        Account updatedAccount = null;
                        foreach (Account a in accounts)
                        {
                            if (a.id == accountId)
                            {
                                updatedAccount = a;
                            }
                        }

                        if (updatedAccount == null)
                        {
                            Console.WriteLine("The customer does'nt exist!");
                            break;
                        }

                        Console.WriteLine("Enter the new Name: ");
                        updatedAccount.Name = Console.ReadLine();

                        Console.WriteLine("Enter the new City: ");
                        updatedAccount.Status = Console.ReadLine();

                        Console.WriteLine("Enter the new amount: ");
                        updatedAccount.Money = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Customer Updated!!");
                        break;

                }
            } while (choice != 5);

        }


        public class Customer
        {
            public string Name { get; set; }
            public string City { get; set; }

            public string State { get; set; }
            public int id { get; set; }
        }

        public class Account
        {
            public string Name { get; set; }
            public int Money { get; set; }

            public string Status { get; set; }
            public int id { get; set; }
        }
    }
}*/