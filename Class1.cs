using System;
using System.Data.SqlClient;

public class database
{
    public void Database()
    {
        SqlConnection sqlConnection;
        string sqlDatabase = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\renzo\OneDrive\Desktop\dict\GameCharaCreation\GameCharaCreation\Database1.mdf;Integrated Security=True";

        try
        {
            SqlConnection newSqlDatabase = new SqlConnection(sqlDatabase);
            newSqlDatabase.Open();
            Console.WriteLine("name");
            string name = Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Nes: {ex.Message}");
        }
    }
}