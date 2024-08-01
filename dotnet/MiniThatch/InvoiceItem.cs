namespace MiniThatch;
public class InvoiceItem
{
    public string SpendType { get; set; }
    public double Amount { get; set; }
    public Transaction Transaction { get; set; }

    public InvoiceItem(string spendType, double amount, Transaction transaction)
    {
        SpendType = spendType;
        Amount = amount;
        Transaction = transaction;
    }

    public override string ToString()
    {
        return $"InvoiceItem for ${Amount}: {SpendType} for {Transaction.Name}";
    }
}
