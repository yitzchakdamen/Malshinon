using MySql.Data.MySqlClient;

namespace Malshinon
{
    class Main
    {
        DatabaseManagement Database;
        System system;

        public void Initialization()
        {
            Database = new DatabaseManagement().Connect();
            system = new(Database);
        }

    }
    
}