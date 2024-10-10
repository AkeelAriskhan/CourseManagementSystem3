using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem
{
    internal class CourseRepository
    {
        private readonly string connectionsting = "Server=(localdb)\\MSSQLLocalDB;database=CourseManagement3;Trusted_Connection=true;TrustServerCertificate=true";

        public void CreateCoursez(string Title, string Duration,decimal Price)
        {
            try
            {
                using (var connection = new SqlConnection(connectionsting))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"insert into Courses (Title,Duration,Price) values(@Title,@Duration,@Price)";
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Duration", Duration);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Course Added sucsessfully");
            }
            catch (Exception ex) 
            {
               Console.WriteLine(ex.Message);
            }
        }
        public void ReadCourses()
        {
            try
            {
                using (var connection = new SqlConnection(connectionsting))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"select * from Courses";
                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Courses list");
                        while (reader.Read())
                        {
                            Console.WriteLine($"CourseId :{reader.GetInt32(0)} Title :{reader.GetString(1)} Duration:{reader.GetString(2)} Price{reader.GetDecimal(3)}");
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
               Console.WriteLine (ex.Message);
            }
        }
        public void Getdatabyid(int id)
        {
            try
            {
                using (var connection = new SqlConnection(connectionsting))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"DELETE FROM  Courses where CourseId=@CourseId ";
                    command.Parameters.AddWithValue("@CourseId", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"CourseId :{reader.GetInt32(0)} Title :{reader.GetString(1)} Duration:{reader.GetString(2)} Price{reader.GetDecimal(3)}");
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateCourse(int id,string Title, string Duration, decimal Price) 
        {
            try
            {
                using (var connection = new SqlConnection(connectionsting))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"UPDATE Courses SET Title=@Title ,Duration=@Duration,Price=@Price where CourseId=@CourseId";
                    command.Parameters.AddWithValue(@"CourseId", id);
                    command.Parameters.AddWithValue(@"Title", Title);
                    command.Parameters.AddWithValue(@"Duration", Duration);
                    command.Parameters.AddWithValue(@"Price", Price);
                    var rowsaffect = command.ExecuteNonQuery();
                    if (rowsaffect > 0)
                    {
                        Console.WriteLine("course updated");
                    }
                    else
                    {
                        Console.WriteLine("course not found");
                    }

                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
      
        }
        public void DeleteCourse(int id) 
        {
            try
            {
                using (var connection = new SqlConnection(connectionsting))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"DELETE from Courses where CourseId=@CourseId";
                    command.Parameters.AddWithValue("CourseId", id);
                    var rowaffect = command.ExecuteNonQuery();

                    if (rowaffect > 0)
                    {
                        Console.WriteLine("Course deleted");
                    }
                    else
                    {
                        Console.WriteLine("course not found");
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        
        }
        public string CapitalizeTitle(string title)
        {
            var words = title.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }
            return string.Join(" ",words);
        }
    }
}
