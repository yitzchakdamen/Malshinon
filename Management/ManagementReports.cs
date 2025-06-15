using MySql.Data.MySqlClient;

namespace Malshinon
{
    class ManagementReports : Management
    {

        public ManagementReports(DatabaseManagement database) : base(database) { }

        public List<PersonStatus> AllPotentialAgents()
        {
            // string queryText = @"SELECT people.first_name, people.last_name, people_status.num_mentions, people_status.num_reports 
            //                     FROM people_status 
            //                     JOIN people ON people.id = people_status.people_id
            //                     WHERE people_status.potential_agent = 1;";

            string queryText = @"SELECT * FROM people_status WHERE people_status.potential_agent = 1;";

            List<PersonStatus> ListPersonStatus = new();
            MySqlDataReader reader = _dalPeopleStatus.Query(queryText);

            while (reader.Read())
            {
                ListPersonStatus.Add(Create.CreatingInstancePersonStatus(reader));
            }
            reader.Close();
            return ListPersonStatus;

        }

        public List<PersonStatus> AllTargetRisk()
        {
            string queryText = "SELECT * FROM people_status WHERE people_status.target_risk = 1;";

            List<PersonStatus> ListPersonStatus = new();
            MySqlDataReader reader = _dalPeopleStatus.Query(queryText);

            while (reader.Read())
            {
                ListPersonStatus.Add(Create.CreatingInstancePersonStatus(reader));
            }
            reader.Close();
            return ListPersonStatus;

        }

        public Dictionary<string, object> AnalysisById(int persenId)
        {
            string Query = @"
            SELECT people.first_name, people.last_name, people.secret_code,
                people_status.num_reports, people_status.num_mentions, people_status.reporter,
                people_status.target, people_status.potential_agent, people_status.target_risk,
                COUNT(n.id) AS ContNotifications,
                AVG(CHAR_LENGTH(r.text)) AS AvgReports
            FROM people
            JOIN intel_reports r ON people.id = r.reporter_id
            JOIN people_status ON people_status.people_id = people.id
            LEFT JOIN notifications n ON people.id = n.target_id
            WHERE people.id = @persenId
            GROUP BY people.id, people.first_name, people.last_name, people.secret_code,
                    people_status.num_reports, people_status.num_mentions, people_status.reporter,
                    people_status.target, people_status.potential_agent, people_status.target_risk;";

            Dictionary<string, object> parametersAndvalue = new() { { "@persenId", persenId } };
            MySqlDataReader intelReports = _dalIntelReports.Query(Query, parametersAndvalue);

            Dictionary<string, object> Analysis = new();
            if (intelReports.Read())
            {
                Analysis["firstName"] = intelReports["first_name"];
                Analysis["lastName"] = intelReports["last_name"];
                Analysis["secretCode"] = intelReports["secret_code"];
                Analysis["numReports"] = intelReports["num_reports"];
                Analysis["numMentions"] = intelReports["num_mentions"];
                Analysis["reporter"] = intelReports["reporter"];
                Analysis["target"] = intelReports["target"];
                Analysis["potentialAgent"] = intelReports["potential_agent"];
                Analysis["targetRisk"] = intelReports["target_risk"];
                Analysis["contNotifications"] = intelReports["ContNotifications"];
                Analysis["avgReports"] = intelReports["AvgReports"];
            }

            intelReports.Close();
            return Analysis;
        }


    }
        

}

    
