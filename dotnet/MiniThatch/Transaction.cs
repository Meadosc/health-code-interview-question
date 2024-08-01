namespace MiniThatch;
public class Transaction
{
    public string Name { get; set; }
    public string Category { get; set; }
    public double Amount { get; set; }

    public Transaction(string name, string category, double amount)
    {
        Name = name;
        Category = category;
        Amount = amount;
    }

    public override string ToString()
    {
        return $"Transaction for ${Amount}: [{Category}] {Name}";
    }
}
