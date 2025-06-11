namespace Malshinon
{
    class PersonaHandling
    {
        
        private readonly ManagementPerson managementPerson;
        public PersonaHandling(ManagementPerson managementPerson)
        {
            this.managementPerson = managementPerson;
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
                    Console.WriteLine($"\nPerson found with secret code: {secretCode}, ID: {personID}, Name: {person.FirstName} Last Name: {person.LastName}, Secret Code: {person.SecretCode}");
                }
                else
                    Console.WriteLine($"\nPerson not found with secret code: {secretCode}");
            }
            else if (firstName != null && lastName != null)
            {
                Person? _person = managementPerson.AddPerson(firstName, lastName)!;
                personID = _person.Id;
                Console.WriteLine($"\nPerson created with name: {firstName} {lastName}, ID: {personID}, Secret Code: {_person.SecretCode}");
            }

            return personID;

        }
        
    }
    
}