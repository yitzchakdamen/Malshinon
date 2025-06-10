using System.Security.Cryptography.X509Certificates;
using MySqlX.XDevAPI.CRUD;

namespace Malshinon
{
    class ManagementPerson
    {
        DalPeople _dalPeople;
        DalPeopleStatus _dalPeopleStatus;
        public ManagementPerson(DatabaseManagement database)
        {
            _dalPeople = new(database);
            _dalPeopleStatus = new(database);
        }

        public Person AddPerson(string firstName, string lastName)
        {
            Person _person = _dalPeople.Insert(Create.CreatePerson(firstName, lastName));
            _dalPeopleStatus.Insert(_person.Id);
            return _person;
        }

        public Person? GetIdBySecretCode(string secretCode)
        {
            return _dalPeople.GetIdBySecretCode(secretCode);
        }
        
    }
    
}