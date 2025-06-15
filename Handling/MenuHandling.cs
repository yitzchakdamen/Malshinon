using MySql.Data.MySqlClient;


namespace Malshinon
{
    class MenuHandling : HandlingBase
    {
        public MenuHandling(DatabaseManagement database) : base(database) { }



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

                        if (secretCode == null)
                            Console.WriteLine("\n --- secret code cannot be empty. ---");
                        else
                            isSecretCode = true;
                        break;

                    case "2":
                        Console.Write("Enter first name: ");
                        firstName = Console.ReadLine()!;

                        Console.Write("Enter last name: ");
                        lastName = Console.ReadLine()!;

                        if (firstName == null || lastName == null)
                            Console.WriteLine("\n --- First name and last name cannot be empty. ---");
                        else
                            isSecretCode = true;
                        break;

                    default:
                        Console.WriteLine("Unknown person type.");
                        break;
                }
            }
            return (secretCode, firstName, lastName);

        }

        public  string ReceiveMessage()
        {
            Console.WriteLine("\nEnter your message: ");
            string message = Console.ReadLine()!;
            return message;
        }

        public string? ReceiveSecretCode()
        {
            Console.WriteLine("\nEnter your secret code: ");
            string? secretCode = Console.ReadLine();
            if (secretCode == "")
            {
                Console.WriteLine("\n --- secret code cannot be empty. ---");
                return null;
            }
            return secretCode;
        }
        public (string? firstNamePerson, string? lastNamePerson, string? secretCodePerson) ReceivePersons()
        {
            (string? secretCodePerson, string? firstNamePerson, string? lastNamePerson) = KnowledgeStatus();
            return (firstNamePerson, lastNamePerson, secretCodePerson);
        }

    }

}