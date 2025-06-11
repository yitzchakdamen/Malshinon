namespace Malshinon
{
    class Menu
    {
        MenuHandling menuHandling;
        ReportsHandling reportsHandling;
        MessageHandling messageHandling;
        public Menu(DatabaseManagement database)
        {
            menuHandling = new(database);
            reportsHandling = new(database);
            messageHandling = new(database);
        }

        
        public void Start()
        {
            MenuPrint.ShowHeader();
            bool exit = false;

            while (!exit)
            {
                MenuPrint.ShowMenu();
                string? choice = Console.ReadLine();

                exit = MenuSelection(choice!);
            }
        }

        public bool MenuSelection(string choice)
        {
            switch (choice)
            {
            case "1":
                var param = menuHandling.SendMessage();
                messageHandling.SendMessage(param.firstNamePerson, param.lastNamePerson, param.secretCodePerson, param.firstNameTarget, param.lastNameTarget, param.secretCodeTarget, param.message);
                break;
            case "2":
                Console.WriteLine(" ---- Displaying all potential agents... ----");
                reportsHandling.ViewAllPotentialAgents();
                break;
            case "3":
                Console.WriteLine(" ---- Displaying all alerts... ----");
                reportsHandling.ViewAllAlerts();
                break;
            case "4":
                Console.WriteLine(" ---- Displaying all target risk agents... ----");
                reportsHandling.ViewAllTargetRiskAgents();
                break;
            case "5":
                Console.WriteLine(" ---- Exiting the system. Goodbye! ----");
                return true;
            default:
                Console.WriteLine(" ---- Invalid choice. Please enter a valid option. ----");
                break;
            }
            return false;
        }




    }

}
