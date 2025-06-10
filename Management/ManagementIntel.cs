using MySql.Data.MySqlClient;

namespace Malshinon
{
    class ManagementIntel : Management
    {
        public ManagementIntel(DatabaseManagement database) : base(database) { }

        public void AddIntelReports(string text, int personID, int targetId)
        {

        }

        public int NumberReportsByReporter(int persenId)
        {
            string Query = @"
            SELECT intel_reports.reporter_id, COUNT(*) AS NumberReports 
            FROM intel_reports 
            WHERE intel_reports.reporter_id = @reporter_id
            GROUP BY intel_reports.reporter_id;";
            return NumberReports(Query, persenId, "@reporter_id");
        }

        public int NumberReportsByTarget(int persenId)
        {
            string Query = @"
            SELECT intel_reports.target_id, COUNT(*) AS NumberReports 
            FROM intel_reports 
            WHERE intel_reports.target_id = @target_id
            GROUP BY intel_reports.target_id;";
            return NumberReports(Query, persenId, "@target_id");

        }
        int NumberReports(string Query, int persenId, string persen)
        {
            Dictionary<string, string> parametersAndvalue = new() { { persen, Convert.ToString(persenId) } };
            MySqlDataReader intelReports = _dalIntelReports.Query(Query, parametersAndvalue);

            if (intelReports.Read())
            {
                return Convert.ToInt32(intelReports.GetString("NumberReports"));
            }
            return 0;
        }

        public int averageLengthReports(int persenId)
        {
            string Query = @"
            SELECT intel_reports.reporter_id, AVG(LENGTH(intel_reports.text))  as AvgReports
            FROM intel_reports 
            WHERE intel_reports.reporter_id = @reporter_id
            GROUP BY intel_reports.reporter_id;";

            Dictionary<string, string> parametersAndvalue = new() { { "@reporter_id", Convert.ToString(persenId) } };
            MySqlDataReader intelReports = _dalIntelReports.Query(Query, parametersAndvalue);
            intelReports.Read();


            if (intelReports.Read())
            {
                return Convert.ToInt32(intelReports.GetString("AvgReports"));
            }
            return 0;
        }
        
        public int NumberReportsByTime(DateTime Time, int persenId)
        {
            string Query = @"
            SELECT intel_reports.target_id, COUNT(*) AS NumberReports
            FROM intel_reports 
            WHERE intel_reports.timestamp BETWEEN @timeA AND @timeB AND intel_reports.target_id = @target_id
            GROUP BY intel_reports.target_id;";

            Dictionary<string, string> parametersAndvalue = new() {
                 { "@reporter_id", Convert.ToString(persenId) },
                 { "@timeA",  Time.AddMinutes(-15).ToString()},
                 { "@timeB", Time.AddMinutes(15).ToString() }
                 }; 


            MySqlDataReader intelReports = _dalIntelReports.Query(Query, parametersAndvalue);
            intelReports.Read();

            if (intelReports.Read())
            {
                return Convert.ToInt32(intelReports.GetString("NumberReports"));
            }
            return 0;
        }


    }

}