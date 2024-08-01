namespace MiniThatch;
public class Account
{
    public string Owner { get; set; }
    public double Balance { get; set;}

    public Account(string owner, double startingBalance)
    {
        Owner = owner;
        Balance = startingBalance;
    }

    public override string ToString()
    {
        return $"Account of {Owner} with starting balance: ${Balance}";
    }
}
