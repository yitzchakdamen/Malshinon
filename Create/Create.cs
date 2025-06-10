using MySql.Data.MySqlClient;

namespace Malshinon
{
    static class Create
    {
        static public Person CreatePerson(string firstName, string lastName)
        {
            Person person = new();
            person.FirstName = firstName;
            person.LastName = lastName;
            person.SecretCode = CreateSecretCode();
            return person;
        }

        static string CreateSecretCode()
        {
            return Convert.ToString(new Random().Next(1, 10000));
        }


        static public Person CreatingInstance(MySqlDataReader reader)
        {
            Person person = new();
            try
            {
                person.Id = reader.GetInt32("id");
                person.FirstName = reader.GetString("first_name");
                person.LastName = reader.GetString("last_name");
                person.SecretCode = reader.GetString("secret_code");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return person;
        }
    }


}        
        