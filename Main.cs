using MySql.Data.MySqlClient;

namespace Malshinon
{
    class Main
    {
        DatabaseManagement Database;

        public void Initialization()
        {
            Database = new DatabaseManagement().Connect();
        }

        public void Run()
        {
            Initialization();
            new MenuHandling(Database).Start();

        }

    }
    
}