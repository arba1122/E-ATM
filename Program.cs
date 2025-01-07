using System;
using System.Collections.Generic;

// Huvudklassen som startar programmet
class Program
{
    static void Main()
    {
        Console.WriteLine("--- Startar programmet ---");

        // Skapar en lista med kort och kopplade bankkonton
        var cards = new List<Card>
        {
            new Card(1234, 1111, new BankAccount(10000)),
            new Card(4321, 2222, new BankAccount(35000)),
            new Card(1122, 3333, new BankAccount(180000)),
            new Card(2233, 4444, new BankAccount(56000))
        };

        var atm = new ATM(cards); // Skapar en instans av bankomaten
        atm.Run(); // Kör bankomaten

        Console.WriteLine("--- Programmet avslutas ---");
    }
}