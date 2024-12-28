using System;
using System.Collections.Generic; // Behövs för att använda List<T>

public class BankAccount
{
    private int _balance; // Privat fält som lagrar kontots saldo
    private List<Transaction> transactionHistory; // Lista som lagrar alla transaktioner

    public int Balance => _balance; // public hämtar saldo

    // Konstruktor för kontots saldo och transaktionshistorik
    public BankAccount(int initialBalance)
    {
        _balance = Math.Max(0, initialBalance); // Om saldo är negativ, sätt den till 0
        transactionHistory = new List<Transaction>(); // Skapar en ny lista för transaktionshistoriken
    }

    // Metod för att göra en insättning på kontot
    public bool Deposit(int amount)
    {
        if (amount <= 0) // Kontrollerar att beloppet är större än 0
        {
            Console.WriteLine("Ogiltigt belopp."); // Skriv ut ett felmeddelande om beloppet är ogiltigt
            return false; // Returnera false eftersom insättningen misslyckades
        }
        _balance += amount; // Lägger till beloppet till saldo
        transactionHistory.Add(new Transaction("Insättning", DateTime.Now, amount)); // Lägg till insättningen i transaktionshistoriken
        return true; // Returnera true vid lyckad iteration
    }

    // Metod för att ta ut pengar från kontot
    public bool Withdraw(int amount)
    {
        if (amount <= 0 || amount > _balance) // Kontrollera om beloppet är ogiltigt eller överstiger saldot
        {
            Console.WriteLine("Otillräckligt saldo eller ogiltigt belopp."); // Skriver ut ett felmeddelande
            return false; // Returnera false eftersom uttaget misslyckades
        }
        _balance -= amount; // Dra av beloppet från balansen
        transactionHistory.Add(new Transaction("Uttag", amount, DateTime.Now)); // Lägger till uttaget i transaktionshistoriken
        return true; // Returnera true vid lyckad iteration
    }

    // Metod för att visa den aktuella balansen
    public void ShowBalance()
    {
        Console.WriteLine($"Saldo: {_balance} kr"); // Skriver ut balansen
    }

    // Metod för att visa transaktionshistoriken
    public void ShowTransactionHistory()
    {
        Console.WriteLine("Transaktionshistorik:"); // Skriver ut en rubrik för historiken
        if (transactionHistory.Count == 0) // Kontrollera om det finns några transaktioner
        {
            Console.WriteLine("Ingen transaktionshistorik tillgänglig."); // Meddelar att historiken är tom
        }
        else
        {
            // Loopar genom varje transaktion och skriver ut informatioen
            foreach (var transaction in transactionHistory)
            {
                Console.WriteLine($"{transaction.DateTime}: {transaction.Type} - {transaction.Amount} kr");
            }
        }
    }
}
