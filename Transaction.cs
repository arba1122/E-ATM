using System;

// Klassen transaktion med typ, datum och belopp
public class Transaction
{
    public string Type { get; } // Typ av transaktion (t.ex. "Uttag" eller "Insättning")
    public DateTime DateTime { get; } // Datum och tid för transaktionen
    public decimal Amount { get; } // Beloppet för transaktionen

    // Konstruktor som initierar transaktionens egenskaper
    public Transaction(string type, DateTime dateTime, decimal amount)
    {
        Type = type;
        DateTime = dateTime;
        Amount = amount;
    }

    // Metod som visar detaljer om transaktionen
    public void ShowTransactionDetails()
    {
        Console.WriteLine($"{DateTime}: {Type} - {Amount:C}"); // Skriv ut detaljer i formatet "Datum: Typ - Belopp"
    }
}