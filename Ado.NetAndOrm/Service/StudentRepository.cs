using Ado.NetAndOrm.Models;
using Microsoft.Data.SqlClient;

namespace Ado.NetAndOrm.Service
{
    public class StudentRepository
    {
        private readonly string _connectionStr= @"Server=ZYNLVA\SQLEXPRESS;Database=PB305;Trusted_Connection=True;TrustServerCertificate=True;";
        public void Add(Student student)
        {
            using SqlConnection sqlConnection=new SqlConnection(_connectionStr);
            SqlCommand sqlCommand=sqlConnection.CreateCommand();
            sqlCommand.CommandText = $"INSERT INTO Students (Name, Surname, Email) VALUES (@Name, @Surname, @Email)";
            sqlCommand.Parameters.AddWithValue("@Name", student.Name);
            sqlCommand.Parameters.AddWithValue("@Surname", student.Surname);
            sqlCommand.Parameters.AddWithValue("@Email", student.Email);
            sqlConnection.Open();
            int rows = sqlCommand.ExecuteNonQuery();
            if (rows == 0)
            {
                throw new Exception("Data elave edilmedi");
            }
        }
        public void Update(Student student)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionStr);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "UPDATE Students SET Name = @Name, Surname = @Surname, Email = @Email WHERE Id = @Id";

            sqlCommand.Parameters.AddWithValue("@Id", student.Id);
            sqlCommand.Parameters.AddWithValue("@Name", student.Name);
            sqlCommand.Parameters.AddWithValue("@Surname", student.Surname);
            sqlCommand.Parameters.AddWithValue("@Email", student.Email);
            sqlConnection.Open();
            int rows = sqlCommand.ExecuteNonQuery();
            if (rows == 0)
            {
                throw new Exception("Update uğursuz oldu: Belə bir tələbə tapılmadı.");
            }

        }
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using SqlConnection sqlConnection = new SqlConnection(_connectionStr);
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT * FROM Students";
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                students.Add(new Student
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    Email = reader["Email"].ToString()
                });
            }
        return students;

        }
        public void Delete(int id)
        {
            using SqlConnection sqlConnection = new SqlConnection(_connectionStr);
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM Students WHERE Id = @Id";
            sqlCommand.Parameters.AddWithValue("@Id", id);
            sqlCommand.ExecuteNonQuery();

        }
    }
}
