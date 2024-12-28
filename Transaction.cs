





using System;
using System.Collections.Generic;

public class Transaction
{
    // Egenskaper för att beskriva en transaktion
    public string Type { get; set; } // Typ av transaktion (t.ex. "Insättning" eller "Uttag")
    public DateTime DateTime { get; set; } // Datum och tid för transaktionen
    public decimal Amount { get; set; } // Belopp för transaktionen

    // Konstruktor för att skapa en ny transaktion
    public Transaction(string type, DateTime dateTime, decimal amount)
    {
        Type = type;
        DateTime = dateTime;
        Amount = amount;
    }

    // Metod för att visa information om transaktionen
    public void ShowTransactionDetails()
    {
        Console.WriteLine($"{DateTime}: {Type} - {Amount} kr");
    }
}
