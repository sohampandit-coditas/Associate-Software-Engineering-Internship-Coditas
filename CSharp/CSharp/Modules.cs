using System;
using System.Collections.Generic;
using System.Text;
using CSharp;
using student = CSharp.Modules.Module_3.Student;
using stud = CSharp.Modules.Module_5.Student;
using fact = CSharp.Modules.Module_5.Faculty;
using Library =  CSharp.Modules.Module_5.LibraryItem;
using book = CSharp.Modules.Module_5.book;
using mag = CSharp.Modules.Module_5.magazine;
using User = CSharp.Modules.Module_5.User;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;


namespace CSharp
{
    public class Module_3
    {
        static void Main(string[] args)
        {
            int maxStudents = ReadInt("Enter Maximum number of students: ");
            double maxMarks = ReadDouble("Enter Max Total Marks: ");
            double passPercentage = ReadDouble("Enter Passing Percentage: ");

            student[] students = new student[maxStudents];
            int studentCount = 0;

            while (true)
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Enter/Update Marks: ");
                Console.WriteLine("3. Display Student Results");
                Console.WriteLine("4. Exit");

                int choice = ReadInt("Enter your choice: ");
                switch (choice)
                {
                    case 1:
                        if (studentCount >= maxStudents)
                        {
                            Console.WriteLine("Student Limit Reached");
                            break;
                        }
                        int id = ReadInt("Enter Student Id: ");
                        if (IsDuplicateId(students, studentCount, id))
                        {
                            Console.WriteLine("Duplicate Id not allowed!");
                            break;
                        }

                        string name = ReadString("Enter your name: ");
                        students[studentCount] = new student(id, name);
                        studentCount++;
                        Console.WriteLine("Student added successfully");
                        break;

                    case 2:
                        student s1 = FindStudent(students, studentCount);
                        if (s1 == null)
                        {
                            Console.WriteLine("Student does'nt exist!!");
                        }
                        double marks;
                        while (true)
                        {
                            marks = ReadDouble("Enter marks obtained: ");
                            if (marks >= 0 && marks <= maxMarks)
                            {
                                break;
                            }
                            Console.WriteLine("Enter Valid Marks!!");
                        }

                        s1.Perform("enter marks", marks, maxMarks, passPercentage);
                        Console.WriteLine("Marks Updated!");
                        break;

                    case 3:
                        student s2=FindStudent(students, studentCount);
                        if (s2 == null)
                        {
                            break;
                        }
                        s2.Perform("display");
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice!!");
                        break;
                }
            }
        }

        static int ReadInt(string message)
        {
            int value;
            while (true) {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;   
                }
            }

            Console.WriteLine("Invalid number");
        }

        static double ReadDouble(string message)
        {
            double value;
            while (true)
            {
                Console.Write(message);
                if(double.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
            }

            Console.WriteLine("Invalid number");
        }

        static string ReadString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        static bool IsDuplicateId(student[] students,int count, int id)
        {
            for(int i = 0; i < count; i++)
            {
                if (students[i].IsId(id))
                {
                    return true;
                }

            }
            return false;
        }

        static student FindStudent(student[] students,int count)
        {
            int id = ReadInt("Enter student id: ");
            for (int i = 0; i < count; i++) 
            {
                if (students[i].IsId(id))
                {
                    return students[i];
                }
            }

            Console.WriteLine("Student not found! ");
            return null;


    public class Module_5
    {
        static List<Library> libraryItems = new List<Library>();
        static List<User> users = new List<User>();

        public static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("==== Library Menu ====");
                Console.WriteLine("1. Add Library Items");
                Console.WriteLine("2. Add Users");
                Console.WriteLine("3. Display Available Items");
                Console.WriteLine("4. Borrow Items");
                Console.WriteLine("5. Return Items");
                Console.WriteLine("6. Display Borrowed Items");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddItems();
                        break;
                    case 2:
                        AddUser();
                        break;
                    case 3:
                        DisplayAvailableItems();
                        break;
                    case 4:
                        BorrowItem();
                        break;
                    case 5:
                        ReturnItem();
                        break;
                    case 6:
                        DisplayBorrowedItems();
                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine("INVALID CHOICE");
                        break;
                }
            } while (choice != 7);

        }

        public static void AddItems()
        {
            Console.WriteLine("1. Book");
            Console.WriteLine("2. Magazine");
            Console.WriteLine("Select Item type: ");

            string type = Console.ReadLine();

            Console.WriteLine("Enter the item id: ");
            int itemId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the title:- ");
            string title= Console.ReadLine();

            if (type == "1" || type=="Book")
            {
                Console.Write("Enter the author: ");
                string author= Console.ReadLine();
                libraryItems.Add(new book(itemId, title, author));
            }
            else if(type == "2" || type == "Magazine")
            {
                Console.Write("Enter the issue no. ");
                int issue=Convert.ToInt32(Console.ReadLine());
                libraryItems.Add(new mag(itemId, title, issue));
            }
            else 
            {
                Console.WriteLine("Enter A Valid Choice");
            }
        }

        public static void AddUser()
        {
            Console.WriteLine("1. Student");
            Console.WriteLine("2. Faculty");
            Console.WriteLine("Enter your choice: ");
            string type= Console.ReadLine();

            Console.Write("Enter User Id: ");
            int userId=Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the Name: ");
            string name=Console.ReadLine();

            if (type == "1")
            {
                users.Add(new stud(userId, name));
            }
            else if (type == "2") 
            {
                users.Add(new fact(userId, name));
            }
            else
            {
                Console.WriteLine("Invalid Choice!");
            }
        }

        public static void DisplayAvailableItems()
        {
            Console.WriteLine("Available items are: ");
            for(int i = 0; i < libraryItems.Count; i++)
            {
                if (libraryItems[i].isAvailable)
                {
                    Console.WriteLine(libraryItems[i].GetItemDetails());
                }
            }
        }

        public static void BorrowItem()
        {
            User user = SelectUser();
            if (user == null)
            {
                return;
            }

            Console.Write("Enter item Id to borrow: ");
            int itemid = int.Parse(Console.ReadLine());

            Library item = FindItemById(itemid);

            if (item == null)
            {
                Console.WriteLine("Item Not Found!!");
                return;
            }

            try
            {
                user.BorrowItem(item);
                Console.WriteLine("Item borrowed successfully!!");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void ReturnItem()
        {
            User user = SelectUser();
            if (user == null) return;

            Console.WriteLine("Enter ItemId to return: ");
            int itemId = int.Parse(Console.ReadLine());

            Library item = FindItemById(itemId);
            if (item == null)
            {
                Console.WriteLine("Item not found!!");
                return;
            }

            user.ReturnItem(item);
            Console.WriteLine("Item Returned");
        }

        public static void DisplayBorrowedItems()
        {
            User user = SelectUser();
            if (user == null) return;
            Console.WriteLine($"Borrowed Items by {user.Name}");

            for(int i = 0; i < user.BorrowedItems.Count; i++)
            {
                Console.WriteLine(user.BorrowedItems[i].GetItemDetails());
            }
        }

        static User SelectUser()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("No users Available");
                return null;
            }

            Console.WriteLine("Select User: ");
            for(int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{users[i].userId} {users[i].Name} ({users[i].GetType().Name})");
            }

            Console.WriteLine("Enter User ID:");
            int userid = int.Parse(Console.ReadLine());
            for(int i = 0; i < users.Count; i++)
            {
                if (users[i].userId == userid)
                {
                    return users[i];
                }
            }

            Console.WriteLine("User Not Found");
            return null;
        }

        static Library FindItemById(int itemId)
        {
            for(int i = 0; i < libraryItems.Count; i++)
            {
                if (libraryItems[i]._itemId == itemId)
                {
                    return libraryItems[i];
                }
            }
            return null;
        }
    }
        
}

