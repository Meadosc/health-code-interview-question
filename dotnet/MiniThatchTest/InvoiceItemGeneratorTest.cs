namespace MiniThatchTest;
using MiniThatch;

public class InvoiceItemGeneratorTest : UnitTest
{
    protected override List<Action> Tests => new()
    {
        TestGenerateForTransactions,
    };

    private void TestGenerateForTransactions()
    {
        var account = new Account("Craig Ellis", 100.0);
        var txn1 = new Transaction("Insurance premium", "Insurance", 50);
        var txn2 = new Transaction("Dentist appointment", "copay", 80);
        var txn3 = new Transaction("Target purchase", "retail", 5);

        var generated = InvoiceItemGenerator.GenerateForTransactions(account, new List<Transaction> { txn1, txn2, txn3 });

        AssertEqual(generated[0].SpendType, "reimbursement");
        AssertEqual(generated[0].Amount, 50);
        AssertEqual(generated[0].Transaction.Name, "Insurance premium");

        AssertEqual(generated[1].SpendType, "reimbursement");
        AssertEqual(generated[1].Amount, 50);
        AssertEqual(generated[1].Transaction.Name, "Dentist appointment");

        AssertEqual(generated[2].SpendType, "overage");
        AssertEqual(generated[2].Amount, 30);
        AssertEqual(generated[2].Transaction.Name, "Dentist appointment");

        AssertEqual(generated[3].SpendType, "overage");
        AssertEqual(generated[3].Amount, 5);
        AssertEqual(generated[3].Transaction.Name, "Target purchase");
    }
}
