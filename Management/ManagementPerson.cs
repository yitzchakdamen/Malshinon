using MySql.Data.MySqlClient;

namespace Malshinon
{
    class ManagementPerson : Management
    {

        public ManagementPerson(DatabaseManagement database) : base(database) { }

        public Person? AddPerson(string firstName, string lastName)
        {
            Person? _person = _dalPeople.Insert(Create.CreatePerson(firstName, lastName));
            if (_person != null)
                 _dalPeopleStatus.Insert(_person.Id);
            return _person;
        }
        
    }
    
}