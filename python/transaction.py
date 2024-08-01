class Transaction:
  def __init__(self, name, category, amount):
    self.name = name
    self.category = category
    self.amount = amount

  def __str__(self):
    return f"Transaction for ${self.amount}: [{self.category}] {self.name}"
