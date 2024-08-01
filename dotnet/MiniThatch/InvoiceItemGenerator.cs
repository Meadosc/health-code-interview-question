namespace MiniThatch;
using System.Collections.Generic;

public static class InvoiceItemGenerator
{
    public static List<InvoiceItem> GenerateForTransactions(Account account, List<Transaction> transactions)
    {
        /*
         * TODO: Use the balance in the account to create reimbursement InvoiceItems. once
         * the account is empty, create overage InvoiceItems for the remaining transaction amounts.
         * For example:
         *   Account balance: $100
         *   Transaction amounts: $50, $80, $5
         *   InvoiceItems: $50 reimbursement, $50 reimbursement, $30 overage, $5 overage
         */
        return new List<InvoiceItem>();
    }
}