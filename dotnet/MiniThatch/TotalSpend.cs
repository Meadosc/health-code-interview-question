namespace MiniThatch;

public static class TotalSpend
{
    private static readonly HashSet<string> NOTABLE_CATEGORIES = new() { "Insurance", "Copay" };

    public static Dictionary<string, double> BySpendType(List<InvoiceItem> invoiceItems)
    {
        var total = new Dictionary<string, double>();

        foreach (var item in invoiceItems)
        {
            double amount = total.GetValueOrDefault(item.SpendType, 0) + item.Transaction.Amount;
            total[item.SpendType] = amount;
        }

        return total;
    }

    public static Dictionary<string, Dictionary<string, double>> BySpendTypeAndCategory(List<InvoiceItem> invoiceItems)
    {
        var total = new Dictionary<string, Dictionary<string, double>>();

        foreach (var item in invoiceItems)
        {
            string category = NOTABLE_CATEGORIES.Contains(item.Transaction.Category) ? item.Transaction.Category : "Other";
            double prevAmount = total.GetValueOrDefault(item.SpendType, new Dictionary<string, double>()).GetValueOrDefault(category, 0);
            
            if (!total.ContainsKey(item.SpendType))
            {
                total[item.SpendType] = new Dictionary<string, double>();
            }

            total[item.SpendType][category] = prevAmount + item.Amount;
        }

        return total;
    }
}
