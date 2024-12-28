public class ATM
{
    public List<Card> Cards;
    private const int MaxWithdrawals = 3;
    private const int MaxAmountPerWithdrawal = 5000;

    public ATM(List<Card> cards)
    {
        Cards = cards;
    }

    public void Run()
    {
        Console.Write("Ange kortnummer: ");
        if (!int.TryParse(Console.ReadLine(), out int cardNumber))
        {
            Console.WriteLine("Ogiltigt kortnummer.");
            return;
        }

        Card userCard = Cards.Find(card => card.CardNumber == cardNumber);

        if (userCard == null)
        {
            Console.WriteLine("Kortnummer hittades inte.");
            return;
        }

        for (int i = 0; i < 3; i++)
        {
            Console.Write("Ange PIN: ");
            if (!int.TryParse(Console.ReadLine(), out int pin))
            {
                Console.WriteLine("Ogiltig PIN.");
                continue;
            }

            if (userCard.CheckPin(pin))
            {
                ShowMenu(userCard);
                return;
            }
        }

        Console.WriteLine("Max antal försök uppnått. Kortet är nu låst.");
    }

    private void ShowMenu(Card card)
    {
        int withdrawalCount = 0;

        while (true)
        {
            Console.WriteLine("\n1. Visa saldo");
            Console.WriteLine("2. Ta ut pengar");
            Console.WriteLine("3. Visa transaktionshistorik");
            Console.WriteLine("4. Avsluta");
            Console.Write("Välj ett alternativ: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Ogiltigt val.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    card.Account.ShowBalance();
                    break;
                case 2:
                    if (withdrawalCount >= MaxWithdrawals)
                    {
                        Console.WriteLine("Max antal uttag nått.");
                        break;
                    }

                    Console.Write("Ange belopp att ta ut: ");
                    if (!int.TryParse(Console.ReadLine(), out int amount) || amount <= 0)
                    {
                        Console.WriteLine("Ogiltigt belopp.");
                        break;
                    }

                    if (amount > MaxAmountPerWithdrawal)
                    {
                        Console.WriteLine("Beloppet överstiger maxbeloppet per uttag.");
                        break;
                    }

                    if (card.Account.Withdraw(amount))
                    {
                        withdrawalCount++;
                        Console.WriteLine($"Du har tagit ut {amount} kr.");
                    }
                    break;
                case 3:
                    card.Account.ShowTransactionHistory();
                    break;
                case 4:
                    Console.WriteLine("Avslutar...");
                    return;
                default:
                    Console.WriteLine("Ogiltigt val.");
                    break;
            }
        }
    }
}
