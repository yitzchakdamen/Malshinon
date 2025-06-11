using MySql.Data.MySqlClient;


namespace Malshinon
{
    class HandlingBase
    {
        protected ManagementPerson managementPerson;
        protected ManagementIntel managementIntel;
        protected ManagementPeopleStatus managementPeopleStatus;
        protected ManagementAlerts managementAlerts;
        protected ManagementReports managementReports;

        public HandlingBase(DatabaseManagement database)
        {
            managementPerson = new(database);
            managementIntel = new(database);
            managementPeopleStatus = new(database);
            managementAlerts = new(database);
            managementReports = new(database);
        }


    }

}