class Transaction {
  constructor(name, category, amount) {
    this.name = name;
    this.category = category;
    this.amount = amount;
  }

  toString() {
    return `Transaction for $${this.amount}: [${this.category}] ${this.name}`;
  }
}

export default Transaction;
