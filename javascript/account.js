class Account {
  constructor(owner, startingBalance) {
    this.owner = owner;
    this.balance = startingBalance;
  }

  toString() {
    return `Account of ${this.owner} with starting balance: $${this.balance}`;
  }
}

export default Account;
