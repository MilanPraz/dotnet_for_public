using System;
using System.Data.SQLite;

class Program
{
    static string connectionString = "Data Source=students.db;Version=3;";

    static void Main()
    {
        CreateTable();
        InsertStudent("Milan", 21, "CSIT");
        ReadStudents();
        UpdateStudent(1, "Milan Updated", 22);
        DeleteStudent(1);
    }

    static void CreateTable()
    {
        using var con = new SQLiteConnection(connectionString);
        con.Open();
        var cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Students (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Age INT, Faculty TEXT)", con);
        cmd.ExecuteNonQuery();
        Console.WriteLine("✅ Table ensured.");
    }

    static void InsertStudent(string name, int age, string faculty)
    {
        using var con = new SQLiteConnection(connectionString);
        con.Open();
        var cmd = new SQLiteCommand("INSERT INTO Students (Name, Age, Faculty) VALUES (@name, @age, @faculty)", con);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@age", age);
        cmd.Parameters.AddWithValue("@faculty", faculty);
        cmd.ExecuteNonQuery();
        Console.WriteLine("✅ Student inserted.");
    }

    static void ReadStudents()
    {
        using var con = new SQLiteConnection(connectionString);
        con.Open();
        var cmd = new SQLiteCommand("SELECT * FROM Students", con);
        using var reader = cmd.ExecuteReader();
        Console.WriteLine("📋 Students List:");
        while (reader.Read())
        {
            Console.WriteLine($"{reader["ID"]}: {reader["Name"]}, Age {reader["Age"]}, Faculty: {reader["Faculty"]}");
        }
    }

    static void UpdateStudent(int id, string newName, int newAge)
    {
        using var con = new SQLiteConnection(connectionString);
        con.Open();
        var cmd = new SQLiteCommand("UPDATE Students SET Name = @name, Age = @age WHERE ID = @id", con);
        cmd.Parameters.AddWithValue("@name", newName);
        cmd.Parameters.AddWithValue("@age", newAge);
        cmd.Parameters.AddWithValue("@id", id);
        var rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"🛠 Updated {rows} row(s).");
    }

    static void DeleteStudent(int id)
    {
        using var con = new SQLiteConnection(connectionString);
        con.Open();
        var cmd = new SQLiteCommand("DELETE FROM Students WHERE ID = @id", con);
        cmd.Parameters.AddWithValue("@id", id);
        var rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"🗑 Deleted {rows} row(s).");
    }
}
