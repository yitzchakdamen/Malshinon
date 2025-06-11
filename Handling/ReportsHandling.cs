using MySql.Data.MySqlClient;


namespace Malshinon
{
    class ReportsHandling : HandlingBase
    {
        public ReportsHandling(DatabaseManagement database) : base(database){}

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
    }
}