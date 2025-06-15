namespace Malshinon
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            EnvReader.Load(@"C:\Users\isaac\source\repos\Malshinon\EnvReader\config.env");
            
            DatabaseManagement database= new DatabaseManagement().Connect();
            new Menu(database).Start();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        
    }
}
