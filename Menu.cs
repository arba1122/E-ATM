




public class Menu
{

    public static void MenuDisplay() // static för att behöver inte skapas flera instanser
    {

        bool isRunning = true; // Loopen körs så länge de true

        while (isRunning) // whle loop fråga krister bör de vara "Environment.Exit(0)" 
        {
            Console.Clear();
            Console.WriteLine("E-ATM Huvudmeny - Fyll i ditt nummer!");
            Console.WriteLine("1. Visa saldo");
            Console.WriteLine("2. Ta ut pengar");
            Console.WriteLine("3. Visa transaktionshistorik");
            Console.WriteLine("4. Avsluta");
            Console.Write("Välj ett alternativ: ");


            string choice = Console.ReadLine(); //Läser in  valet från användaren , fråga krister int eller string?


            int QurrentAmount = 0; // Exempel på deklaration


            switch (choice) // Switch-case för att hantera användarens val
            {
                case "1": // Visa saldo
                    Console.WriteLine($"Ditt Saldo är: {QurrentAmount} kr"); 
                    break;
                case "2": // Ta ut pengar
                    Console.Write("Ange belopp att ta ut: ");
                    string amountInput = Console.ReadLine();
                    if (int.TryParse(amountInput, out int amount) && amount > 0)
                    {
                        Console.WriteLine($"Du har tagit ut {amount} kr."); 
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt belopp.");
                    }
                    break;
                case "3": // Visa transaktionshistorik
                    Console.WriteLine("Transaktionshistorik:");
        
                    break;
                case "4": // Avsluta
                    Console.WriteLine("Avslutar programmet...");
                    isRunning = false; // Avslutar loopen
                    break;
                default: // Ogiltigt val
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
    }















}