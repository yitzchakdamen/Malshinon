using MySql.Data.MySqlClient;


namespace Malshinon
{
    class MessageHandling : HandlingBase
    {
        Tools tools;
        public MessageHandling(DatabaseManagement database) : base(database)
        {
            tools = new Tools(managementPerson, managementIntel);
        }

        public void SendMessage(
            string? firstNamePerson = null,
            string? lastNamePerson = null,
            string? secretCodePerson = null,
            string? firstNametarget = null,
            string? lastNametarget = null,
            string? secretCodetarget = null,
            string? messageText = null
            )
        {
            var peopleIds = People(firstNamePerson, lastNamePerson, secretCodePerson, firstNametarget, lastNametarget, secretCodetarget);
            if (peopleIds == null || messageText == null)
                return;

            Messages(peopleIds.Value.personID, peopleIds.Value.targetId, messageText);
            UpdateStatus(peopleIds.Value.personID, peopleIds.Value.targetId);
            Analysis(peopleIds.Value.personID, peopleIds.Value.targetId, DateTime.Now);
        }


        public (int personID, int targetId)? People(
            string? firstNamePerson = null,
            string? lastNamePerson = null,
            string? secretCodePerson = null,
            string? firstNametarget = null,
            string? lastNametarget = null,
            string? secretCodetarget = null
            )
        {
            int personID = tools.HandlingPersonalInformation(firstNamePerson, lastNamePerson, secretCodePerson);
            int targetId = tools.HandlingPersonalInformation(firstNametarget, lastNametarget, secretCodetarget);
            if (personID < 0 || targetId < 0)
                return null;

            return (personID, targetId);
        }

        public void UpdateStatus(int personID, int targetId)
        {
            managementPeopleStatus.UpdateNumMentions(personID);
            managementPeopleStatus.UpdateReporter(personID, true);

            managementPeopleStatus.UpdateNumReports(targetId);
            managementPeopleStatus.UpdateTarget(targetId, true);

            Console.WriteLine($"Status updated for Person ID: {personID} and Target ID: {targetId}");
        }

        public void Messages(int personID, int targetId, string messageText)
        {
            managementIntel.AddIntelReports(messageText, personID, targetId);
            Console.WriteLine($"Message sent from Person ID: {personID} to Target ID: {targetId} with text: {messageText}");
        }

        public void Analysis(int personID, int targetId, DateTime data)
        {
            int averageLength = managementIntel.AverageLengthReports(personID);
            int numberReportsByReporter = managementIntel.NumberReportsByReporter(personID);
            int numberReportsByTarget = managementIntel.NumberReportsByTarget(targetId);
            int NumberReportsByTime = managementIntel.NumberReportsByTime(data, targetId);

            if (averageLength >= 100)
                managementAlerts.AddAlert(personID, "Suspiciously long message detected.");
            

            if (numberReportsByReporter >= 10)
                managementAlerts.AddAlert(personID, "Suspicious activity detected based on message analysis.");

            if (numberReportsByTarget >= 20)
                managementAlerts.AddAlert(targetId, "High number of reports detected for this target.");

            if (NumberReportsByTime >= 5)
                managementAlerts.AddAlert(targetId, "Multiple reports received within a short time frame.");
            
            if (averageLength >= 100 || numberReportsByReporter >= 10)
            {
                PersonStatus? personStatus = managementPerson._dalPeopleStatus.GetPersonStatusById(personID);
                if (personStatus.PotentialAgent == 0)
                {
                    managementPeopleStatus.UpdatePotentialAgent(personID, 1);
                    managementAlerts.AddAlert(personID, "Potential agent status updated based on message analysis.");
                    Console.WriteLine($"Potential agent status updated for Person ID: {personID} based on message analysis. Number of reports: {numberReportsByReporter} .");
                }
            }
            else
            {
                managementPeopleStatus.UpdatePotentialAgent(personID, 0);
            }

            if (numberReportsByTarget >= 20 && NumberReportsByTime >= 5)
            {
                PersonStatus? targetStatus = managementPerson._dalPeopleStatus.GetPersonStatusById(targetId);
                if (targetStatus.TargetRisk == 0)
                {
                    managementPeopleStatus.UpdateTargetRisk(targetId, 1);
                    managementAlerts.AddAlert(targetId, "Target risk status updated based on message analysis.");
                    Console.WriteLine($"Target risk status updated for Target ID: {targetId} based on message analysis. Number of reports: {numberReportsByTarget} .");
                }
            }
            else
            {
                managementPeopleStatus.UpdateTargetRisk(targetId, 0);
            }
            Console.WriteLine($"Analysis complete for Person ID: {personID} and Target ID: {targetId}");

        }
    }

}