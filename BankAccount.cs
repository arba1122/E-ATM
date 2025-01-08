using System;
using System.Collections.Generic;

// Hanterar ett bankkonto, dess saldo och transaktioner
public class BankAccount
{
    // Egenskaper 
    public decimal Balance { get; private set; } // Kontots saldo, skrivs endast internt
    public int MaxDailyWithdrawals { get; } = 5; // Max antal uttag konstant
    public decimal MaxDailyAmount { get; } = 25000; // Max belopp konstant

    // Transaktionshistorik som en egenskap
    public List<Transaction> TransactionHistory { get; private set; } = new List<Transaction>();

    public int DailyWithdrawals { get; private set; } = 0; // Räknare för dagens antal uttag
    public decimal DailyWithdrawalAmount { get; private set; } = 0; // Total summa av dagens uttag
    public DateTime LastWithdrawalDate { get; private set; } = DateTime.Today; // Datum för senaste uttaget

    // Konstruktor över kontots startbalans
    public BankAccount(decimal startBalance)
    {
        Balance = startBalance;
    }

    // Hanterar uttag från kontot
    public bool Withdraw(decimal amount)
    {
        // Kontrollera om datumet har ändrats (ny dag, återställ räkneverk)
        if (LastWithdrawalDate.Date != DateTime.Today)
        {
            DailyWithdrawals = 0; // Återställ antalet uttag
            DailyWithdrawalAmount = 0; // Återställ dagens totala uttagssumma
            LastWithdrawalDate = DateTime.Today; // Uppdatera senaste uttagsdatum
        }

        // Kontrollera dagliga gränser
        if (DailyWithdrawals >= MaxDailyWithdrawals)
        {
            Console.WriteLine("Du har nått max antal uttag för idag."); // Meddelande om max uttag nåtts
            return false;
        }
        if (DailyWithdrawalAmount + amount > MaxDailyAmount)
        {
            Console.WriteLine("Du har nått max uttagsbelopp för idag."); // Meddelande om max belopp nåtts
            return false;
        }
        if (amount > Balance)
        {
            Console.WriteLine("Otillräckligt saldo."); // Meddelande om det saknas pengar på kontot
            return false;
        }

        // Genomför uttag
        Balance -= amount; // Minska saldot
        DailyWithdrawals++; // Öka antalet uttag
        DailyWithdrawalAmount += amount; // Lägg till beloppet i dagens totala uttagssumma
        TransactionHistory.Add(new Transaction("Uttag", DateTime.Now, amount)); // Lägg till transaktion i historiken
        Console.WriteLine($"Du har tagit ut {amount:C}. Ditt nya saldo är {Balance:C}."); // Meddelande om lyckat uttag
        return true;
    }

    // Hanterar insättning på kontot
    public void Deposit(decimal amount)
    {
        Balance += amount; // Öka saldot
        TransactionHistory.Add(new Transaction("Insättning", DateTime.Now, amount)); // Lägg till transaktion
        Console.WriteLine($"Du har satt in {amount:C}. Ditt nya saldo är {Balance:C}."); // Meddelande om lyckad insättning
    }

    // Visar alla transaktioner för kontot
    public void ShowTransactionHistory()
    {
        Console.WriteLine("Transaktionshistorik:"); // Rubrik för transaktionshistoriken
        if (TransactionHistory.Count > 0) // Kontrollera om det finns transaktioner
        {
            foreach (var transaction in TransactionHistory)
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
