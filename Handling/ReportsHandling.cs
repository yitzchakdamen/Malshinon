using MySql.Data.MySqlClient;


namespace Malshinon
{
    class ReportsHandling : HandlingBase
    {
        public ReportsHandling(DatabaseManagement database) : base(database) { }

        public void ViewAllPotentialAgents()
        {
            List<PersonStatus> potentialAgents = managementReports.AllPotentialAgents();
            ViewPersonStatus(potentialAgents);
        }

        public void ViewAllTargetRiskAgents()
        {
            List<PersonStatus> targetRiskAgents = managementReports.AllTargetRisk();
            ViewPersonStatus(targetRiskAgents);
        }

        public void ViewPersonStatus(List<PersonStatus> potentialAgents)
        {
            foreach (var agent in potentialAgents)
            {
                Person? person = managementPerson._dalPeople.GetPersonById(agent.PeopleId);
                int numberReports = managementIntel.NumberReportsByReporter(agent.PeopleId);
                int AvrReports = managementIntel.AverageLengthReports(agent.PeopleId);

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Agent ID       : {agent.PeopleId}");
                Console.WriteLine($"Name           : {person?.FirstName} {person?.LastName}");
                Console.WriteLine($"Secret Code    : {person?.SecretCode}");
                Console.WriteLine($"Risk Level     : {agent.TargetRisk}");
                Console.WriteLine($"Reports Count  : {numberReports}");
                Console.WriteLine($"Avg. Report Len: {AvrReports}");
                Console.WriteLine();
            }
        }

        public void ViewAllAlerts()
        {
            List<Alert> alerts = managementAlerts.GetAllAlertsByList();
            foreach (var alert in alerts)
            {
                Person person = managementPerson._dalPeople.GetPersonById(alert.TargetId)!;

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Alert ID       : {alert.Id}");
                Console.WriteLine($"Timestamp      : {alert.Timestamp}");
                Console.WriteLine($"Description    : {alert.Reason}");
                Console.WriteLine($"Target Name    : {person.FirstName} {person.LastName}");
                Console.WriteLine($"Secret Code    : {person.SecretCode}");
                Console.WriteLine();
            }
        }

        public void AnalysisById(string secretCode)
        {
            int Id = managementPerson._dalPeople.GetIdBySecretCode(secretCode)!.Id;
            Dictionary<string, object> reportData = managementReports.AnalysisById(Id);
            PrintPersonReportSummary(reportData);

        }
        public void PrintPersonReportSummary(Dictionary<string, object> reportData)
        {
            if (reportData == null || reportData.Count == 0)
            {
                Console.WriteLine("No data found for the specified person.");
                return;
            }

            Console.WriteLine("===== Person Report Summary =====");
            Console.WriteLine($"Name: {reportData["firstName"]}  {reportData["lastName"]}");
            Console.WriteLine($"Secret Code: {reportData["secretCode"]}");

            Console.WriteLine();
            Console.WriteLine(" --- Status: ---");
            Console.WriteLine($" - Number of Reports: {reportData["numReports"]}");
            Console.WriteLine($" - Number of Mentions: {reportData["numMentions"]}");
            Console.WriteLine($" - Is Reporter: {BoolToYesNo(reportData["reporter"])}");
            Console.WriteLine($" - Is Target: {BoolToYesNo(reportData["target"])}");
            Console.WriteLine($" - Potential Agent: {BoolToYesNo(reportData["potentialAgent"])}");
            Console.WriteLine($" - Target Risk: {BoolToYesNo(reportData["targetRisk"])}");

            Console.WriteLine();
            Console.WriteLine(" --- Notifications and Reports: --- ");
            Console.WriteLine($" - Number of Notifications: {reportData["contNotifications"]}");
            Console.WriteLine($" - Average Report Length: {reportData["avgReports"]:F2} characters");
            Console.WriteLine("=================================");
        }


        private string BoolToYesNo(object value)
        {
            return Convert.ToBoolean(value) ? "Yes" : "No";
        }


    }
}