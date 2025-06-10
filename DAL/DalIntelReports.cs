using MySql.Data.MySqlClient;

namespace Malshinon
{
    class DalIntelReports : Dal
    {
        public DalIntelReports(DatabaseManagement database) : base(database) { }

        public List<IntelReport> GetAllIntelReports()
        {
            List<IntelReport> ListIntelReport = new();

            MySqlDataReader reader = Query("SELECT * FROM intel_reports;");

            while (reader.Read())
            {
                ListIntelReport.Add(Create.CreatingInstanceIntelReport(reader));
            }
            return ListIntelReport;
        }


    }

}