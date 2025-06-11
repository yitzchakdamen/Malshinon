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

        public int Person(string? firstName = null, string? lastName = null, string? secretCode = null)
        {
            return GetPersonId(firstName, lastName, secretCode);
        }

        public int Target(string? firstName = null, string? lastName = null, string? secretCode = null)
        {
            return GetPersonId(firstName, lastName, secretCode);
        }

        public void AddIntelText(string text, int personID, int targetId)
        {
            managementIntel.AddIntelReports(text, personID, targetId);
        }


        public int GetPersonId(string? firstName = null, string? lastName = null, string? secretCode = null)
        {
            int personID = -1;

            if (secretCode != null)
            {
                Person? person = managementPerson._dalPeople.GetIdBySecretCode(secretCode);
                if (person != null)
                    personID = person.Id;
            }   
            else if (firstName != null && lastName != null)
                personID = managementPerson.AddPerson(firstName, lastName)!.Id;

            return personID;

        }
        
    }
    
}