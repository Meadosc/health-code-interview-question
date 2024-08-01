require './invoice_item.rb'

class InvoiceItemGenerator
  # TODO: Use up the balance in the account to create reimbursement InvoiceItems. Once
  # the account is empty, create overage InvoiceItems for any additional spending.
  # For example:
  #   Account balance: $100
  #   Transaction amounts: $50, $50, $5
  #   InvoiceItems: $50 reimbursement, $50 reimbursement, $5 overage
  def self.generate_for_transactions(account, transactions)
    []
  end
end
