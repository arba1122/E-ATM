


public class Eatm // public eller private......
{

    

     public void WithDraw(BankAccount bankAccount) // Metod som hanterar uttag utefter saldo. I det här fallet är BankAccount min  värdetyp som har en varibael därefter bankAccount. Saldon lagras i klassen BankAccount så den går att nå.
    {
        Console.WriteLine("Hur mycket vill du ta ut?");
        int amount = int.Parse(Console.ReadLine());



        if (amount > bankAccount.Balance)
        {

            Console.WriteLine("Det finns inte tillräckligt mycket pengar på kontot! Försök igen.");
             return;

        }

        else
        {
            bankAccount.Balance -= amount; // bankAccount.Balance = bankAccount-Balance - amount alltså subtraheras amount från balance

            Console.WriteLine($"Du har tagit ut {amount} kr.");







        }



    }
}







