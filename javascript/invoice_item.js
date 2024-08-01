class InvoiceItem {
  constructor(spendType, amount, transaction) {
    this.spendType = spendType;
    this.amount = amount;
    this.transaction = transaction;
  }

  toString() {
    return `InvoiceItem for $${this.amount}: ${this.spendType} for ${this.transaction.name}`;
  }
}

export default InvoiceItem;