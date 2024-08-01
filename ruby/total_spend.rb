require 'set'

class TotalSpend
  NOTABLE_CATEGORIES = Set["Insurance", "Copay"]

  def self.by_spend_type(invoice_items)
    total = {}

    invoice_items.each do |item|
      amount = total.fetch(item.spend_type, 0) + item.transaction.amount
      total[item.spend_type] = amount
    end

    total
  end

  def self.by_spend_type_and_category(invoice_items)
    total = {}

    invoice_items.each do |item|
      category = TotalSpend::NOTABLE_CATEGORIES.include?(item.transaction.category) ? item.transaction.category : "Other"
      prev_amount = total.dig(item.spend_type, category) || 0
      unless total.include?(item.spend_type)
        total[item.spend_type] = {}
      end
      total[item.spend_type][category] = prev_amount + item.amount
    end

    total
  end
end
