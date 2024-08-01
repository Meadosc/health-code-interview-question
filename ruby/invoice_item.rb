class InvoiceItem
  attr_reader :spend_type, :amount, :transaction

  def initialize(spend_type:, amount:, transaction:)
    @spend_type = spend_type
    @amount = amount
    @transaction = transaction
  end

  def to_s
    "InvoiceItem for $#{@amount}: #{@spend_type} for #{@transaction.name}"
  end
end
