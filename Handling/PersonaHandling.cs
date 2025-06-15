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
                personID = CheckingPerson(secretCode);
            }
            else if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                personID = CreatingPerson(firstName, lastName);
            }
            return personID;

        }
        public int CheckingPerson(string secretCode)
        {
            Person? person = managementPerson._dalPeople.GetIdBySecretCode(secretCode);
            if (person != null)
            {
                Console.WriteLine($"\nPerson found with secret code: {secretCode}, ID: {person.Id}, Name: {person.FirstName} Last Name: {person.LastName}, Secret Code: {person.SecretCode}");
                return person.Id;
            }
            else
                Console.Clear();
                Console.WriteLine($"\nPerson not found with secret code: {secretCode}");
            return -1;

        }
        public int CreatingPerson(string firstName, string lastName)
        {
            Person? _person = managementPerson.AddPerson(firstName, lastName)!;
            Console.WriteLine($"\nPerson created with name: {firstName} {lastName}, ID: {_person.Id}, Secret Code: {_person.SecretCode}");
            return _person.Id;
        }

    }
    
}