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

        public void SendMessage(int personID, int targetId, string messageText)
        {
            Messages(personID, targetId, messageText);
            UpdateStatus(personID, targetId);
            analysisHandling.Analysis(personID, targetId, DateTime.Now);
        }


        public int? PeopleHandling((string? firstNamePerson, string? lastNamePerson, string? secretCodePerson) information)
        {
            int personID = personaHandling.HandlingPersonalInformation(information.firstNamePerson, information.lastNamePerson, information.secretCodePerson);
            if (personID < 0)
                return null;

            return personID;
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