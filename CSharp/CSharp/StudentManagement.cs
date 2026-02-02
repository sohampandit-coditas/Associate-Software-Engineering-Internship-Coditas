/*using Microsoft.Data.SqlClient;
public class StudentManagement
{
    private readonly string _connectionString;
    public StudentManagement(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void AddStudent(string name,int age, string email)
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();
        var cmd = new SqlCommand("INSERT INTO Students(Name,Age,Email) VALUES(@Name, @Age, @Email)", conn);
        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@Age", age);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.ExecuteNonQuery();
    }

    public void GetStudents()
    {
        using var conn=new SqlConnection(_connectionString);
        conn.Open();
        var cmd = new SqlCommand("SELECT Id, Name,Age, Email, EnrollmentDate FROM Students", conn);
        using var reader=cmd.ExecuteReader();
        while (reader.Read()) {
            Console.WriteLine($"{reader["Id"]} | {reader["Name"]} | {reader["Age"]} | {reader["Email"]} | {reader["EnrollmentDate"]}");
        }
    }

    public void UpdateStudentEmail(int id,string newEmail)
    {
        using var conn=new SqlConnection(_connectionString);
        conn.Open();
        var cmd = new SqlCommand("UPDATE Students SET Email=@Email WHERE Id=@Id",conn);
        cmd.Parameters.AddWithValue("@Email",newEmail);
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.ExecuteNonQuery();
    }

    public void DeleteStudent(int id)
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();
        var cmd = new SqlCommand("DELETE FROM Students WHERE Id=@Id",conn);
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.ExecuteNonQuery();
    }
}*/