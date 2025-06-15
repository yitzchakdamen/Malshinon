using MySql.Data.MySqlClient;

namespace Malshinon
{
    public class DatabaseManagement
    {
        // static string DbName = "malshinon";
        // static string connectionString = $"Server=Localhost;Port=3306;Database={DbName};User=root;Password='';";
        string connectionString = Environment.GetEnvironmentVariable("connectionString");
        private MySqlConnection _connection;

        public DatabaseManagement Connect()
        {
            var conn = new MySqlConnection(connectionString: connectionString);
            _connection = conn;
            try
            {
                conn.Open();
                Console.WriteLine("Connected to the database successfully.");
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error connecting to the database: {ex.Message}");
            }
            return this;
        }

        public MySqlConnection GetConnction()
        {
            try
            {
                MySqlConnection coon = _connection;
                coon.Open();
                return coon;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error connecting to the database: {ex.Message}");
                throw;
            }
        }
    }

}