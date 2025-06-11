namespace Malshinon
{
    class Program
    {
        static void Main()
        {
            // Initialize the main class
            Main main = new Main();
            
            // Run the system
            main.Run();
            
            // Keep the console window open
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        
    }
}