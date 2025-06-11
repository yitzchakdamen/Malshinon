using MySql.Data.MySqlClient;

namespace Malshinon
{
    class DalPeopleStatus : Dal
    {

        public DalPeopleStatus(DatabaseManagement database) : base(database) { }

        public void Update(int peopleId, string columnName, object newValue)
        {
            string queryText = $"UPDATE people_status SET {columnName} = @newValue WHERE people_status.people_id = @peopleId;";

            Dictionary<string, object> parametersAndvalue = new() { { "@newValue", newValue }, {"@peopleId", peopleId} };
            MySqlDataReader intelReports = Query(queryText, parametersAndvalue);
            intelReports.Close();
        }


        public void Insert(int Id)
        {
            string queryText = @"
            INSERT INTO people_status (people_id)
            VALUES (@people_id);";

            Dictionary<string, object> parametersAndvalue = new() { { "@people_id", Id } };
            MySqlDataReader intelReports = Query(queryText, parametersAndvalue);
            intelReports.Close();

        }

    }

}