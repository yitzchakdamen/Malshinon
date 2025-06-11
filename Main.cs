using MySql.Data.MySqlClient;

namespace Malshinon
{
    class Main
    {
        DatabaseManagement Database;
        MessageHandling system;

        public void Initialization()
        {
            Database = new DatabaseManagement().Connect();
            system = new(Database);
        }

        public void Run()
        {
            Initialization();
            system.SendMessage(
                firstNamePerson: "aaaaaa",
                lastNamePerson: "Doe",
                firstNametarget: "Jane",
                lastNametarget: "gggggggg",
                messageText: "Hello, this is a test message."
            );
        }

    }
    
}