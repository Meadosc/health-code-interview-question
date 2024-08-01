namespace MiniThatchTest;
using MiniThatch;

public class TotalSpendTest : UnitTest
{
    protected override List<Action> Tests => new()
    {
        TestBySpendType1,
        TestBySpendType2,
        TestBySpendTypeAndCategory,
    };

    private void TestBySpendType1()
    {
        var txn1 = new Transaction("Insurance premium", "Insurance", 100);
        var itm1 = new InvoiceItem("reimbursement", 100, txn1);

        var txn2 = new Transaction("Dentist appointment", "copay", 11.33);
        var itm2 = new InvoiceItem("overage", 11.33, txn2);

        var total = TotalSpend.BySpendType(new List<InvoiceItem> { itm1, itm2 });

        AssertEqual(total, new Dictionary<string, double> { { "reimbursement", 100 }, { "overage", 11.33 } });
    }

    private void TestBySpendType2()
    {
        var txn1 = new Transaction("Insurance premium", "Insurance", 50.75);
        var itm1 = new InvoiceItem("reimbursement", 50.75, txn1);

        var txn2 = new Transaction("Dentist appointment", "copay", 91.25);
        var itm2 = new InvoiceItem("reimbursement", 49.25, txn2);
        var itm3 = new InvoiceItem("overage", 42, txn2);

        var total = TotalSpend.BySpendType(new List<InvoiceItem> { itm1, itm2, itm3 });

        AssertEqual(total, new Dictionary<string, double> { { "reimbursement", 100 }, { "overage", 42 } });
    }

    private void TestBySpendTypeAndCategory()
    {
        var txn1 = new Transaction("Insurance premium", "Insurance", 50.75);
        var itm1 = new InvoiceItem("reimbursement", 50.75, txn1);

        var txn2 = new Transaction("Dentist appointment", "copay", 91.25);
        var itm2 = new InvoiceItem("reimbursement", 49.25, txn2);
        var itm3 = new InvoiceItem("overage", 42, txn2);

        var txn3 = new Transaction("Target purchase", "retail", 5.25);
        var itm4 = new InvoiceItem("overage", 5.25, txn3);

        var txn4 = new Transaction("Amazon purchase", "online", 10.0);
        var itm5 = new InvoiceItem("overage", 10.0, txn4);

        var total = TotalSpend.BySpendTypeAndCategory(new List<InvoiceItem> { itm1, itm2, itm3, itm4, itm5 });

        AssertEqual(total, new Dictionary<string, Dictionary<string, double>>
        {
            {
                "reimbursement", new Dictionary<string, double>
                {
                    { "Insurance", 50.75 },
                    { "Copay", 49.25 },
                }
            },
            {
                "overage", new Dictionary<string, double>
                {
                    { "Copay", 42 },
                    { "Other", 15.25 },
                }
            },
        });
    }
}
