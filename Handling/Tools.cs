namespace Malshinon
{
    class Tools
    {
        private readonly ManagementPerson managementPerson;
        private readonly ManagementIntel managementIntel;
        public Tools(ManagementPerson managementPerson, ManagementIntel managementIntel)
        {
            this.managementPerson = managementPerson;
            this.managementIntel = managementIntel;
        }

        public void AddIntelText(string text, int personID, int targetId)
        {
            managementIntel.AddIntelReports(text, personID, targetId);
        }


        public int HandlingPersonalInformation(string? firstName = null, string? lastName = null, string? secretCode = null)
        {
            int personID = -1;

            if (secretCode != null)
            {
                Person? person = managementPerson._dalPeople.GetIdBySecretCode(secretCode);
                if (person != null)
                {
                    personID = person.Id;
                    Console.WriteLine($"Person found with secret code: {secretCode}, ID: {personID}, Name: {person.FirstName} Last Name: {person.LastName}, Secret Code: {person.SecretCode}");
                }
                else
                    Console.WriteLine($"Person not found with secret code: {secretCode}");
            }
            else if (firstName != null && lastName != null)
            {
                Person? _person = managementPerson.AddPerson(firstName, lastName)!;
                personID = _person.Id;
                Console.WriteLine($"Person created with name: {firstName} {lastName}, ID: {personID}, Secret Code: {_person.SecretCode}");
            }

            return personID;

        }
        
    }
    
}