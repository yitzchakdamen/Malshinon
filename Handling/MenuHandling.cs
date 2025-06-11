using MySql.Data.MySqlClient;


namespace Malshinon
{
    class MenuHandling : HandlingBase
    {
        Tools tools;
        public MenuHandling(DatabaseManagement database) : base(database)
        {
            tools = new Tools(managementPerson, managementIntel);
        }


    }

}