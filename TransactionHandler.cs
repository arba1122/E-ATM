public class TransactionHandler
{
    private List<Transaction> transactionHistory = new List<Transaction>();

    public void AddTransaction(string type, decimal amount, DateTime dateTime)
    {
        transactionHistory.Add(new Transaction(type, dateTime, amount));

    }

    public void PrintTransactionHistory()
    {
        Console.WriteLine("Transaktionshistorik:");
        foreach (var transaction in transactionHistory)
        {
            Console.WriteLine($"{transaction.Type}: {transaction.DateTime} - {transaction.Amount:C}");
        }
    }
}
