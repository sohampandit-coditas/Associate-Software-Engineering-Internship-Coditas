using System;
using System.Collections.Generic;
using System.Text;
using CSharp;
using student = CSharp.Modules.Module_3.Student;


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
        }
    } 
}
