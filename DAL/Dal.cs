using System.Data;
using MySql.Data.MySqlClient;

namespace Malshinon
{
    class Dal
    {
        DatabaseManagement _database;
        public Dal(DatabaseManagement database)
        {
            _database = database;
        }

        public MySqlDataReader Query(string Query, Dictionary<string, object>? parametersAndValue = null)
        {
            MySqlConnection coon = _database.GetConnction();
            MySqlCommand cmd = coon.CreateCommand();

            cmd.CommandText = Query;

            if (parametersAndValue != null)
            {
                foreach (var item in parametersAndValue)
                {
                    cmd.Parameters.AddWithValue(item.Key, item.Value);
                }
            }
            try
            {
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error executing query: " + Query);
                Console.WriteLine(ex.Message);
                throw;
            }

        }
        public MySqlDataReader GetById(int peopleId, string tableName)
        {
            string queryText = $"SELECT * FROM {tableName} WHERE {tableName}.people_id = @peopleId ;";

            Dictionary<string, object> parametersAndvalue = new() { { "@peopleId", peopleId } };
            MySqlDataReader intelReports = Query(queryText, parametersAndvalue);
            return intelReports;
        }

        public MySqlDataReader GetAll(string tableName)
        {
            string queryText = $"SELECT * FROM {tableName};";
            return Query(queryText);
        }

    }

}