from account import Account
from invoice_item import InvoiceItem
from transaction import Transaction
from invoice_item_generator import InvoiceItemGenerator

def test_generate_for_transactions1():
  account = Account("Craig Ellis", 100)
  txn_1 = Transaction(name="Insurance premium", category="Insurance", amount=50)
  txn_2 = Transaction(name="Dentist appointment", category="copay", amount=80)
  txn_3 = Transaction(name="Target purchase", category="retail", amount=5)

  generated = InvoiceItemGenerator.generate_for_transactions(account, [txn_1, txn_2, txn_3])
  
  assert generated[0].spend_type == "reimbursement"
  assert generated[0].amount == 50
  assert generated[0].transaction.name == "Insurance premium"

  assert generated[1].spend_type == "reimbursement"
  assert generated[1].amount == 50
  assert generated[1].transaction.name == "Dentist appointment"

  assert generated[2].spend_type == "overage"
  assert generated[2].amount == 30
  assert generated[2].transaction.name == "Dentist appointment"

  assert generated[3].spend_type == "overage"
  assert generated[3].amount == 5
  assert generated[3].transaction.name == "Target purchase"


if __name__ == "__main__":
  test_generate_for_transactions1()

  print("All tests passed!")
