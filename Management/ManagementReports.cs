using MySql.Data.MySqlClient;

namespace Malshinon
{
    class ManagementReports : Management
    {

        public ManagementReports(DatabaseManagement database) : base(database) { }

        public List<PersonStatus> AllPotentialAgents()
        {
            string queryText = "SELECT * FROM people_status WHERE people_status.potential_agent = 1;";
           
            List<PersonStatus> ListPersonStatus = new();
            MySqlDataReader reader = _dalPeopleStatus.Query(queryText);

            while (reader.Read())
            {
                ListPersonStatus.Add(Create.CreatingInstancePersonStatus(reader));
            }
            reader.Close();
            return ListPersonStatus;

        }


    }
        

}

    
