class InvoiceItem:
  def __init__(self, spend_type, amount, transaction):
    self.spend_type = spend_type
    self.amount = amount
    self.transaction = transaction

  def __str__(self):
    return f"InvoiceItem for ${self.amount}: {self.spend_type} for {self.transaction.name}"
