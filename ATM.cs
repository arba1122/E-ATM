using System;
using System.Collections.Generic;

// Klassen representerar en bankomat
public class ATM
{
    public List<Card> Cards; // Lista med kort som är tillgängliga för bankomaten

    // Konstruktor som initierar listan med kort
    public ATM(List<Card> cards)
    {
        Cards = cards;
    }

    // Huvudmetod som kör bankomatens funktioner
    public void Run()
    {
        Console.WriteLine("--- Välkommen till E-ATM ---");

        while (true)
        {
            Console.Write("Ange kortnummer (eller 'exit' för att avsluta): ");
            string input = Console.ReadLine();

            if (input?.ToLower() == "exit") // Avsluta programmet om användaren skriver "exit"
            {
                Console.WriteLine("Tack för att du använde E-ATM!");
                break;
            }

            if (int.TryParse(input, out int cardNumber)) // Kontrollera att kortnumret är giltigt
            {
                Card userCard = FindCard(cardNumber); // Sök efter kortet

                if (userCard != null)
                {
                    if (!userCard.IsLocked) // Kontrollera att kortet inte är låst
                    {
                        if (VerifyPin(userCard)) // Verifiera PIN-koden
                        {
                            ShowMainMenu(userCard); // Visa huvudmenyn om verifieringen lyckas
                        }
                    }
                    else
                    {
                        Console.WriteLine("Det här kortet är låst. Kontakta banken.");
                    }
                }
                else
                {
                    Console.WriteLine("Kortet hittades inte."); // Felmeddelande om kortet inte finns
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt kortnummer. Försök igen."); // Meddelande om kortnummer inte är giltigt
            }
        }
    }

    // Hitta kort i listan baserat på kortnummer
    private Card FindCard(int cardNumber)
    {
        return Cards.Find(card => card.CardNumber == cardNumber);
    }

    // Verifiera PIN-koden för ett kort
    private bool VerifyPin(Card card)
    {
        Console.WriteLine("--- Verifiering ---");
        for (int i = 0; i < 3; i++) // Tillåt tre försök
        {
            Console.Write("Ange PIN: ");
            if (int.TryParse(Console.ReadLine(), out int pin) && card.VerifyPin(pin))
            {
                Console.WriteLine("Verifiering lyckades!");
                return true;
            }
        }
        return false;
    }

    // Visa huvudmenyn för kortet
    private void ShowMainMenu(Card card)
    {
        while (true)
        {
            Console.WriteLine("\n--- Huvudmeny ---");
            Console.WriteLine("1. Visa saldo");
            Console.WriteLine("2. Ta ut pengar");
            Console.WriteLine("3. Visa transaktionshistorik");
            Console.WriteLine("4. Logga ut");
            Console.Write("Välj ett alternativ: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Visa saldo
                    Console.WriteLine($"Ditt saldo är: {card.Account.Balance:C}");
                    break;
                case "2": // Hantera uttag
                    HandleWithdrawal(card);
                    break;
                case "3": // Visa transaktionshistorik
                    card.Account.ShowTransactionHistory();
                    break;
                case "4": // Logga ut
                    Console.WriteLine("Du har loggats ut.");
                    return; // Avsluta menyn
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen."); // Felmeddelande om valet inte är giltigt
                    break;
            }
        }
    }

    // Hantera uttag av pengar
    private void HandleWithdrawal(Card card)
    {
        Console.Write("Ange belopp att ta ut: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0) // Kontrollera giltigt belopp
        {
            if (!card.Account.Withdraw(amount))
            {
                Console.WriteLine("Otillräckligt saldo eller maxgräns nådd."); // Felmeddelande vid problem
            }
        }
        else
        {
            Console.WriteLine("Ogiltigt belopp."); // Meddelande vid felaktigt belopp
        }
    }
}
