using MySql.Data.MySqlClient;

namespace Malshinon
{
    class DalIntelReports
    {
        DatabaseManagement _database;
        public DalIntelReports(DatabaseManagement database)
        {
            _database = database;
        }

        public List<Person> Query(string Query, List<string>? parameters = null, List<string>? value = null)
        {
            List<Person> ListPerson = new();
            MySqlConnection coon = _database.GetConnction();
            MySqlDataReader reader;
            MySqlCommand cmd = coon.CreateCommand();

            cmd.CommandText = Query;
            
            if (parameters != null && value != null && parameters.Count == value.Count)
            {
                for (int i = 0; i < parameters.Count; i++)
                    cmd.Parameters.AddWithValue(parameters[0], value[0]);
            }

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListPerson.Add(Create.CreatingInstance(reader));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                coon.Close();
            }
            return ListPerson;
        }

    }

}