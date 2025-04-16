using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApp3ByMilanprajapati.Models;

public class StudentController : Controller
{
    private readonly IConfiguration _configuration;
    public StudentController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        List<Student> students = new List<Student>();
        string connStr = _configuration.GetConnectionString("DefaultConnection");

        using (SqlConnection con = new SqlConnection(connStr))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Students", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                students.Add(new Student
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Age = (int)reader["Age"],
                    Faculty = reader["Faculty"].ToString()
                });
            }
        }

        return View(students);
    }

    // Add Create, Edit, Delete actions similarly...
}
