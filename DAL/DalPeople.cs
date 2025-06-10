using MySql.Data.MySqlClient;

namespace Malshinon
{
    class DalPeople
    {
        DatabaseManagement _database;
        public DalPeople(DatabaseManagement database)
        {
            _database = database;
        }

        public List<Person> GetByQuery(string Query, string? parameters = null, string? value = null)
        {
            List<Person> ListPerson = new();
            MySqlConnection coon = _database.GetConnction();
            MySqlDataReader reader;
            MySqlCommand cmd = coon.CreateCommand();

            cmd.CommandText = Query;
            if (parameters != null)
                cmd.Parameters.AddWithValue(parameters, value);

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListPerson.Add(Create.CreatingInstancePerson(reader));
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

        public Person Insert(Person p)
        {
            MySqlConnection coon = _database.GetConnction();
            MySqlDataReader reader;
            MySqlCommand cmd = coon.CreateCommand();
            cmd.CommandText = @"
            INSERT INTO people (first_name, last_name, secret_code)
             VALUES (@first_name, @last_name, @secret_code);";

            cmd.Parameters.AddWithValue("@first_name", p.FirstName);
            cmd.Parameters.AddWithValue("@last_name", p.LastName);
            cmd.Parameters.AddWithValue("@secret_code", p.SecretCode);

            try
            {
                reader = cmd.ExecuteReader();
                reader.Read();
                return Create.CreatingInstancePerson(reader);
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
        public Person? GetIdBySecretCode(string secretCode)
        {
            string query = $"SELECT * FROM people WHERE people.secret_code = '{secretCode}':";
            List<Person> people = GetByQuery(query);

            if (people.Count == 1)
                return people[0];

            return null;
        }

        
    }


}