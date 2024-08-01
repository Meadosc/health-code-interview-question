class Transaction
  attr_reader :name, :category, :amount

  def initialize(name:, category:, amount:)
    @name = name
    @category = category
    @amount = amount
  end

  def to_s
    "Transaction for $#{@amount}: [#{@category}] #{@name}"
  end
end
