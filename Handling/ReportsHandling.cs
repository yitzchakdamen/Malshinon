using MySql.Data.MySqlClient;


namespace Malshinon
{
    class ReportsHandling : HandlingBase
    {
        Tools tools;
        MessageHandling messageHandling;
        public ReportsHandling(DatabaseManagement database) : base(database)
        {
            tools = new Tools(managementPerson, managementIntel);
            messageHandling = new MessageHandling(database);
        }


        public void ShowMenu()
        {
            Console.WriteLine("1. Send Message");
            Console.WriteLine("2. View All Potential Agents");
            Console.WriteLine("3. Manage Alerts");
            Console.WriteLine("4. Exit");
        }
        public void ShowOption()
        {
            Console.WriteLine("Select the type of person:");
            Console.WriteLine("1. Secret Code");
            Console.WriteLine("2. First Name and Last Name");
            Console.Write("Enter your choice: ");
        }

        (string? secretCode, string? firstName, string? lastName) KnowledgeStatus()
        {

            bool isSecretCode = false;
            string? secretCode = null;
            string? firstName = null;
            string? lastName = null;

            while (!isSecretCode)
            {
                ShowOption();
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter secret code: ");
                        secretCode = Console.ReadLine()!;
                        if (!string.IsNullOrEmpty(secretCode))
                            isSecretCode = true;
                        break;
                    case "2":
                        Console.Write("Enter first name: ");
                        firstName = Console.ReadLine()!;
                        Console.Write("Enter last name: ");
                        lastName = Console.ReadLine()!;
                        if (!string.IsNullOrEmpty(firstName) || !string.IsNullOrEmpty(lastName))
                            isSecretCode = true;
                        break;
                    default:
                        Console.WriteLine("Unknown person type.");
                        break;
                }

            }
            return (secretCode, firstName, lastName);

        }

        public void SendMessage()
        {
            Console.WriteLine("Sending message...");
            Console.Write("Enter your information.");
            (string? secretCodePerson , string? firstNamePerson, string? lastNamePerson) = KnowledgeStatus();

            Console.Write("Enter the target information.");
            (string? secretCodeTarget , string? firstNameTarget, string? lastNameTarget) = KnowledgeStatus();

            Console.WriteLine( "enter your message: ");
            string message = Console.ReadLine()!;

            messageHandling.SendMessage(
                firstNamePerson,
                lastNamePerson,
                secretCodePerson,
                firstNameTarget,
                lastNameTarget,
                secretCodeTarget,
                message
            );
        }

        public void ViewAllPotentialAgents()
        {
            List<PersonStatus> potentialAgents = managementReports.AllPotentialAgents();
            View(potentialAgents);
        }

        public void ViewAllTargetRiskAgents()
        {
            List<PersonStatus> targetRiskAgents = managementReports.AllTargetRisk();
            View(targetRiskAgents);
        }

        public void View(List<PersonStatus> potentialAgents)
        {
            foreach (var agent in potentialAgents)
            {
                Person? person = managementPerson._dalPeople.GetPersonById(agent.PeopleId);
                int numberReports = managementIntel.NumberReportsByReporter(agent.PeopleId);
                int AvrReports = managementIntel.AverageLengthReports(agent.PeopleId);

                Console.WriteLine("--------------------------------------------------");
                Console.Write($"Potential Agent ID: {agent.PeopleId}, Risk Level: {agent.TargetRisk} ");
                Console.WriteLine($"Name: {person?.FirstName} {person?.LastName}, Secret Code: {person?.SecretCode}");
                Console.WriteLine($"Number of Reports: {numberReports}");
                Console.WriteLine($"Average Length of Reports: {AvrReports}");
            }
        }

        public void ViewAllAlerts()
        {
            List<Alert> alerts = managementAlerts.GetAllAlertsByList();
            foreach (var alert in alerts)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Alert ID: {alert.Id}, Timestamp: {alert.Timestamp}, Description: {alert.Reason}");
                Person person = managementPerson._dalPeople.GetPersonById(alert.TargetId)!;
                Console.WriteLine($"Target : {person.FirstName} LastName: {person.LastName}, Secret Code: {person.SecretCode}");
            }
        }

        public bool MenuSelection(string choice)
        {
            switch (choice)
            {
                case "1":
                    SendMessage();
                    break;
                case "2":
                    Console.WriteLine("Viewing All Potential Agents...");
                    ViewAllPotentialAgents();
                    break;
                case "3":
                    Console.WriteLine("Managing Alerts...");
                    ViewAllAlerts();
                    break;
                case "4":
                    Console.WriteLine("Target Risk Agents:");
                    ViewAllTargetRiskAgents();
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    return true;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            return false;
        }


    }

}