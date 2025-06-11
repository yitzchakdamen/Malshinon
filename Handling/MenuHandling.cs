using MySql.Data.MySqlClient;


namespace Malshinon
{
    class MenuHandling : HandlingBase
    {
        public MenuHandling(DatabaseManagement database) : base(database) {}



        (string? secretCode, string? firstName, string? lastName) KnowledgeStatus()
        {

            bool isSecretCode = false;
            string? secretCode = null;
            string? firstName = null;
            string? lastName = null;

            while (!isSecretCode)
            {
                MenuPrint.ShowOption();
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

        public (
            string? secretCodePerson,
            string? firstNamePerson,
            string? lastNamePerson,
            string? secretCodeTarget,
            string? firstNameTarget,
            string? lastNameTarget,
            string message)
            SendMessage()
        {
            Console.WriteLine("\nSending message...");

            Console.Write("\nEnter your information.");
            (string? secretCodePerson, string? firstNamePerson, string? lastNamePerson) = KnowledgeStatus();

            Console.Write("\nEnter the target information.");
            (string? secretCodeTarget, string? firstNameTarget, string? lastNameTarget) = KnowledgeStatus();

            Console.WriteLine("\nEnter your message: ");
            string message = Console.ReadLine()!;
            return (secretCodePerson, firstNamePerson, lastNamePerson, secretCodeTarget, firstNameTarget, lastNameTarget, message);


        }

    }

}