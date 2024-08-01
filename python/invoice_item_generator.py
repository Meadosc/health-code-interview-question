from invoice_item import InvoiceItem

class InvoiceItemGenerator:
  # TODO: Use the balance in the account to create reimbursement InvoiceItems. once
  # the account is empty, create overage InvoiceItems for the remaining transaction amounts.
  # For example:
  #   Account balance: $100
  #   Transaction amounts: $50, $80, $5
  #   InvoiceItems: $50 reimbursement, $50 reimbursement, $30 overage, $5 overage
  @staticmethod
  def generate_for_transactions(account, transactions):
    return []
