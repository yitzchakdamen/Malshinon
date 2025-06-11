using System.Security.Cryptography.X509Certificates;
using MySqlX.XDevAPI.CRUD;

namespace Malshinon
{
    class Management
    {
        public DalPeople _dalPeople;
        public DalPeopleStatus _dalPeopleStatus;
        public DalIntelReports _dalIntelReports;
        public DalAlerts _dalAlerts;

        public Management(DatabaseManagement database)
        {
            _dalPeople = new(database);
            _dalPeopleStatus = new(database);
            _dalIntelReports = new(database);
            _dalAlerts = new(database);
        }

    }
    
}