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

        public MySqlDataReader Query(string Query, Dictionary<string,string>? parametersAndValue = null )
        {
            MySqlConnection coon = _database.GetConnction();
            MySqlDataReader reader;
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
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                coon.Close();
            }
        }

    }

}