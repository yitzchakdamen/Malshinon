using MySql.Data.MySqlClient;


namespace Malshinon
{
    class MessageHandling : HandlingBase
    {
        PersonaHandling personaHandling;
        AnalysisHandling analysisHandling;
        public MessageHandling(DatabaseManagement database) : base(database)
        {
            personaHandling = new PersonaHandling(managementPerson);
            analysisHandling = new AnalysisHandling(database);
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
            analysisHandling.Analysis(peopleIds.Value.personID, peopleIds.Value.targetId, DateTime.Now);
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
            int personID = personaHandling.HandlingPersonalInformation(firstNamePerson, lastNamePerson, secretCodePerson);
            int targetId = personaHandling.HandlingPersonalInformation(firstNametarget, lastNametarget, secretCodetarget);
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

            Console.WriteLine($"\nStatus updated for Person ID: {personID} and Target ID: {targetId}");
        }

        public void Messages(int personID, int targetId, string messageText)
        {
            managementIntel.AddIntelReports(messageText, personID, targetId);
            Console.WriteLine($"\nMessage sent from Person ID: {personID} to Target ID: {targetId} with text: {messageText}");
        }
    }

}