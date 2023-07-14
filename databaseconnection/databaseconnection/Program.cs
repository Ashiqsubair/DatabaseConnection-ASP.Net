using System;
using System.Data;
using MySqlConnector;

class Program
{
    static void Main(string[] args)
    {
        string connStr = "server=localhost;user=root;database=sys;port=3306;password=root";
        string sql = "SELECT * FROM employee";
        try
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            Console.WriteLine("Connecting to the database");
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt16(0)}, {reader.GetString(1)}");
            }

            reader.Close();
            conn.Close();

            Console.WriteLine("Connection closed");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
