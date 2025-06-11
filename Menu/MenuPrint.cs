namespace Malshinon
{
    static class MenuPrint
    {
        static public void ShowMenu()
        {
            Console.WriteLine("1. Send Message");
            Console.WriteLine("2. View All Potential Agents");
            Console.WriteLine("3. Manage Alerts");
            Console.WriteLine("4. Exit");
        }
        public static void ShowOption()
        {
            Console.WriteLine("Select the type of person:");
            Console.WriteLine("1. Secret Code");
            Console.WriteLine("2. First Name and Last Name");
            Console.Write("Enter your choice: ");
        }
        
    }
    
}