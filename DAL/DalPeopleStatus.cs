using MySql.Data.MySqlClient;

namespace Malshinon
{
    class DalPeopleStatus
    {
        DatabaseManagement _database;
        public DalPeopleStatus(DatabaseManagement database)
        {
            _database = database;
        }

        public void Insert(int Id)
        {
            MySqlConnection coon = _database.GetConnction();
            MySqlDataReader reader;
            MySqlCommand cmd = coon.CreateCommand();
            cmd.CommandText = @"
            INSERT INTO people_status (people_id)
             VALUES (@people_id);";

            cmd.Parameters.AddWithValue("@people_id", Id);

            try
            {
                reader = cmd.ExecuteReader();
                return;
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

        // private PersonStatus CreatingInstance(MySqlDataReader reader)
        // {
        //     PersonStatus status = new();
        //     try
        //     {
        //         // status.
        //         // person.Id = reader.GetInt32("id");
        //         // person.FirstName = reader.GetString("first_name");
        //         // person.LastName = reader.GetString("last_name");
        //         // person.SecretCode = reader.GetString("secret_code");
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine(ex.Message);
        //     }
        //     return status;
        // }


    }

}