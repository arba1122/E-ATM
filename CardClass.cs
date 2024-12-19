

//funderingar till krister att pin attempt maxattempt sk avara i card eller account

using System.ComponentModel.Design;

public class Card

{

    public int CardNumber { get; } // Kortnummer
    private int Pin { get; } // Lagrad PIN-kod
    private int PinAttempts; // Antal felaktiga försök
    private const int MaxAttempts = 3; // Max antal försök innan kortet låses. Const För värden som aldrig ändras och är kända vid kompilering.
    public bool IsLocked { get; private set; } // Om kortet är låst

    public Card(int cardNumber, int pin)
    {
        CardNumber = cardNumber;
        Pin = pin;
        PinAttempts = 0; // Sätt initialt antal försök till 0
        IsLocked = false; //false kortet är inte låst från början


    }

    

    public bool CheckPin(int inputPin)
    {
        if (IsLocked)
        {
            Console.WriteLine("Kortet är låst.");
            return false;
        }

        if (inputPin == Pin)
        {
            PinAttempts = 0; // Återställ antalet försök vid korrekt PIN
            return true;
        }
        else
        {
            PinAttempts++;

            if (PinAttempts >= MaxAttempts)
            {
                IsLocked = true;
                Console.WriteLine("Kortet har låsts efter tre felaktiga försök.");
            }
            else
            {
                Console.WriteLine($"Felaktig PIN. Försök kvar: {MaxAttempts - PinAttempts}");
            }
            return false;
        }
    }






















}





