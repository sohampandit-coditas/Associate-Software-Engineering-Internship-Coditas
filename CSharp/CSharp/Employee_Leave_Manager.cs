/*using System;
using System.Security.Cryptography.X509Certificates;
namespace LeaveTrackerApp 
{
    class LeaveMannager
    {
        public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            int choice;
            do
            {
                Console.WriteLine("***************Welcome to ZOHO Leave Manager!!*****************");
                Console.WriteLine("1. Employees Menu");
                Console.WriteLine("2. Manage Leaves");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Employees(employees);
                        break;

                    case 2:
                        Leaves(employees);
                        break;
                }
            } while (choice != 3);
        }

        public static void Employees(List<Employee> employees)
        {
            int choice;
            do
            {
                Console.WriteLine("****Employee Menu****");
                Console.WriteLine("1. Add Employees");
                Console.WriteLine("2. Display Employees");
                Console.WriteLine("3. Exit ");
                Console.WriteLine("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Employee employee = new Employee();
                        employee.SetName(employee);
                        employee.SetAge(employee);
                        employee.SetType(employee);
                        employees.Add(employee);
                        break;

                    case 2:
                        if (employees.Count <= 0)
                        {
                            Console.WriteLine("No Employees remaining!!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The employees are: ");
                            foreach (Employee emp in employees)
                            {
                                Console.WriteLine(emp.name);
                            }
                            break;

                        }

                    case 3:
                        break;



                }
            } while (choice != 3);


        }

        public static void Leaves(List<Employee> employees)
        {
            int choice;
            do
            {
                Console.WriteLine("****Leaves Tracker****");
                Console.WriteLine("1. Apply for Leave");
                Console.WriteLine("2. Check remaining Leaves");
                Console.WriteLine("3. Exit");
                Console.WriteLine("What's your choice?: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        foreach (Employee emp in employees)
                        {
                            if (emp.type == "contract")
                            {
                                ContractLeaveManager mng = new ContractLeaveManager();
                                Console.WriteLine("Enter your method of applying");
                                Console.WriteLine("1. Start Date to End Date");
                                Console.WriteLine("2. Days");
                                int ch = Convert.ToInt32(Console.ReadLine());
                                switch (ch)
                                {
                                    case 1:
                                        Console.WriteLine("Enter the start date: ");
                                        DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                                        Console.WriteLine("Enter the end date: ");
                                        DateTime endDate = Convert.ToDateTime(Console.ReadLine());
                                        mng.LeaveApprover(emp, startDate, endDate);
                                        break;

                                    case 2:
                                        Console.WriteLine("Enter the number of days you want a leave for:");
                                        int days = Convert.ToInt32(Console.ReadLine());
                                        mng.LeaveApprover(emp, days);
                                        break;


                                }
                                break;




                            }
                            else
                            {
                                LeaveManager mng = new LeaveManager();
                                Console.WriteLine("Enter your method of applying");
                                Console.WriteLine("1. Start Date to End Date");
                                Console.WriteLine("2. Days");
                                int ch = Convert.ToInt32(Console.ReadLine());
                                switch (ch)
                                {
                                    case 1:
                                        Console.WriteLine("Enter the start date: ");
                                        DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                                        Console.WriteLine("Enter the end date: ");
                                        DateTime endDate = Convert.ToDateTime(Console.ReadLine());
                                        mng.LeaveApprover(emp, startDate, endDate);
                                        break;

                                    case 2:
                                        Console.WriteLine("Enter the number of days you want a leave for:");
                                        int days = Convert.ToInt32(Console.ReadLine());
                                        mng.LeaveApprover(emp, days);
                                        break;


                                }
                                break;
                            }

                        }
                        break;

                    case 2:
                        foreach(Employee emp in employees)
                        {
                            Console.WriteLine("Name of Employee " + " Leaves Remaining");
                            Console.WriteLine(emp.name + " " + emp.leaveBalance);
                        }
                        break;
                    }
            } while (choice != 3);
        }
     }
}*/



