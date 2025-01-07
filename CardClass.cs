using System;

// bankkort hanterar PIN-verifiering och låsning
public class Card
{   //egenskaper
    public int CardNumber { get; private set; } // Kortets nummer
    public bool IsLocked { get; private set; } // Om kortet är låst
    public BankAccount Account { get; private set; } // Kontot kopplat till kortet
    //fält
    private int pin; // Kortets PIN-kod
    private int failedAttempts; // Antal misslyckade PIN-försök
    private const int maxFailedAttempts = 3; // Max antal tillåtna misslyckade försök

    // Konstruktor över kortets egenskaper
    public Card(int cardNumber, int pin, BankAccount account)
    {
        CardNumber = cardNumber;
        this.pin = pin;
        Account = account;
        failedAttempts = 0;
        IsLocked = false;
    }

    // Verifierar att den inslagna PIN-koden är korrekt
    public bool VerifyPin(int inputPin)
    {
        if (IsLocked) // Kontrollera om kortet redan är låst
        {
            Console.WriteLine("Kortet är låst.");
            return false;
        }

        if (inputPin == pin) // Kontrollera om PIN är korrekt
        {
            failedAttempts = 0; // Återställer räknaren
            return true;
        }
        else
        {
            failedAttempts++; // Öka räknaren med 1 för att hålla koll på försök
            if (failedAttempts >= maxFailedAttempts)
            {
                IsLocked = true; // Lås kortet vid max försök
                Console.WriteLine("Kortet har låsts efter för många felaktiga försök.");
            }
            else
            {
                Console.WriteLine($"Fel PIN. Försök kvar: {maxFailedAttempts - failedAttempts}"); // Meddela försök
            }
            return false;
        }
    }
}