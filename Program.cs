namespace Malshinon
{
    class Program
    {
        static void Main()
        {

            DatabaseManagement database= new DatabaseManagement().Connect();
            new Menu(database).Start();

            // Keep the console window open
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        
    }
}