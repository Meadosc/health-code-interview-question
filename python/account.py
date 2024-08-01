class Account:
  def __init__(self, owner, starting_balance):
    self.owner = owner
    self.balance = starting_balance

  def __str__(self):
    return f"Account of {self.owner} with starting balance: ${self.balance}"
