/*using Microsoft.Data.SqlClient;
public class App
{
   public static void Main(string[] args)
    {
        string connectionString = "Server=localhost;Database=StudentManagement;Trusted_Connection=True;TrustServerCertificate=True;";
        StudentManagement repo = new StudentManagement(connectionString);
        while (true)
        {
            Console.WriteLine("--- Student Management System ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. List Students");
            Console.WriteLine("3. Update Student Email");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");
            int choice=Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Age: ");
                    int age=Convert.ToInt32 (Console.ReadLine());
                    Console.Write("Email: ");
                    string email= Console.ReadLine();
                    repo.AddStudent(name, age, email);
                    break;

                case 2:
                    repo.GetStudents();
                    break;

                case 3:
                    Console.Write("Enter the Student Id to update: ");
                    int idToUpdate= Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the email to be updated: ");
                    string email1=Console.ReadLine();
                    repo.UpdateStudentEmail(idToUpdate,email1);
                    break;

                case 4:
                    Console.WriteLine("Enter the student id to be deleted: ");
                    int idToBeDeleted= Convert.ToInt32(Console.ReadLine());
                    repo.DeleteStudent(idToBeDeleted);
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;

            }
        }
    }
}*/