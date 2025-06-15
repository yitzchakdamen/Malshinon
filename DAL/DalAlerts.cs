using MySql.Data.MySqlClient;

namespace Malshinon
{
    class DalAlerts : Dal
    {

        public DalAlerts(DatabaseManagement database) : base(database){}

        public void Insert(Alert alert)
        {
            string queryText = @"
            INSERT INTO notifications (target_id, Reason, timestamp)
            VALUES (@target_id, @Reason, @timestamp);";

            Dictionary<string, object> parametersAndvalue = new() {
                { "@target_id", alert.TargetId },
                { "@Reason", alert.Reason },
                { "@timestamp", alert.Timestamp },
            };

            MySqlDataReader intelReports = Query(queryText, parametersAndvalue);
            intelReports.Close();

        }

        public List<Alert> GetAllAlerts()
        {
            List<Alert> ListAlerts = new();

            MySqlDataReader reader = GetAll("notifications");


            while (reader.Read())
            {
                ListAlerts.Add(Create.CreatingInstanceAlert(reader));
            }
            reader.Close();
            return ListAlerts;
        }


    }

}