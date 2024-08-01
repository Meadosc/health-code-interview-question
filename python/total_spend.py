class TotalSpend:
  NOTABLE_CATEGORIES = {"Insurance", "Copay"}

  @staticmethod
  def by_spend_type(invoice_items):
    total = {}
    for item in invoice_items:
      amount = total.get(item.spend_type, 0) + item.transaction.amount
      total[item.spend_type] = amount
    return total

  @staticmethod
  def by_spend_type_and_category(invoice_items):
    total = {}
    for item in invoice_items:
      if item.transaction.category in TotalSpend.NOTABLE_CATEGORIES:
        category = item.transaction.category
      else:
        category = "Other"
      amount = total.get((item.spend_type, category), 0) + item.amount
      total[(item.spend_type, category)] = amount
    return total
