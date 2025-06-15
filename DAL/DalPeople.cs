using MySql.Data.MySqlClient;

namespace Malshinon
{
    class DalPeople : Dal
    {

        public DalPeople(DatabaseManagement database) : base(database) { }

        public Person? Insert(Person p)
        {
            string queryText = @"
            INSERT INTO people (first_name, last_name, secret_code)
            VALUES (@first_name, @last_name, @secret_code);";

            Dictionary<string, object> parametersAndvalue = new() {
                { "@first_name", p.FirstName },
                { "@last_name", p.LastName },
                { "@secret_code", p.SecretCode}};

            MySqlDataReader intelReports = Query(queryText, parametersAndvalue);
            intelReports.Close();
            Console.WriteLine("Person inserted into database.");
            
            Person? _person = GetIdBySecretCode(p.SecretCode);

            if (_person != null)
            {
                return _person;
            }

            return null;
        }

        public List<Person> GetAllPeople()
        {
            List<Person> ListPerson = new();

            MySqlDataReader reader = GetAll("people");

            while (reader.Read())
            {
                ListPerson.Add(Create.CreatingInstancePerson(reader));
            }
            reader.Close();
            return ListPerson;
        }

        public Person? GetPersonById(int id)
        {
            string queryText = $"SELECT * FROM people WHERE people.id = @peopleId ;";

            Dictionary<string, object> parametersAndvalue = new() { { "@peopleId", id } };
            MySqlDataReader intelReports = Query(queryText, parametersAndvalue);
            
            if (intelReports.Read())
            {
                return Create.CreatingInstancePerson(intelReports);
            }
            intelReports.Close();
            return null;
        }

        public Person? GetIdBySecretCode(string secretCode)
        {
            string query = @"SELECT * FROM people WHERE people.secret_code = @secretCode;";

            Dictionary<string, object> parametersAndvalue = new() { { "@secretCode", secretCode } };
            MySqlDataReader intelReports = Query(query, parametersAndvalue);

            if (intelReports.Read())
            {
                return Create.CreatingInstancePerson(intelReports);
            }
            intelReports.Close();
            return null;
        }


    }


}