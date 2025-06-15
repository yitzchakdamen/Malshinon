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
                    Console.WriteLine(" ---- Sending a message... ----");
                    Console.WriteLine(" ---- Please provide the necessary information to send a message. ----");
                    MessageSendingProcess();
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
                    Console.WriteLine(" ----  Analysis... ----");
                    AnalysisProcess();
                    break;
                case "6":
                    Console.WriteLine(" ---- Exiting the system. Goodbye! ----");
                    return true;
                default:
                    Console.WriteLine(" ---- Invalid choice. Please enter a valid option. ----");
                    break;
            }
            return false;
        }

        void MessageSendingProcess()
        {
            Console.Write("\n --- Enter <<< your >>> information. ---\n");
            if (messageHandling.PeopleHandling(menuHandling.ReceivePersons()) is not int personID)
            {
                Console.WriteLine(" ---- Invalid person information. Please try again. ----");
                return;
            }

            Console.Write("\n --- Enter <<< target >>> information. ---\n");
            if (messageHandling.PeopleHandling(menuHandling.ReceivePersons()) is not int targetID)
            {
                Console.WriteLine(" ---- Invalid target information. Please try again. ----");
                return;
            }
            string message = menuHandling.ReceiveMessage();
            messageHandling.SendMessage(personID, targetID, message);
            return;
        }
        void AnalysisProcess()
        {
            string? secretCode = menuHandling.ReceiveSecretCode();
            if (secretCode != null)
            {
                reportsHandling.AnalysisById(secretCode);
            }
            
        }




    }

}
