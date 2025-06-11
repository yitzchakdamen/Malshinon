using MySql.Data.MySqlClient;


namespace Malshinon
{
    class DalIntelReports : Dal
    {
        public DalIntelReports(DatabaseManagement database) : base(database) { }


        public void Insert(IntelReport intelReport)
        {
            string queryText = @"
            INSERT INTO intel_reports (reporter_id, target_id, text, timestamp)
             VALUES (@reporter_id, @target_id, @text, @timestamp);";

            Dictionary<string, object> parametersAndvalue = new() {
                { "@reporter_id", intelReport.ReporterId },
                { "@target_id", intelReport.TargetId },
                { "@text", intelReport.Text},
                { "@timestamp", intelReport.Timestamp},
                };

            MySqlDataReader intelReports = Query(queryText, parametersAndvalue);
            intelReports.Close();

        }

        public List<IntelReport> GetAllIntelReports()
        {
            List<IntelReport> ListIntelReport = new();

            MySqlDataReader reader = GetAll("intel_reports");


            while (reader.Read())
            {
                ListIntelReport.Add(Create.CreatingInstanceIntelReport(reader));
            }
            reader.Close();
            return ListIntelReport;
        }


    }

}
