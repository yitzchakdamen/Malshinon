using MySql.Data.MySqlClient;

namespace Malshinon
{
    class ManagementPeopleStatus : Management
    {

        public ManagementPeopleStatus(DatabaseManagement database) : base(database) { }


        public void UpdateNumReports(int peopleId)
        {
            string queryText = $"UPDATE people_status SET num_reports = num_reports + 1 WHERE people_status.people_id = @peopleId;";

            Dictionary<string, object> parametersAndvalue = new() { { "@peopleId", peopleId } };
            MySqlDataReader intelReports = _dalPeopleStatus.Query(queryText, parametersAndvalue);
            intelReports.Close();
        }

        public void UpdateNumMentions(int peopleId)
        {
            string queryText = $"UPDATE people_status SET num_mentions = num_mentions + 1 WHERE people_status.people_id = @peopleId;";

            Dictionary<string, object> parametersAndvalue = new() { { "@peopleId", peopleId } };
            MySqlDataReader intelReports = _dalPeopleStatus.Query(queryText, parametersAndvalue);
            intelReports.Close();
        }

        public void UpdateReporter(int peopleId, bool newValue)
        {
            _dalPeopleStatus.Update(peopleId, "reporter", newValue);
        }

        public void UpdateTarget(int peopleId, bool newValue)
        {
            _dalPeopleStatus.Update(peopleId, "target", newValue);
        }

        public void UpdatePotentialAgent(int peopleId, int newValue)
        {
            _dalPeopleStatus.Update(peopleId, "potential_agent", newValue);
        }

        public void UpdateTargetRisk(int peopleId, int newValue)
        {
            _dalPeopleStatus.Update(peopleId, "target_risk", newValue);
        }
        
    }
    
}