using System.Data;
using MySql.Data.MySqlClient;

namespace Malshinon
{
    static class Create
    {
        static public Person CreatePerson(string firstName, string lastName)
        {
            Person person = new();
            person.FirstName = firstName;
            person.LastName = lastName;
            person.SecretCode = CreateSecretCode();
            return person;
        }
        static public IntelReport CreateIntelReport(string text, int reporterId, int targetId)
        {
            IntelReport report = new();
            report.Text = text;
            report.ReporterId = reporterId;
            report.TargetId = targetId;
            report.Timestamp = DateTime.Now;
            return report;
        }


        static public Alert CreateAlert(int targetId, string reason)
        {
            Alert alert = new();
            alert.TargetId = targetId;
            alert.Reason = reason;
            alert.Timestamp = DateTime.Now;
            return alert;
        }
        static public Alert CreatingInstanceAlert(MySqlDataReader reader)
        {
            Alert alert = new();
            try
            {
                alert.Id = reader.GetInt32("id");
                alert.TargetId = reader.GetInt32("target_id");
                alert.Reason = reader.GetString("reason");
                alert.Timestamp = reader.GetDateTime("timestamp");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return alert;
        }

        static string CreateSecretCode()
        {
            Random r = new Random();
            return $"{(char)r.Next('A', 'Z' + 1)}{(char)r.Next('A', 'Z' + 1)}{(char)r.Next('A', 'Z' + 1)}{Convert.ToString(r.Next(1, 10000))}";
        }


        static public Person CreatingInstancePerson(MySqlDataReader reader)
        {
            Person person = new();
            try
            {
                person.Id = reader.GetInt32("id");
                person.FirstName = reader.GetString("first_name");
                person.LastName = reader.GetString("last_name");
                person.SecretCode = reader.GetString("secret_code");
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
            }
            return person;
        }

        static public PersonStatus CreatingInstancePersonStatus(MySqlDataReader reader)
        {
            PersonStatus personStatus = new();
            try
            {
                personStatus.PeopleId = reader.GetInt32("people_id");
                personStatus.NumReports = reader.GetInt32("num_reports");
                personStatus.NumMentions = reader.GetInt32("num_mentions");
                personStatus.Reporter = reader.GetBoolean("reporter");
                personStatus.Target = reader.GetBoolean("target");
                personStatus.PotentialAgent = reader.GetInt32("potential_agent");
                personStatus.TargetRisk = reader.GetInt32("target_risk");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                reader.Close();
            }
            return personStatus;
        }

        static public IntelReport CreatingInstanceIntelReport(MySqlDataReader reader)
        {
            IntelReport intelReport = new();
            try
            {
                intelReport.Id = reader.GetInt32("id");
                intelReport.ReporterId = reader.GetInt32("reporter_id");
                intelReport.TargetId = reader.GetInt32("target_id");
                intelReport.Timestamp = reader.GetDateTime("timestamp");
                intelReport.Text = reader.GetString("text");
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return intelReport;
        }
    }


}        
        