import InvoiceItem from './invoice_item.js';

class InvoiceItemGenerator {
  // TODO: Use up the balance in the account to create reimbursement InvoiceItems. Once
  // the account is empty, create overage InvoiceItems for any additional spending.
  // For example:
  //   Account balance: $100
  //   Transaction amounts: $50, $50, $5
  //   InvoiceItems: $50 reimbursement, $50 reimbursement, $5 overage
  static generateForTransactions(account, transactions) {
    return []
  }
}

export default InvoiceItemGenerator;
