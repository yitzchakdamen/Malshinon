using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Misc;
using Org.BouncyCastle.Asn1.Pkcs;

namespace Malshinon
{
    class System
    {
        ManagementPerson managementPerson;
        ManagementIntel managementIntel;

        public System(DatabaseManagement database)
        {
            managementPerson = new(database);
            managementIntel = new(database);
        }

        public Boolean Add(
            string text,
            string? firstNamePerson = null,
            string? lastNamePerson = null,
            string? secretCodePerson = null,
            string? firstNametarget = null,
            string? lastNametarget = null,
            string? secretCodetarget = null
            )
        {
            int personID = Person(firstNamePerson, lastNamePerson, secretCodePerson);
            int targetId = Terget(firstNametarget, lastNametarget, secretCodetarget);
            if (personID < 0 || targetId < 0)
                return false;

            managementIntel.AddIntelReports(text, personID, targetId);
            return true;
        }

        public int Person(string? firstName = null, string? lastName = null, string? secretCode = null)
        {
            return GetPersonId(firstName, lastName, secretCode);
        }

        public int Terget(string? firstName = null, string? lastName = null, string? secretCode = null)
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
                Person? person = managementPerson.GetIdBySecretCode(secretCode);
                if (person != null)
                    personID = person.Id;
            }   
            else if (firstName != null && lastName != null)
                personID = managementPerson.AddPerson(firstName, lastName).Id;

            return personID;

        }

    }
    
}