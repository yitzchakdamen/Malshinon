namespace Malshinon
{
    static class MenuPrint
    {
        public static void ShowHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n===== Malshinon Intelligence System =====");
            Console.ResetColor();
        }
        public static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===== Main Menu =====\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Send Message");
            Console.WriteLine("2. View All Potential Agents");
            Console.WriteLine("3. Manage Alerts");
            Console.WriteLine("4. View Target Risk Agents");
            Console.WriteLine("5. Exit");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nEnter your choice: ");
            Console.ResetColor();
        }

        public static void ShowOption()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nSelect the type of person:");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Secret Code");
            Console.WriteLine("2. First Name and Last Name");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nEnter your choice: ");
            Console.ResetColor();
        }
        
    }
    
}