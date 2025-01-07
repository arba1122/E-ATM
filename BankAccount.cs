using System;
using System.Collections.Generic;

//  Hanterar ett bankkonto, dess saldo och transaktioner
public class BankAccount
{
    private decimal balance; // Kontots saldo
    private List<Transaction> transactionHistory = new List<Transaction>(); // Lista med transaktioner

    // Konstruktor över kontots startbalans
    public BankAccount(decimal startBalance)
    {
        balance = startBalance;
    }

    // Returnerar det aktuella saldot
    public decimal GetBalance()
    {
        return balance;
    }

    // Hanterar uttag från kontot
    public bool Withdraw(decimal amount)
    {
        if (amount <= balance) // Kontrollera om det finns tillräckligt med pengar
        {
            balance -= amount; // Minska saldot
            transactionHistory.Add(new Transaction("Uttag", DateTime.Now, amount)); // Lägg till transaktion
            Console.WriteLine($"Du har tagit ut {amount:C}. Ditt nya saldo är {balance:C}.");
            return true;
        }
        else
        {
            Console.WriteLine("Otillräckligt saldo."); // Felmeddelande om pengarna inte räcker
            return false;
        }
    }

    // Hanterar insättning på kontot
    public void Deposit(decimal amount)
    {
        balance += amount; // Öka saldot
        transactionHistory.Add(new Transaction("Insättning", DateTime.Now, amount)); // Lägg till transaktion
        Console.WriteLine($"Du har satt in {amount:C}. Ditt nya saldo är {balance:C}.");
    }

    // Visar alla transaktioner för kontot
    public void ShowTransactionHistory()
    {
        Console.WriteLine("Transaktionshistorik:");
        if (transactionHistory.Count > 0) // Kontrollera om det finns transaktioner
        {
            foreach (var transaction in transactionHistory)
            {
                transaction.ShowTransactionDetails(); // Visa detaljer för varje transaktion
            }
        }
        else
        {
            Console.WriteLine("Inga transaktioner ännu."); // Meddelande om historiken är tom
        }
    }
}