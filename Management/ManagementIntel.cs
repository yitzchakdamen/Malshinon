using System.Data;
using MySql.Data.MySqlClient;

namespace Malshinon
{
    class ManagementIntel : Management
    {
        public ManagementIntel(DatabaseManagement database) : base(database) { }

        public void AddIntelReports(string text, int personID, int targetId)
        {
            IntelReport report = Create.CreateIntelReport(text, personID, targetId);
            _dalIntelReports.Insert(report);
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
            Dictionary<string, object> parametersAndvalue = new() { { persen, persenId } };
            MySqlDataReader intelReports = _dalIntelReports.Query(Query, parametersAndvalue);

            if (intelReports.Read())
            {
                int numberReports = intelReports.GetInt32("NumberReports");
                intelReports.Close();

                return Convert.ToInt32(numberReports);
            }
            intelReports.Close();
            return 0;
        }

        public int AverageLengthReports(int persenId)
        {
            string Query = @"
            SELECT intel_reports.reporter_id, AVG(LENGTH(intel_reports.text))  as AvgReports
            FROM intel_reports 
            WHERE intel_reports.reporter_id = @reporter_id
            GROUP BY intel_reports.reporter_id;";

            Dictionary<string, object> parametersAndvalue = new() { { "@reporter_id", persenId } };
            MySqlDataReader intelReports = _dalIntelReports.Query(Query, parametersAndvalue);

            if (intelReports.Read())
            {
                double averageLength = intelReports.GetDouble("AvgReports");
                intelReports.Close();

                return Convert.ToInt32(averageLength);
            }
            intelReports.Close();
            return 0;
        }

        public int NumberReportsByTime(DateTime Time, int persenId)
        {
            string Query = @"
            SELECT intel_reports.target_id, COUNT(*) AS NumberReports
            FROM intel_reports 
            WHERE intel_reports.timestamp BETWEEN @timeA AND @timeB AND intel_reports.target_id = @target_id
            GROUP BY intel_reports.target_id;";

            Dictionary<string, object> parametersAndvalue = new() {
                { "@target_id", persenId },
                { "@timeA",  Time.AddMinutes(-15)},
                { "@timeB", Time.AddMinutes(15) }
                };


            MySqlDataReader intelReports = _dalIntelReports.Query(Query, parametersAndvalue);

            if (intelReports.Read())
            {
                int numberReports = intelReports.GetInt32("NumberReports");
                intelReports.Close();
                return Convert.ToInt32(numberReports);
            }
            intelReports.Close();
            return 0;
        }
    }

}