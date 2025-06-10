using System.Security.Cryptography.X509Certificates;
using MySqlX.XDevAPI.CRUD;

namespace Malshinon
{
    class Management
    {
        protected DalPeople _dalPeople;
        protected DalPeopleStatus _dalPeopleStatus;
        protected DalIntelReports _dalIntelReports;
        public Management(DatabaseManagement database)
        {
            _dalPeople = new(database);
            _dalPeopleStatus = new(database);
            _dalIntelReports = new(database);
        }

    }
    
}