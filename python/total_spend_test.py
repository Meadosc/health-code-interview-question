from transaction import Transaction
from invoice_item import InvoiceItem
from total_spend import TotalSpend

def test_by_spend_type1():
  txn_1 = Transaction(name="Insurance premium", category="Insurance", amount=100)
  itm_1 = InvoiceItem(spend_type="reimbursement", amount=100, transaction=txn_1)

  txn_2 = Transaction(name="Dentist appointment", category="copay", amount=11.33)
  itm_2 = InvoiceItem(spend_type="overage", amount=11.33, transaction=txn_2)

  total = TotalSpend.by_spend_type([itm_1, itm_2])
  
  assert total == {"reimbursement": 100, "overage": 11.33}


def test_by_spend_type2():
  txn_1 = Transaction(name="Insurance premium", category="Insurance", amount=50.75)
  itm_1 = InvoiceItem(spend_type="reimbursement", amount=50.75, transaction=txn_1)

  txn_2 = Transaction(name="Dentist appointment", category="copay", amount=91.25)
  itm_2 = InvoiceItem(spend_type="reimbursement", amount=49.25, transaction=txn_2)
  itm_3 = InvoiceItem(spend_type="overage", amount=42, transaction=txn_2)

  total = TotalSpend.by_spend_type([itm_1, itm_2, itm_3])
  
  assert total == {"reimbursement": 100.0, "overage": 42.0}


def test_by_spend_type_and_category():
  txn_1 = Transaction(name="Insurance premium", category="Insurance", amount=50.75)
  itm_1 = InvoiceItem(spend_type="reimbursement", amount=50.75, transaction=txn_1)

  txn_2 = Transaction(name="Dentist appointment", category="copay", amount=91.25)
  itm_2 = InvoiceItem(spend_type="reimbursement", amount=49.25, transaction=txn_2)
  itm_3 = InvoiceItem(spend_type="overage", amount=42, transaction=txn_2)

  txn_3 = Transaction(name="Target purchase", category="retail", amount=5.25)
  itm_4 = InvoiceItem(spend_type="overage", amount=5.25, transaction=txn_3)

  txn_4 = Transaction(name="Amazon purchase", category="online", amount=10.0)
  itm_5 = InvoiceItem(spend_type="overage", amount=10.0, transaction=txn_4)

  total = TotalSpend.by_spend_type_and_category([itm_1, itm_2, itm_3, itm_4, itm_5])

  assert total == {("reimbursement", "Insurance"): 50.75, ("reimbursement", "Copay"): 49.25, ("overage", "Copay"): 42.0, ("overage", "Other"): 15.25}


if __name__ == "__main__":
  test_by_spend_type1()
  test_by_spend_type2()
  test_by_spend_type_and_category()

  print("All tests passed!")
